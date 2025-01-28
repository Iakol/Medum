using MediumWriteStoreApi.DTO;
using MediumWriteStoreApi.DTO.ContentStateDTO;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StackExchange.Redis;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MediumWriteStoreApi.Service.RabitMQProducerService
{
    public class RabitMQProducer : IRabitMQProducer
    {
        private IConnection _connection;
        private IChannel _sendChannel;
        private IChannel _retriveChannel;
        private string sendQueue = "ContentStateRequestQueue";
        private string retriveQueue = "retriveContentStateQueue";



        public RabitMQProducer()
        {

        }

        public async Task CreateConection() 
        {
            var factory = new ConnectionFactory { HostName = "hostName" };
            _connection = await factory.CreateConnectionAsync();
            _sendChannel = await _connection.CreateChannelAsync();
            _retriveChannel = await _connection.CreateChannelAsync();
            await _sendChannel.QueueDeclareAsync(queue: sendQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            await _retriveChannel.QueueDeclareAsync(queue: retriveQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

        }


        public async Task<string> sendMessage(string requestQueue, string responseQueue, TempMessageDTO message)
        {
            

            string CorelationId = DateTime.Now.ToString("ss:m:ss") + Guid.NewGuid().ToString();
            var props = new BasicProperties();

            props.CorrelationId = CorelationId;
            props.ReplyTo = responseQueue;

            byte[] messageBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize( message));


            var tcs = new TaskCompletionSource<string>();
            var consumer = new AsyncEventingBasicConsumer(_retriveChannel);

            consumer.ReceivedAsync += async(ch, ea) =>
                {
                    if (ea.BasicProperties.CorrelationId!.Equals(CorelationId)) 
                    {
                        byte[] ResponsemessageBytes = new byte[ea.Body.Length];
                        ea.Body.CopyTo(ResponsemessageBytes);

                        tcs.SetResult(Encoding.UTF8.GetString(ResponsemessageBytes));
                    }
            
                };


            return await tcs.Task;
        }

        public async Task<ContentStateDTO> GetContentStateFromBdOverRabit(string ContentId)
        {
            if (_connection == null || !_connection.IsOpen)
            {
                await CreateConection();
            }
            TempMessageDTO message = new TempMessageDTO {
                Type = "GetContentState",
                Message = ContentId
            };

            string res = await sendMessage(sendQueue, retriveQueue, message);
            return JsonSerializer.Deserialize<ContentStateDTO>(res)!;

        }

        public void sendMessage(string Type, string Data)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
