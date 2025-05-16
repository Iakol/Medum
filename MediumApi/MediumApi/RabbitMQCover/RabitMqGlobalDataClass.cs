using MediumApi.Service.ConccurentDictonryForReplyTask;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Data;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace MediumApi.RabbitMQCover
{
    public class RabitMqGlobalDataClass(IConccurentDictonryForReplyTask _taskDictonaryService)
    {
        private IConnection? _connection;
        private IChannel? _sendChannel;
        private IChannel? _retriveChannel;

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
            await ToAddchanel.QueueDeclareAsync(queue: QueueName, durable: false, exclusive: true, autoDelete: true, arguments: null);
        }

        public async Task CreateConsumerForChanelToQueue(IChannel ToAddchanel, string QueueName) 
        {
            await CreateNewQueueForChanel(ToAddchanel, QueueName);
            var consumer = new AsyncEventingBasicConsumer(ToAddchanel);
            consumer.ReceivedAsync += async (ch, ea) => 
            {

                await _taskDictonaryService.SetResult(ea.BasicProperties.CorrelationId!, Encoding.UTF8.GetString(ea.Body.ToArray()));
                
                await ToAddchanel.BasicAckAsync(ea.DeliveryTag, false);
            };

            await ToAddchanel.BasicConsumeAsync(QueueName, false, consumer);

        }

        public async Task SendMessageWrapper(string Message,string sendQueueOrRouteKey, BasicProperties? props,string? exchange)
        {
            
            byte[] body = Encoding.UTF8.GetBytes(Message);
            IChannel Sendchanel = _sendChannel == null? await GetSendChannelToRabit() : _sendChannel;

            if (exchange == null) 
            {
                await CreateNewQueueForChanel(Sendchanel, sendQueueOrRouteKey);
            }
            await Sendchanel.BasicPublishAsync(exchange: exchange != null? exchange : "",
                              routingKey: sendQueueOrRouteKey,
                              mandatory:true,
                              basicProperties: props,
                              body: body);

        }


    }
}
