using MediumMapperApi.DTO.ContentStateDTO;
using MediumMapperApi.DTO.TempMessage;
using MediumMapperApi.Service.RabitMqGlobalData;
using RabbitMQ.Client;
using System.Text.Json;

namespace MediumMapperApi.Service.RabitMqProducerWraper
{
    public class RabitMqProducerWraperClass
    {
        private readonly RabitMqGlobalDataClass _wrapper;
        public async Task SendContentStateToWriteStory(ContentStateDTO content ,BasicProperties props)
        {
            TempMessageDTO tempMessage = new TempMessageDTO
            {
                Type = "GetContentState",
                Message = JsonSerializer.Serialize(content)
            };

            await _wrapper.SendMessageWrapper(tempMessage, props.ReplyTo, props);
        }
        
    }
}
