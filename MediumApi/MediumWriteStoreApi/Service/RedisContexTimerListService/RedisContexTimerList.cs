using MediumWriteStoreApi.DTO.ContentStateDTO;
using MediumWriteStoreApi.Service.RabitMQProducerService;
using MediumWriteStoreApi.Service.RedisConnectionService;
using System.Text.Json;

namespace MediumWriteStoreApi.Service.RedisContexTimerListService
{
    public class RedisContexTimerList
    {
        private static List<TimerWrapper> _timerList = new List<TimerWrapper>();
        private readonly IRabitMQProducer _producer;
        private readonly IRedisConnection _redisConnection;

        public RedisContexTimerList()
        {
        }

        public void AddTimer(string ContextStateId)
        {
            Action act = () => SaveContextAfterExpiredTime(ContextStateId);
            TimerWrapper newTimer = new TimerWrapper(ContextStateId, act, DateTime.Now.AddMinutes(1));
            _timerList.Add(newTimer);
        }

        public void SaveContextAfterExpiredTime(string ContextStateId)
        {
            ContentStateDTO contentStateDTO = _redisConnection.getContent(ContextStateId);
            _producer.sendMessage("saveConext", JsonSerializer.Serialize(contentStateDTO));
        }

        public void CancelTimerByContextId(string ContextStateId) 
        {
            _timerList.FirstOrDefault(t => t.GetContextStateId.Equals(ContextStateId)).CancelTimer();
        }



    }
}
