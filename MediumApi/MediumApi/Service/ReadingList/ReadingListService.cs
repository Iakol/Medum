using MediumApi.DTO.ReadingListDTO;
using MediumApi.RabbitMQCover;
using System.Text.Json;

namespace MediumApi.Service.ReadingList
{
    public class ReadingListService(RabitMqGlobalDataClass _rabbitClient) : IReadingListService
    {
        public async Task<bool> AddStoryToReadingListByUser(string userId, string storyId, string readingListId)
        {
            string Message = JsonSerializer.Serialize(new { user = userId, story = storyId, readingList = readingListId });
            string json = await _rabbitClient.DataBaseCommonRequest(Message, QueueConstantForRabbitComunication.ReadingListQueue, QueueConstantForRabbitComunication.AddStoryToReadingListByUser)
            JsonElement result = JsonSerializer.Deserialize<JsonElement>(Message);

            if (!result.GetProperty("Status").Equals("Ok"))
            {
                await AddStoryToReadingListByUser(userId, storyId, readingListId);
            }
            else 
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreateReadingListByUser(string userId, CreateReadingListDTO readingListToCreate)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize(readingListToCreate), QueueConstantForRabbitComunication.ReadingListQueue, QueueConstantForRabbitComunication.CreateReadingListByUser);
            JsonElement result = JsonSerializer.Deserialize<JsonElement>(json);
            if (!result.GetProperty("Status").Equals("Ok"))
            {
               await CreateReadingListByUser(userId, readingListToCreate);
            }
            return true;
        }

        public async Task<bool> DeleteReadingList(string readingListId, string UserId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(readingListId, QueueConstantForRabbitComunication.ReadingListQueue, QueueConstantForRabbitComunication.DeleteReadingList);
            JsonElement result = JsonSerializer.Deserialize<JsonElement>(json);
            if (result.GetProperty("Status").Equals("Bad User"))
            {
                return false;
            }
            else if (!result.GetProperty("Status").Equals("OK")) 
            {
                await DeleteReadingList(readingListId, UserId);
            }
            return true;
        }

        public async Task<bool> DeleteStoryFromReadingList(string storyId, string readingListId,string UserId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize(new { story = storyId, readingList = readingListId , User = UserId }), QueueConstantForRabbitComunication.ReadingListQueue, QueueConstantForRabbitComunication.DeleteStoryFromReadingList);
            JsonElement result = JsonSerializer.Deserialize<JsonElement>(json);
            if (result.GetProperty("Status").Equals("Bad User"))
            {
                return false;
            }
            else if (!result.GetProperty("Status").Equals("OK"))
            {
                await DeleteReadingList(readingListId, UserId);
            }
            return true;
        }

        public async Task<List<string>> GetAuthorRedingList(string authorId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(authorId, QueueConstantForRabbitComunication.ReadingListQueue, QueueConstantForRabbitComunication.GetAuthorRedingList);

            return JsonSerializer.Deserialize<List<string>>(json);

        }

        public async Task<List<string>> GetUserReadingLists(string userId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(userId, QueueConstantForRabbitComunication.ReadingListQueue, QueueConstantForRabbitComunication.GetUserReadingLists);

            return JsonSerializer.Deserialize<List<string>>(json);
        }

        public async Task<List<string>> GetUserSavedReadingLists(string userId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(userId, QueueConstantForRabbitComunication.ReadingListQueue, QueueConstantForRabbitComunication.GetUserSavedReadingLists);

            return JsonSerializer.Deserialize<List<string>>(json);
        }

        public async Task<bool> UpdateNoteToStoryInReadingList(string storyid, string readingListId, string TextOfNote, string UserId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize(new { story = storyid , readingList = readingListId , TextOfNote, User = UserId }), QueueConstantForRabbitComunication.ReadingListQueue, QueueConstantForRabbitComunication.UpdateNoteToStoryInReadingList);
            JsonElement result = JsonSerializer.Deserialize<JsonElement>(json);
            if (result.GetProperty("Status").Equals("Bad User")) 
            {
                return false;
            }
            else if (!result.GetProperty("Status").Equals("Ok"))
            {
                await UpdateNoteToStoryInReadingList(storyid, readingListId, TextOfNote, UserId);

            }
            return true;
        }

        public async Task<bool> UpdateReadingListByUser(string userId, string readingListId, CreateReadingListDTO readingListToChangeCred)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize(new { User = userId, readingList = readingListId, readingListToChangeCred }), QueueConstantForRabbitComunication.ReadingListQueue, QueueConstantForRabbitComunication.UpdateReadingListByUser);
            JsonElement result = JsonSerializer.Deserialize<JsonElement>(json);
            if (result.GetProperty("Status").Equals("Bad User"))
            {
                return false;
            }
            else if (!result.GetProperty("Status").Equals("Ok"))
            {
                await UpdateReadingListByUser(userId, readingListId, readingListToChangeCred);

            }
            return true;
        }
    }
}
