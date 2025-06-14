

namespace MediumApi.RabbitMQCover
{
    public class RabitMqConsumerBackGroundService(RabitMqGlobalDataClass _rabitManager) : BackgroundService
    {


        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _rabitManager.CreateConsumerForChanelToQueue(await _rabitManager.GetRetriveChannelChannelToRabit(), QueueConstantForRabbitComunication.StoryCredQueue);
            await _rabitManager.CreateConsumerForChanelToQueue(await _rabitManager.GetRetriveChannelChannelToRabit(), QueueConstantForRabbitComunication.UpdateClapsAndResponseQueue);

        }
    }
}
