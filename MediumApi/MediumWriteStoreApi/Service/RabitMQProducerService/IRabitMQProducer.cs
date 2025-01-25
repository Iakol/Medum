namespace MediumWriteStoreApi.Service.RabitMQProducerService
{
    public interface IRabitMQProducer
    {
        public void sendMessage(string Type,string Data);
    }
}
