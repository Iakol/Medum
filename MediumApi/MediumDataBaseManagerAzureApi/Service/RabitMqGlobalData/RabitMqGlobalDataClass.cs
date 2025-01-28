using MediumDataBaseManagerAzureApi.Service.RabitMqMediator;
using MediumDataBaseManagerAzureApi.Service.RabitMqProducerWraper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Data;
using System.Threading.Channels;

namespace MediumDataBaseManagerAzureApi.Service.RabitMqGlobalData
{
    public class RabitMqGlobalDataClass
    {
        private IConnection? _connection;
        private IChannel? _sendChannel;
        private IChannel? _retriveChannel;
        private ConcurrentDictionary<string, string> queueDictionary;
        private string sendQueue = "ContentStateRequestQueue";
        private string retriveQueue = "retriveContentStateQueue";

        private RabitMqMediatorService _Mediator;


        public RabitMqGlobalDataClass(RabitMqMediatorService Mediator) 
        {
            _Mediator = Mediator;
        }

        public async Task<IConnection> GetConnectionToRabit() {

            if (_connection == null) 
            {
                var factory = new ConnectionFactory();
                factory.UserName = "user";
                factory.Password = "password";
                factory.HostName = "localhost";
                factory.Port = 5672;
                _connection = await factory.CreateConnectionAsync();

            }

            return _connection!;
        }

        public async Task<IChannel> GetSendChannelToRabit()
        {
            if (_sendChannel == null) 
            {
                IConnection conection = await GetConnectionToRabit();
                _sendChannel = await conection.CreateChannelAsync();
            }

            return _sendChannel!;
        }

        public async Task<IChannel> GetRetriveChannelChannelToRabit()
        {

            if (_retriveChannel == null)
            {
                IConnection conection = await GetConnectionToRabit();
                _retriveChannel = await conection.CreateChannelAsync();
            }

            return _retriveChannel!;
        }

        public async Task CreateNewQueueForChanel(IChannel ToAddchanel, string QueueName)
        {
            await ToAddchanel.QueueDeclareAsync(queue: sendQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public async Task CreateConsumerForChanelToQueue(IChannel ToAddchanel, string QueueName) 
        {
            await CreateNewQueueForChanel(ToAddchanel, QueueName);
            var consumer = new AsyncEventingBasicConsumer(ToAddchanel);
            consumer.ReceivedAsync += async (ch, ea) => 
            {
                var body = ea.Body.ToArray();
                await _Mediator.Handler(body);
                await ToAddchanel.BasicAckAsync(ea.DeliveryTag, false);
            };
            await ToAddchanel.BasicConsumeAsync(QueueName, false, consumer);

        }


    }
}
