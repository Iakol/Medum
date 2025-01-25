using MediumWriteStoreApi.DTO.ContentStateDTO;
using MediumWriteStoreApi.Service.RabitMQProducerService;
using MediumWriteStoreApi.Service.RedisConnectionService;
using MediumWriteStoreApi.Service.WebSocketDictionaryService;
using System.Net.WebSockets;

namespace MediumWriteStoreApi.Service.ContentState
{
    public class ContentStateService : IContentStateService
    {
        private readonly IRedisConnection _redisConnection;
        private readonly IRabitMQProducer _producer;
        private readonly IWebSocketDictionaryService _websocketDictionaryService;

        public ContentStateDTO SetChanges(ContentStateDTO content)
        {
            throw new NotImplementedException();
        }

        public async Task SetContentById(WebSocket socet,string id)
        {
            ContentStateDTO? content;
            content = await _redisConnection.GetContentAfterReconect(id);
            if (content != null)
            {
                await _websocketDictionaryService.ReconectBindingWithContentStateAndSessionData(socet, content);

            }
            else {
                content = new ContentStateDTO(); // Imitation ask from BD
                await _websocketDictionaryService.ReconectBindingWithContentStateAndSessionData(socet, content);                           
            }


        }

        public void DeleteContent(string id)
        {
            throw new NotImplementedException();
        }

        public ContentStateDTO SetContentById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
