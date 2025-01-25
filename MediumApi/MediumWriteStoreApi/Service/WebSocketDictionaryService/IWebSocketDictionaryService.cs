using MediumWriteStoreApi.DTO.ContentStateDTO;
using MediumWriteStoreApi.DTO.WebSocetDTO;
using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace MediumWriteStoreApi.Service.WebSocketDictionaryService
{
    public interface IWebSocketDictionaryService
    {
        private static readonly ConcurrentDictionary<WebSocket, SessionData> _sessions;

        public SessionData GetSessionDataByID(string id);
        public SessionData SetContentStateByID(string id);
        public void SetSessionDataByWebSoket(WebSocket soket);
        public SessionData GetSessionDataByWebSoket(WebSocket soket);
        public void TryRemoveSessionDataByWebSoketUnNormalClose(WebSocket soket);
        public void TryRemoveSessionDataByWebSoketNormalClose(WebSocket soket);

        public void Disconect(WebSocket soket);

        public Task ReconectBindingWithContentStateAndSessionData(WebSocket soket, ContentStateDTO content);






    }
}
