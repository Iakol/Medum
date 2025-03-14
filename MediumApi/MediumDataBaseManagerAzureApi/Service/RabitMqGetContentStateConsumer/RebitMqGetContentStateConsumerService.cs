
using MediumDataBaseManagerAzureApi.Service.RabitMqGlobalData;
using RabbitMQ.Client;

namespace MediumDataBaseManagerAzureApi.Service.RebitMqConsumer
{
    public class RebitMqGetContentStateConsumerService : IRebitMqGetContentStateConsumerService
    {
        private RabitMqGlobalDataClass _rabitWrapper;        
        private string retriveQueue = "ContentStateRequestQueue";

        public RebitMqGetContentStateConsumerService(RabitMqGlobalDataClass rabitWrapper) 
        {
            _rabitWrapper = rabitWrapper;
        }

        public async Task StartHeandleMessage()
        {
            await _rabitWrapper.CreateConsumerForChanelToQueue(await _rabitWrapper.GetRetriveChannelChannelToRabit(), retriveQueue);
        }
    }
}
