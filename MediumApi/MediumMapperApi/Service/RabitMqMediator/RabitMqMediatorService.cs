using MediumMapperApi.DTO.TempMessage;
using MediumMapperApi.Models.ContentState;
using MediumMapperApi.Service.ContentState;
using MediumMapperApi.Service.RabitMqProducerWraper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace MediumMapperApi.Service.RabitMqMediator
{
    public class RabitMqMediatorService
    {
        private readonly RabitMqProducerWraperClass _Producer;
        private readonly IContentState _contentStateService;
        public async Task Handler(byte[] message, BasicProperties props)
        {
            TempMessageDTO messageDTO = JsonSerializer.Deserialize< TempMessageDTO >( Encoding.UTF8.GetString(message));
            switch (messageDTO.Type) 
            {
                case "GetContentState":
                    await _Producer.SendContentStateToWriteStory(_contentStateService.ContentBazeToStateDto(JsonSerializer.Deserialize<ContentStateModel>(Encoding.UTF8.GetString(message))), props);
                    break;
                case "SaveContentStateToBaseData":

                    break;
                default:
                    break;
            }
        }
    }
}
