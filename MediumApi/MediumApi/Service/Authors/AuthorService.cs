
using MediumApi.DTO.AuthorDTO;
using MediumApi.RabbitMQCover;
using MediumApi.Service.ConccurentDictonryForReplyTask;
using RabbitMQ.Client;
using System.Text.Json;

namespace MediumApi.Service.Authors
{
    public class AuthorService(RabitMqGlobalDataClass _rabbitClient) : IAuthorService
    {

        public async Task BlockAuthorByAuthorId(string authorId, string userId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize(new { author = authorId, user = userId }), QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.BlockAuthor);
        
            JsonElement JsonResult = JsonSerializer.Deserialize<JsonElement>(json);
            if (!JsonResult.GetProperty("Status").Equals("OK")) 
            {
                await BlockAuthorByAuthorId(authorId, userId);
            }
        }

        public async Task FollowAuthorByAuthorId(string authorId, string userId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize(new { author = authorId, user = userId }), QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.FollowAuthor);

            JsonElement JsonResult = JsonSerializer.Deserialize<JsonElement>(json);
            if (!JsonResult.GetProperty("Status").Equals("OK"))
            {
                await FollowAuthorByAuthorId(authorId, userId);
            }
        }

        public async Task<List<string>> GetAuthorFollowingAuthors(string authorId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest( authorId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetAuthorFollowingAuthors);

            return JsonSerializer.Deserialize<List<string>>(json);
            
        }

        public async Task<List<int>> GetReadingIdsListByAuthor(string authorId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(authorId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetReadingListsByAuthor);

            return JsonSerializer.Deserialize<List<int>>(json);
        }

        public async Task<List<string>> GetRecomendationAuthorForUser(string userId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(userId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetRecomendationAuthorForUser);

            return JsonSerializer.Deserialize<List<string>>(json);
        }

        public async Task<List<string>> GetStoryIdsListByAuthor(string authorId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(authorId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetStoryListByAuthor);

            return JsonSerializer.Deserialize<List<string>>(json);
        }

        public async Task MuteAuthorByAuthorId(string authorId, string userId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize(new { author = authorId, user = userId }), QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.MuteAuthor);

            JsonElement JsonResult = JsonSerializer.Deserialize<JsonElement>(json);
            if (!JsonResult.GetProperty("Status").Equals("OK"))
            {
                await MuteAuthorByAuthorId(authorId, userId);
            }
        }

        public async Task UnMuteAuthorByAuthorId(string authorId, string userId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize(new { author = authorId, user = userId }), QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.MuteAuthor);

            JsonElement JsonResult = JsonSerializer.Deserialize<JsonElement>(json);
            if (!JsonResult.GetProperty("Status").Equals("OK"))
            {
                await UnMuteAuthorByAuthorId(authorId, userId);
            }
        }

        public async Task UnBlockAuthorByAuthorId(string authorId, string userId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize(new { author = authorId, user = userId }), QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.UnBlockAuthor);

            JsonElement JsonResult = JsonSerializer.Deserialize<JsonElement>(json);
            if (!JsonResult.GetProperty("Status").Equals("OK"))
            {
                await UnBlockAuthorByAuthorId(authorId, userId);
            }
        }

        public async Task UnFollowAuthorByAuthorId(string authorId, string userId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize(new { author = authorId, user = userId }), QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.UnFollowAuthor);
            JsonElement JsonResult = JsonSerializer.Deserialize<JsonElement>(json);
            if (!JsonResult.GetProperty("Status").Equals("OK"))
            {
                await UnFollowAuthorByAuthorId(authorId, userId);
            }
        }


        public async Task<AuthorHeaderDTO> GetUserHeaderStoryId(string storyId)
        {            
            string json = await _rabbitClient.DataBaseCommonRequest(storyId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetUserHeaderStory);

            AuthorHeaderDTO User = JsonSerializer.Deserialize<AuthorHeaderDTO>(json);

            return User;
        }

        public async Task<AuthorHeaderDTO> GetUserHeader(string authorId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(authorId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetUserHeader);

            AuthorHeaderDTO User = JsonSerializer.Deserialize<AuthorHeaderDTO>(json);

            return User;
        }
        public async Task<AuthorCredDTO> GetUserCred(string authorId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(authorId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.UserCred);

            AuthorCredDTO User = JsonSerializer.Deserialize<AuthorCredDTO>(json);

            return User;
        }

        
        public async Task<List<string>> GetMuteAuthorList(string userId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(userId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetMuteAuthorList);

            return JsonSerializer.Deserialize<List<string>>(json);
        }

        public async Task<List<string>> GetBlockAuthorList(string userId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(userId, QueueConstantForRabbitComunication.AuthorCredQueue, QueueConstantForRabbitComunication.GetBlockAuthorList);

            return JsonSerializer.Deserialize<List<string>>(json);
        }

    }
}
