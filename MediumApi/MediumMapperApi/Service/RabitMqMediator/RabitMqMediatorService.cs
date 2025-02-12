using MediumMapperApi.DTO.TempMessage;
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
        public async Task Handler(byte[] message, BasicProperties props)
        {
            TempMessageDTO messageDTO = JsonSerializer.Deserialize< TempMessageDTO >( Encoding.UTF8.GetString(message));
            switch (messageDTO.Type) 
            {
                case "GetContentState":
                    
                    break;
                default:
                    break;
            }
        }
    }
}
