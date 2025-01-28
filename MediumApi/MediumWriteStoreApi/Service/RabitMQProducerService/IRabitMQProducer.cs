using MediumWriteStoreApi.DTO;
using MediumWriteStoreApi.DTO.ContentStateDTO;

namespace MediumWriteStoreApi.Service.RabitMQProducerService
{
    public interface IRabitMQProducer : IDisposable
    {
        public void sendMessage(string Type,string Data);
        public Task<string> sendMessage(string requestQueue, string responseQueue, TempMessageDTO message);
        public Task<ContentStateDTO> GetContentStateFromBdOverRabit(string ContentId);


    }
}
