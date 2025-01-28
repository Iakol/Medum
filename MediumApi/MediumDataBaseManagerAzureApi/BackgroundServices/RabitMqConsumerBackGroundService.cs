
using MediumDataBaseManagerAzureApi.Service.RebitMqConsumer;

namespace MediumDataBaseManagerAzureApi.BackgroundServices
{
    public class RabitMqConsumerBackGroundService : BackgroundService
    {
        private readonly IRebitMqGetContentStateConsumerService _consumer;

        public RabitMqConsumerBackGroundService(IRebitMqGetContentStateConsumerService rabitMqconsumer) 
        {
            _consumer = rabitMqconsumer;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.StartHeandleMessage();
            return Task.CompletedTask;
        }
    }
}
