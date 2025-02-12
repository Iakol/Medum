using MediumMapperApi.DTO.TempMessage;
using MediumMapperApi.Service.RabitMqGlobalData;
using RabbitMQ.Client;
using System.Text.Json;

namespace MediumMapperApi.Service.RabitMqProducerWraper
{
    public class RabitMqProducerWraperClass
    {
        private readonly RabitMqGlobalDataClass _wrapper;
        public async Task SendContentStateToMappper(BasicProperties props)
        {
            TempMessageDTO tempMessage = new TempMessageDTO
            {
                Type = "",
                Message = JsonSerializer.Serialize("content")
            };

            await _wrapper.SendMessageWrapper(tempMessage, "Temp", props);
        }
        
    }
}
