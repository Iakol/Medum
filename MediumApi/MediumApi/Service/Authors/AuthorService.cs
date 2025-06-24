
using MediumApi.DTO.AuthorDTO;
using MediumApi.RabbitMQCover;
using MediumApi.Service.ConccurentDictonryForReplyTask;
using RabbitMQ.Client;
using System.Text.Json;

namespace MediumApi.Service.Authors
{
    public class AuthorService(RabitMqGlobalDataClass _rabbitClient) : IAuthorService
    {

        public async Task<string> BlockAuthorByAuthorId(string authorId, string userId)
        {
            string result = await _rabbitClient.DataBaseCommonRequest<string>(JsonSerializer.Serialize(new {  authorId, userId }), QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.BlockAuthor);

            if (result.Equals("OK") || result.Equals("AlreadyBlocked")) 
            {
                return "OK";
            }
            return result;
        }

        public async Task<string> FollowAuthorByAuthorId(string authorId, string userId)
        {
            string result = await _rabbitClient.DataBaseCommonRequest<string>(JsonSerializer.Serialize(new { authorId, userId }), QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.FollowAuthor);

            if (result.Equals("OK") || result.Equals("AlreadyFollowed"))
            {
                return "OK";
            }

            return result;
        }

        public async Task<List<string>> GetAuthorFollowingAuthors(string authorId)
        {
            return await _rabbitClient.DataBaseCommonRequest<List<string>>( authorId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetAuthorFollowingAuthors);            
        }

        public async Task<List<int>> GetReadingIdsListByAuthor(string authorId)
        {
            return await _rabbitClient.DataBaseCommonRequest<List<int>>(authorId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetReadingListsByAuthor);

        }

        public async Task<List<string>> GetRecomendationAuthorForUser(string userId)
        {
            return await _rabbitClient.DataBaseCommonRequest<List<string>>(userId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetRecomendationAuthorForUser);

        }

        public async Task<List<string>> GetStoryIdsListByAuthor(string authorId)
        {
            return await _rabbitClient.DataBaseCommonRequest<List<string>>(authorId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetStoryListByAuthor);

        }

        public async Task<string> MuteAuthorByAuthorId(string authorId, string userId)
        {
            string result = await _rabbitClient.DataBaseCommonRequest<string>(JsonSerializer.Serialize(new { authorId,userId }), QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.MuteAuthor);

            if (result.Equals("OK") || result.Equals("AlreadyMuted"))
            {
                return "OK";
            }

            return result;
        }

        public async Task<string> UnMuteAuthorByAuthorId(string authorId, string userId)
        {
            string result = await _rabbitClient.DataBaseCommonRequest<string>(JsonSerializer.Serialize(new { authorId, userId }), QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.MuteAuthor);

            if (result.Equals("OK"))
            {
                return "OK";
            }

            return result;
        }

        public async Task<string> UnBlockAuthorByAuthorId(string authorId, string userId)
        {
            string result = await _rabbitClient.DataBaseCommonRequest<string>(JsonSerializer.Serialize(new { authorId, userId }), QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.UnBlockAuthor);

            if (result.Equals("OK"))
            {
                return "OK";
            }

            return result;
        }

        public async Task<string> UnFollowAuthorByAuthorId(string authorId, string userId)
        {
            string result = await _rabbitClient.DataBaseCommonRequest<string>(JsonSerializer.Serialize(new { authorId, userId }), QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.UnFollowAuthor);
            if (result.Equals("OK"))
            {
                return "OK";
            }

            return result;
        }


        public async Task<AuthorHeaderDTO> GetUserHeaderStoryId(string storyId)
        {            
            return await _rabbitClient.DataBaseCommonRequest< AuthorHeaderDTO>(storyId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetUserHeaderStory);
        }

        public async Task<AuthorHeaderDTO> GetUserHeader(string authorId)
        {
            return await _rabbitClient.DataBaseCommonRequest<AuthorHeaderDTO>(authorId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetUserHeader);
        }
        public async Task<AuthorCredDTO> GetUserCred(string authorId)
        {
            return await _rabbitClient.DataBaseCommonRequest<AuthorCredDTO>(authorId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.UserCred);

        }

        
        public async Task<List<string>> GetMuteAuthorList(string userId)
        {
            return await _rabbitClient.DataBaseCommonRequest<List<string>>(userId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetMuteAuthorList);
        }

        public async Task<List<string>> GetBlockAuthorList(string userId)
        {
            return await _rabbitClient.DataBaseCommonRequest<List<string>>(userId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetBlockAuthorList);

        }

    }
}
