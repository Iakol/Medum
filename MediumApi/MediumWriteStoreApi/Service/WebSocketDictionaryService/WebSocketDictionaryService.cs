using MediumWriteStoreApi.DTO;
using MediumWriteStoreApi.DTO.ContentStateDTO;
using MediumWriteStoreApi.DTO.WebSocetDTO;
using MediumWriteStoreApi.Service.RabitMQProducerService;
using MediumWriteStoreApi.Service.RedisConnectionService;
using MediumWriteStoreApi.Service.RedisContexTimerListService;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace MediumWriteStoreApi.Service.WebSocketDictionaryService
{
    public class WebSocketDictionaryService : IWebSocketDictionaryService
    {
        private static readonly ConcurrentDictionary<WebSocket, SessionData> _sessions = new();
        private readonly IRedisConnection _redisConnection;
        private readonly IRabitMQProducer _producer;



        public SessionData GetSessionDataByID(string id)
        {
            throw new NotImplementedException();
        }

        public SessionData SetContentStateByID(string id)
        {
            throw new NotImplementedException();
        }

        public void SetSessionDataByWebSoket(WebSocket soket)
        {
            _sessions[soket] = new SessionData();
            
        }
        public SessionData GetSessionDataByWebSoket(WebSocket soket)
        {
            return _sessions[soket];
        }

        public void TryRemoveSessionDataByWebSoketUnNormalClose(WebSocket soket)
        {
            _redisConnection.AddContentAfterWebSoketDisconect(GetSessionDataByWebSoket(soket));
            _sessions.TryRemove(soket, out _);
        }

        public void TryRemoveSessionDataByWebSoketNormalClose(WebSocket soket)
        {
            _producer.sendMessage("saveConext", JsonSerializer.Serialize(GetSessionDataByWebSoket(soket).ContentState.ContentState));
            _sessions.TryRemove(soket, out _);
        }

        public void Disconect(WebSocket soket)
        {
            if (soket.CloseStatus != WebSocketCloseStatus.NormalClosure)
            {
                TryRemoveSessionDataByWebSoketUnNormalClose(soket);
            }
            else {
                TryRemoveSessionDataByWebSoketNormalClose(soket);
            }
        }

        public async Task ReconectBindingWithContentStateAndSessionData(WebSocket soket, ContentStateDTO content)
        {

            SessionData data = _sessions[soket];
            data.ContentState.ContentState = content;
            TempMessageDTO reply = new TempMessageDTO
            {
                Type ="ReconectAfterDisconect",
                Message = ""
            };
            byte[] response = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(reply));
            await soket.SendAsync(new ArraySegment<byte>(response),WebSocketMessageType.Text,true,CancellationToken.None);

        }
    }
}
