using MediumWriteStoreApi.DTO.ContentStateDTO;
using MediumWriteStoreApi.Service.RabitMQProducerService;
using MediumWriteStoreApi.Service.RedisConnectionService;
using MediumWriteStoreApi.Service.RedisContexTimerListService;
using MediumWriteStoreApi.Service.WebSocketDictionaryService;
using System.Net.WebSockets;

namespace MediumWriteStoreApi.Service.ContentState
{
    public class ContentStateService : IContentStateService
    {
        private readonly IRedisConnection _redisConnection;
        private readonly IRabitMQProducer _producer;
        private readonly IWebSocketDictionaryService _websocketDictionaryService;
        private readonly RedisContexTimerList _redisContexTimerList;

        public ContentStateDTO SetChanges(ContentStateDTO content)
        {
            throw new NotImplementedException();
        }

        public async Task SetContentById(WebSocket socet,string id)
        {
            ContentStateDTO? content;
            if (_redisContexTimerList.List.FirstOrDefault(t => t.getContextId == id) != null)
            {
                content = await _redisConnection.GetContentAfterReconect(id);
                if (content == null) 
                {
                    content = await _producer.GetContentStateFromBdOverRabit(id);
                }
                await _websocketDictionaryService.ReconectBindingWithContentStateAndSessionData(socet, content);
            }
            else {
                content = await _producer.GetContentStateFromBdOverRabit(id);
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
