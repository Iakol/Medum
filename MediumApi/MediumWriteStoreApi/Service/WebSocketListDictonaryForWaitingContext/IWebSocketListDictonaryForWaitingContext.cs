using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace MediumWriteStoreApi.Service.WebSocketListDictonaryForWaitingContext
{
    public interface IWebSocketListDictonaryForWaitingContext
    {
        private static readonly ConcurrentDictionary<string, WebSocket> _WaitingForBindingSession = new();

        public void addToWaitList(string Key, WebSocket soket);
        public void RemoveFromWaitList(string Key);

    }
}
