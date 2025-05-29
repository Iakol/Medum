using JWT;
using MediumApi.DTO.TopicDTO;
using MediumApi.RabbitMQCover;
using System.Text.Json;

namespace MediumApi.Service.Topic
{
    public class TopicService(RabitMqGlobalDataClass _rabbitClient) : ITopicService
    {
        public async Task CreateTopic(string TopicName)
        {
            string result = await _rabbitClient.DataBaseCommonRequest(TopicName, QueueConstantForRabbitComunication.TopicQueue, QueueConstantForRabbitComunication.CreateTopic);

            if (!JsonSerializer.Deserialize<JsonElement>(result).GetProperty("Status").Equals("OK"))
            {
                await CreateTopic(TopicName);
            }

        }

        public async Task<List<TopicDTO>> GetFollowTopicsForUser(string UserId)
        {
            string result = await _rabbitClient.DataBaseCommonRequest(UserId, QueueConstantForRabbitComunication.TopicQueue, QueueConstantForRabbitComunication.GetFollowTopicsForUser);

            return JsonSerializer.Deserialize<List<TopicDTO>>(result);
        }

        public async Task<List<TopicDTO>> GetRecomendationTopicsForUser(string UserId)
        {
            string result = await _rabbitClient.DataBaseCommonRequest(UserId, QueueConstantForRabbitComunication.TopicQueue, QueueConstantForRabbitComunication.GetRecomendationTopicsForUser);

            return JsonSerializer.Deserialize<List<TopicDTO>>(result);
        }
    }
}
