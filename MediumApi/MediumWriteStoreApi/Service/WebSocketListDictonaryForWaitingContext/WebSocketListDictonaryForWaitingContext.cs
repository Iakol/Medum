using MediumWriteStoreApi.DTO.WebSocetDTO;
using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace MediumWriteStoreApi.Service.WebSocketListDictonaryForWaitingContext
{
    public class WebSocketListDictonaryForWaitingContext : IWebSocketListDictonaryForWaitingContext
    {
        private static readonly ConcurrentDictionary<string, WebSocket> _WaitingForBindingSession = new();

        public void addToWaitList(string Key, WebSocket soket)
        {
            _WaitingForBindingSession[Key] = soket;
        }

        public void RemoveFromWaitList(string Key)
        {
            _WaitingForBindingSession.TryRemove(Key, out _);
        }
    }
}
