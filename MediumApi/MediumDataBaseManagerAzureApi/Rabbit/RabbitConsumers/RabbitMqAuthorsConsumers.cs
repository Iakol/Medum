using MediumDataBaseManagerAzureApi.Rabbit.RabbitService;
using MediumDataBaseManagerAzureApi.Service.Author;
using MediumDataBaseManagerAzureApi.Service.Author.ParamsDTO;

namespace MediumDataBaseManagerAzureApi.Rabbit.RabbitConsumers
{
    public class RabbitMqAuthorsConsumers(RabitMqGlobalDataClass _rabbitService, IAuthorService _authorService)
    {
        public async Task CreateAuthorServiceRabbitConsumers()
        {
            await GetAuthorFollowingAuthorsConsumer();
            await GetRecomendationAuthorForUserConsumer();
            await MuteAuthorByAuthorIdConsumer();
            await BlockAuthorByAuthorIdConsumer();
            await FollowAuthorByAuthorIdConsumer();
            await UnMuteAuthorByAuthorIdConsumer();
            await UnBlockAuthorByAuthorIdConsumer();
            await UnFollowAuthorByAuthorIdConsumer();
            await GetMuteAuthorListConsumer();
            await GetBlockAuthorListConsumer();
            await GetStoryIdsListByAuthorConsumer();
            await GetReadingIdsListByAuthorConsumer();
            await GetUserHeaderStoryIdConsumer();
            await GetUserHeaderConsumer();
            await GetUserCredConsumer();


        }

        public async Task GetAuthorFollowingAuthorsConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<string, List<string>>(QueueConstantForRabbitComunication.GetAuthorFollowingAuthors, _authorService.GetAuthorFollowingAuthors, QueueConstantForRabbitComunication.RequestDBExechange);
        }

        public async Task GetRecomendationAuthorForUserConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<string, List<string>>(QueueConstantForRabbitComunication.GetRecomendationAuthorForUser, _authorService.GetRecomendationAuthorForUser, QueueConstantForRabbitComunication.RequestDBExechange);
        }

        public async Task MuteAuthorByAuthorIdConsumer() 
        {
            await _rabbitService.CreateConsumerForChanelToQueue<AuthorToUserDTO, string>(QueueConstantForRabbitComunication.MuteAuthor, _authorService.MuteAuthorByAuthorId, QueueConstantForRabbitComunication.RequestDBExechange);
        }
        public async Task BlockAuthorByAuthorIdConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<AuthorToUserDTO, string>(QueueConstantForRabbitComunication.BlockAuthor, _authorService.BlockAuthorByAuthorId, QueueConstantForRabbitComunication.RequestDBExechange);

        }
        public async Task FollowAuthorByAuthorIdConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<AuthorToUserDTO, string>(QueueConstantForRabbitComunication.FollowAuthor, _authorService.FollowAuthorByAuthorId, QueueConstantForRabbitComunication.RequestDBExechange);

        }

        public async Task UnMuteAuthorByAuthorIdConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<AuthorToUserDTO, string>(QueueConstantForRabbitComunication.UnMuteAuthor, _authorService.UnMuteAuthorByAuthorId, QueueConstantForRabbitComunication.RequestDBExechange);
        }
        public async Task UnBlockAuthorByAuthorIdConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<AuthorToUserDTO, string>(QueueConstantForRabbitComunication.UnBlockAuthor, _authorService.UnBlockAuthorByAuthorId, QueueConstantForRabbitComunication.RequestDBExechange);

        }

        public async Task UnFollowAuthorByAuthorIdConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<AuthorToUserDTO, string>(QueueConstantForRabbitComunication.UnFollowAuthor, _authorService.UnFollowAuthorByAuthorId, QueueConstantForRabbitComunication.RequestDBExechange);

        }

        public async Task GetMuteAuthorListConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<string, List<string>>(QueueConstantForRabbitComunication.GetMuteAuthorList, _authorService.GetMuteAuthorList, QueueConstantForRabbitComunication.RequestDBExechange);

        }
        public async Task GetBlockAuthorListConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<string, List<string>>(QueueConstantForRabbitComunication.GetBlockAuthorList, _authorService.GetBlockAuthorList, QueueConstantForRabbitComunication.RequestDBExechange);

        }
        public async Task GetStoryIdsListByAuthorConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<string, List<string>>(QueueConstantForRabbitComunication.GetStoryListByAuthor, _authorService.GetStoryIdsListByAuthor, QueueConstantForRabbitComunication.RequestDBExechange);

        }
        public async Task GetReadingIdsListByAuthorConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<string, List<string>>(QueueConstantForRabbitComunication.GetReadingListsByAuthor, _authorService.GetReadingIdsListByAuthor, QueueConstantForRabbitComunication.RequestDBExechange);

        }
        public async Task GetUserHeaderStoryIdConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<string, string>(QueueConstantForRabbitComunication.GetUserHeaderStory, _authorService.GetUserHeaderStoryId, QueueConstantForRabbitComunication.RequestDBExechange);

        }
        public async Task GetUserHeaderConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<string, string>(QueueConstantForRabbitComunication.GetUserHeader, _authorService.GetUserHeader, QueueConstantForRabbitComunication.RequestDBExechange);

        }
        public async Task GetUserCredConsumer()
        {
            await _rabbitService.CreateConsumerForChanelToQueue<string, string>(QueueConstantForRabbitComunication.GetUserCred, _authorService.GetUserCred, QueueConstantForRabbitComunication.RequestDBExechange);

        }
    }
}
