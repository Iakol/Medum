

namespace MediumApi.RabbitMQCover
{
    public class RabitMqConsumerBackGroundService(RabitMqGlobalDataClass _rabitManager) : BackgroundService
    {


        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _rabitManager.CreateConsumerForChanelToQueue(await _rabitManager.GetRetriveChannelChannelToRabit(), QueueConstantForRabbitComunication.StoryCredQueue + QueueConstantForRabbitComunication.ServiceRabitID);
            await _rabitManager.CreateConsumerForChanelToQueue(await _rabitManager.GetRetriveChannelChannelToRabit(), QueueConstantForRabbitComunication.UpdateClapsAndResponseQueue + QueueConstantForRabbitComunication.ServiceRabitID);

        }
    }
}
