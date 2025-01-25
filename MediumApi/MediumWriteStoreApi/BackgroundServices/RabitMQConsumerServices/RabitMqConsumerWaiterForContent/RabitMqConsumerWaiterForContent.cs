
using MediumWriteStoreApi.Service.WebSocketListDictonaryForWaitingContext;

namespace MediumWriteStoreApi.BackgroundServices.RabitMQConsumerServices.RabitMqConsumerWaiterForContent
{
    public class RabitMqConsumerWaiterForContent : IHostedService
    {
        private readonly IWebSocketListDictonaryForWaitingContext _WaitForContextList;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
