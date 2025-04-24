using MediumDataBaseManagerAzureApi.DTO.TempMessage;
using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Service.ModalServices.ContentState;
using MediumDataBaseManagerAzureApi.Service.RabitMqProducerWraper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace MediumDataBaseManagerAzureApi.Service.RabitMqMediator
{
    public class RabitMqMediatorService
    {
        private readonly IContentStateService _contentStateService;
        private readonly RabitMqProducerWraperClass _Producer;
        public async Task Handler(byte[] message, BasicProperties props)
        {
            TempMessageDTO messageDTO = JsonSerializer.Deserialize< TempMessageDTO >( Encoding.UTF8.GetString(message));
            switch (messageDTO.Type) 
            {
                case "GetContentState":
                    ContentStateModel content = await _contentStateService.GetContentStateById(messageDTO.Message);
                    
                    await _Producer.SendContentStateToMappper(content, props);
                    break;
                case "SaveContentState":
                    ContentStateModel content = await _contentStateService.GetContentStateById(messageDTO.Message);

                    await _Producer.SendContentStateToMappper(content, props);
                    break;
                default:
                    break;
            }
        }
    }
}
