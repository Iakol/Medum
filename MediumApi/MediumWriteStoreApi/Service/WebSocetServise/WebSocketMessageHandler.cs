using MediumWriteStoreApi.DTO.ContentStateDTO;
using MediumWriteStoreApi.DTO.LinkDTO;
using MediumWriteStoreApi.DTO.WebSocetDTO;
using MediumWriteStoreApi.Service.AzureService;
using MediumWriteStoreApi.Service.ContentState;
using MediumWriteStoreApi.Service.LinkService;
using MediumWriteStoreApi.Service.RedisConnectionService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
namespace MediumWriteStoreApi.Service.WebSocetServise
{
    public class WebSocketMessageHandler
    {
        private readonly IRedisConnection _redisConnection;
        private readonly IContentStateService _contentStateService;

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public WebSocketMessageHandler(IServiceScopeFactory serviceScopeFactory, IRedisConnection redisConnection, IContentStateService contentStateService)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _redisConnection = redisConnection;
            _contentStateService = contentStateService;
        }

        public async Task HandleWebSocketAsync(WebSocket webSocket, SessionData sessionData)
        {
            var buffer = new byte[4096];
            MemoryStream data = new MemoryStream();
            DateTime lastExecutionTime = DateTime.Now;


            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                data.Write(buffer, 0, result.Count);

                if (result.EndOfMessage)
                {
                    await ProcessReceivedData(data, webSocket, result, sessionData);
                    data.SetLength(0);
                }

                if ((DateTime.Now - lastExecutionTime).TotalSeconds >= 10) 
                {
                    lastExecutionTime = DateTime.Now;

                }

            }

        }

        public async Task ProcessReceivedData(MemoryStream data, WebSocket webSocket, WebSocketReceiveResult result, SessionData sessionData)
        {



            byte[] Response = data.ToArray();

            if (result.MessageType == WebSocketMessageType.Text)
            {
                WebSocketMessageDTO message = JsonSerializer.Deserialize<WebSocketMessageDTO>(Encoding.UTF8.GetString(Response, 0, result.Count))!;
                byte[] responseBytes;
                WebSocketMessageDTO responseMessage = new WebSocketMessageDTO();
                if (sessionData.isConneced)
                {
                    switch (message.Type)
                    {
                        case "UpdateContentState":
                            try
                            {
                                var options = new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                };
                                ContentStateDTO state = JsonSerializer.Deserialize<ContentStateDTO>(message.Message, options);
                                if (!sessionData.ContentState.ContentState.Equals(state))
                                {
                                    sessionData.ContentState.ContentState = state;
                                    sessionData.ContentState.isChangedAfterSave = true;
                                    sessionData.ContentState.isSaved = false;

                                }


                            }
                            catch (JsonException ex)
                            {
                                Console.WriteLine("Ошибка при десериализации JSON: " + ex.Message);
                                Console.WriteLine("JSON: " + message.Message);
                            }
                            if (!sessionData.ContentState.isChangedAfterSave)
                            {
                                if (sessionData.ContentState.ContentState == null)
                                {
                                    throw new Exception("BadContentState");
                                }
                                else if (!sessionData.ContentState.isSaved && sessionData.ContentState.isChangedAfterSave)
                                {
                                    //send to server
                                }
                                else if (sessionData.ContentState.isSaved && !sessionData.ContentState.isChangedAfterSave)
                                { }
                            }
                            break;
                    }
                }
                else 
                {
                    switch (message.Type)
                    {
                        case "CreateWriteStory":
                            var Reply = Encoding.UTF8.GetBytes(JsonSerializer.Serialize( new WebSocketMessageDTO { Type = "SetStoryIdForNewStory", Message = sessionData.ContentState.ContentState.id }));

                            await webSocket.SendAsync(new ArraySegment<byte>(Reply),WebSocketMessageType.Text, true, CancellationToken.None);
                            break;
                        case "AcceptNewIdFprWriteStory":
                            sessionData.isConneced = true;
                            break;
                        case "ReconectWebSoketWithId":
                            await _contentStateService.SetContentById(webSocket, message.Message);
                            break;
                    }
                }

            }
            else if (result.MessageType == WebSocketMessageType.Binary)
            {
                
            }
            else { }


        }
    }
}
