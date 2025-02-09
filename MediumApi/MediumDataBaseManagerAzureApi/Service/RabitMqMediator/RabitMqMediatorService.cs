using MediumDataBaseManagerAzureApi.DTO.TempMessage;
using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Service.ContentState;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MediumDataBaseManagerAzureApi.Service.RabitMqMediator
{
    public class RabitMqMediatorService
    {
        private readonly IContentStateService _contentStateService;
        public async Task Handler(byte[] message, IReadOnlyBasicProperties props)
        {
            TempMessageDTO messageDTO = new TempMessageDTO();
            switch (messageDTO.Type) 
            {
                case "GetContentState":
                    ContentStateModel content = await _contentStateService.GetContentStateById(messageDTO.Message);

                    break;
                default:
                    break;
            }
        }
    }
}
