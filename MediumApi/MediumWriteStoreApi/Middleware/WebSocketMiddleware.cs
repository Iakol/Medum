using MediumWriteStoreApi.DTO.WebSocetDTO;
using MediumWriteStoreApi.Service.WebSocetServise;
using MediumWriteStoreApi.Service.WebSocketDictionaryService;
using Microsoft.AspNetCore.Http;
using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace MediumWriteStoreApi.Middleware
{
    public class WebSocketMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebSocketMessageHandler _messageHandler;
        private readonly IWebSocketDictionaryService _dictonary;

        public WebSocketMiddleware(RequestDelegate next, WebSocketMessageHandler messageHandler, IWebSocketDictionaryService dictonary)
        {
            _next = next;
            _messageHandler = messageHandler;
            _dictonary = dictonary;
        }

        public async Task InvokeAsync(HttpContext _context) 
        {
            try 
            {
                if (_context.WebSockets.IsWebSocketRequest)
                {
                    if (_context.Request.Path == "/ws")

                    {

                        var webSocet = await _context.WebSockets.AcceptWebSocketAsync();
                        _dictonary.SetSessionDataByWebSoket(webSocet);
                        await _messageHandler.HandleWebSocketAsync(webSocet, _dictonary.GetSessionDataByWebSoket(webSocet));

                        //Add logic what cheak close web soket and delete from _sesion


                        _dictonary.Disconect(webSocet);

                    }
                    else
                    {
                        _context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    }

                }
                else 
                {
                   await _next(_context);

                }


            }
            catch (Exception e) 
            {
                throw;
            }

        }
    }
}
