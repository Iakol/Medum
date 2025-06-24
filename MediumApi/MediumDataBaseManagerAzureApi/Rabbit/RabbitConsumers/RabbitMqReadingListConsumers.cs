using MediumDataBaseManagerAzureApi.Rabbit.RabbitService;
using MediumDataBaseManagerAzureApi.Service.ReadingList;
using MediumDataBaseManagerAzureApi.Service.ReadingList.ParamsDTO;

namespace MediumDataBaseManagerAzureApi.Rabbit.RabbitConsumers
{
    public class RabbitMqReadingListConsumers(RabitMqGlobalDataClass _rabbitService, IReadingListService _readingList)
    {
        public async Task CreateReadingListRabbitConsumers()
        {
            await AddStoryToReadingListByUserConsumer();
            await DeleteReadingListConsumer();
            await DeleteStoryFromReadingListConsumer();
            await CreateReadingListByUserConsumer();
            await UpdateReadingListByUserConsumer();
            await GetUserReadingListsConsumer();
            await GetUserSavedReadingListsConsumer();
            await GetAuthorRedingListConsumer();
            await UpdateNoteToStoryInReadingListConsumer();
            GetReadingListByIdConsumer();

        }

        public async Task AddStoryToReadingListByUserConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<UserStoryReadingListParamDTO, string>(QueueConstantForRabbitComunication.AddStoryToReadingListByUser, _readingList.AddStoryToReadingListByUser, QueueConstantForRabbitComunication.RequestDBExechange);
        }
        public async Task DeleteReadingListConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<UserStoryReadingListParamDTO , string>(QueueConstantForRabbitComunication.DeleteReadingList, _readingList.DeleteReadingList, QueueConstantForRabbitComunication.RequestDBExechange);
        }
        public async Task DeleteStoryFromReadingListConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue(QueueConstantForRabbitComunication.DeleteStoryFromReadingList, _readingList.DeleteStoryFromReadingList, QueueConstantForRabbitComunication.RequestDBExechange);
        }

        public async Task CreateReadingListByUserConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue(QueueConstantForRabbitComunication.CreateReadingListByUser, _readingList.CreateReadingListByUser, QueueConstantForRabbitComunication.RequestDBExechange);
        }

        public async Task UpdateReadingListByUserConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue(QueueConstantForRabbitComunication.UpdateReadingListByUser, _readingList.UpdateReadingListByUser, QueueConstantForRabbitComunication.RequestDBExechange);
        }
        public async Task GetUserReadingListsConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue(QueueConstantForRabbitComunication.GetUserReadingLists, _readingList.GetUserReadingLists, QueueConstantForRabbitComunication.RequestDBExechange);
        }

        public async Task GetUserSavedReadingListsConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue(QueueConstantForRabbitComunication.GetUserSavedReadingLists, _readingList.GetUserSavedReadingLists, QueueConstantForRabbitComunication.RequestDBExechange);
        }
        public async Task GetAuthorRedingListConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue(QueueConstantForRabbitComunication.GetAuthorRedingList, _readingList.GetAuthorRedingList, QueueConstantForRabbitComunication.RequestDBExechange);
        }

        public async Task UpdateNoteToStoryInReadingListConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue(QueueConstantForRabbitComunication.UpdateNoteToStoryInReadingList, _readingList.UpdateNoteToStoryInReadingList, QueueConstantForRabbitComunication.RequestDBExechange);
        }

        public async Task GetReadingListByIdConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue(QueueConstantForRabbitComunication.GetReadingListById, _readingList.GetReadingListById, QueueConstantForRabbitComunication.RequestDBExechange);
        }


    }
}
