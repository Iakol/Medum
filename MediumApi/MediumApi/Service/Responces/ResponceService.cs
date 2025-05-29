using MediumApi.DTO.StoryDTO.ResponceDTO;
using MediumApi.RabbitMQCover;
using MediumApi.Service.ConccurentDictonryForReplyTask;
using RabbitMQ.Client;
using System.Text.Json;
using System.Threading.Tasks;

namespace MediumApi.Service.Responces
{
    public class ResponceService(RabitMqGlobalDataClass _rabbitClient) : IResponceService
    {


        public async Task<bool> AddResponceByUser(string UserID, string readId, string TextOfResponce, int? ResponseId, int readType)
        {
            var Message = new { User = UserID, Read = readId, TextOfResponce, Response = ResponseId, readType = readType };

            string JsonResult = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize(Message), QueueConstantForRabbitComunication.UpdateClapsAndResponseQueue, QueueConstantForRabbitComunication.AddResponce);

            JsonElement result = JsonSerializer.Deserialize<JsonElement>(JsonResult);

            if (!result.GetProperty("Status").Equals("Ok"))
            {
                await AddResponceByUser(UserID, readId, TextOfResponce, ResponseId, readType);
            }
            return true;
        }

        public async Task<bool> DeleteResponceByResponceid(int responceId)
        {
            string JsonResult = await _rabbitClient.DataBaseCommonRequest(responceId.ToString(), QueueConstantForRabbitComunication.UpdateClapsAndResponseQueue, QueueConstantForRabbitComunication.DeleteResponce);

            JsonElement result = JsonSerializer.Deserialize<JsonElement>(JsonResult);

            if (!result.GetProperty("Status").Equals("Ok"))
            {

                await DeleteResponceByResponceid(responceId);
            }
            return true;


        }



        public async Task<List<ResponceDTO>> GetResponce(string readId, int readType)
        {
            string JsonResult = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize( new {Read = readId, readType }), QueueConstantForRabbitComunication.UpdateClapsAndResponseQueue, QueueConstantForRabbitComunication.GetResponce);


            return JsonSerializer.Deserialize<List<ResponceDTO>>(JsonResult);
        }


        public async Task<int> GetResponceCount(string readId, int readType)
        {
            string JsonResult = await _rabbitClient.DataBaseCommonRequest(JsonSerializer.Serialize(new { Read = readId, readType }), QueueConstantForRabbitComunication.UpdateClapsAndResponseQueue, QueueConstantForRabbitComunication.GetResponceCount);
            return JsonSerializer.Deserialize<int>(JsonResult);
        }
    }
}
