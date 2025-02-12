using MediumDataBaseManagerAzureApi.DTO.TempMessage;
using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Service.RabitMqGlobalData;
using RabbitMQ.Client;
using System.Text.Json;

namespace MediumDataBaseManagerAzureApi.Service.RabitMqProducerWraper
{
    public class RabitMqProducerWraperClass
    {
        private readonly RabitMqGlobalDataClass _wrapper;
        private const string ContentStateQueueForMapping = "ContentStateQueueForMapping";

        public async Task SendContentStateToMappper(ContentStateModel content, BasicProperties props)
        {
            TempMessageDTO tempMessage = new TempMessageDTO
            {
                Type = "MappingContentStateForFrontend",
                Message = JsonSerializer.Serialize(content)
            };

            await _wrapper.SendMessageWrapper(tempMessage, ContentStateQueueForMapping, props);
        }
        
    }
}
