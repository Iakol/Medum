using MediumApi.DTO.AuthorDTO;
using MediumApi.RabbitMQCover;
using System.Text.Json;

namespace MediumApi.Service.ReadingHistory
{
    public class ReadingHistory(RabitMqGlobalDataClass _rabbitClient) : IReadingHistory
    {
        public async Task ClearUserReadingHistory(string userId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(userId, QueueConstantForRabbitComunication.ReadingHistoryQueue, QueueConstantForRabbitComunication.ClearReadingHistoryByUser);

            JsonElement result = JsonSerializer.Deserialize<JsonElement>(json);

            if (result.TryGetProperty("Status", out _)) 
            {
                await ClearUserReadingHistory(userId);
            }
        }

        public async Task<AuthorCredDTO> GetUserReadingHistory(string userId)
        {
            string json = await _rabbitClient.DataBaseCommonRequest(userId, QueueConstantForRabbitComunication.ReadingHistoryQueue, QueueConstantForRabbitComunication.GetReadingHistoryByUser);

            AuthorCredDTO User = JsonSerializer.Deserialize<AuthorCredDTO>(json);

            return User;
        }

    }
}
