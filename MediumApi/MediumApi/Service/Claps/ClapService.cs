using MediumApi.RabbitMQCover;
using System.Text.Json;

namespace MediumApi.Service.Claps
{
    public class ClapService(RabitMqGlobalDataClass _rabbitClient) : IClapService
    {
        public async Task AddClapsToReadingListByUser(string UserID, string ReadingListId)
        {
            string JsonResult = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize(new { user = UserID, readingList = ReadingListId }), QueueConstantForRabbitComunication.UpdateClapsAndResponseQueue, QueueConstantForRabbitComunication.AddClapsToReadingList);

            JsonElement result = JsonSerializer.Deserialize<JsonElement>(JsonResult);
            if (!result.GetProperty("Status").Equals("OK"))
            {
                await AddClapsToStoryByUser(UserID, ReadingListId);
            }
        }

        public async Task AddClapsToResponceByUser(string UserID, string responceId)
        {
            string JsonResult = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize(new { user = UserID, responce = responceId }), QueueConstantForRabbitComunication.UpdateClapsAndResponseQueue, QueueConstantForRabbitComunication.AddClapsToResponce);

            JsonElement result = JsonSerializer.Deserialize<JsonElement>(JsonResult);
            if (!result.GetProperty("Status").Equals("OK"))
            {
                await AddClapsToResponceByUser(UserID, responceId);
            }
        }

        public async Task AddClapsToStoryByUser(string UserID, string StoryId)
        {
            string JsonResult = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize(new { user = UserID, story = StoryId }), QueueConstantForRabbitComunication.UpdateClapsAndResponseQueue, QueueConstantForRabbitComunication.AddClapsToStory);

            JsonElement result = JsonSerializer.Deserialize<JsonElement>(JsonResult);
            if (!result.GetProperty("Status").Equals("OK"))
            {
                await AddClapsToStoryByUser(UserID, StoryId);
            }
        }

        public async Task<int> GetClapsByReadingList(string ReadingListId)
        {
            string JsonResult = await _rabbitClient.DataBaseCommonRequest(ReadingListId, QueueConstantForRabbitComunication.UpdateClapsAndResponseQueue, QueueConstantForRabbitComunication.GetClapsByReadingList);

            return JsonSerializer.Deserialize<int>(JsonResult);
        }

        public async Task<int> GetClapsByStory(string StoryId)
        {
            string JsonResult = await _rabbitClient.DataBaseCommonRequest(StoryId, QueueConstantForRabbitComunication.UpdateClapsAndResponseQueue, QueueConstantForRabbitComunication.GetClapsByStory);

            return JsonSerializer.Deserialize<int>(JsonResult);

        }
    }
}
