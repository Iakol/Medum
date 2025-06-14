using MediumDataBaseManagerAzureApi.DTO.TempMessage;
using Microsoft.IdentityModel.Tokens;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Data;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace MediumDataBaseManagerAzureApi.Rabbit.RabbitService
{
    public class RabitMqGlobalDataClass
    {
        private IConnection? _connection;
        private IChannel? _sendChannel;
        private IChannel? _retriveChannel;

        public async Task<IConnection> GetConnectionToRabit()
        {

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
            await ToAddchanel.QueueDeclareAsync(queue: QueueName, durable: false, exclusive: false, autoDelete: true, arguments: null);
        }

        public async Task CreateExangeByName(string ExhangeName)
        {
            await (await GetRetriveChannelChannelToRabit()).ExchangeDeclareAsync(ExhangeName, ExchangeType.Direct, true);
        }

        public async Task CreateQuerryAndBindToExangeByName(string ExhangeName, string QueueName) 
        {
            await CreateNewQueueForChanel(await GetRetriveChannelChannelToRabit(), QueueName);
            await CreateExangeByName(ExhangeName);
            await (await GetRetriveChannelChannelToRabit()).QueueBindAsync(QueueName, ExhangeName, QueueName);
        }

        public async Task CreateConsumerForChanelToQueue(string QueueName, Func<string, Task<string>> processingTask,string? ExhangeName)
        {
            if (!ExhangeName.IsNullOrEmpty()) 
            {
                await CreateQuerryAndBindToExangeByName(ExhangeName!, QueueName);
            }
            else
            {
                await CreateNewQueueForChanel(await GetRetriveChannelChannelToRabit(), QueueName);
            }
            var consumer = new AsyncEventingBasicConsumer(await GetRetriveChannelChannelToRabit());
            consumer.ReceivedAsync += async (ch, ea) =>
            {
                await (await GetRetriveChannelChannelToRabit()).BasicAckAsync(ea.DeliveryTag, false);
                await DataBaseCommonResponce(Encoding.UTF8.GetString(ea.Body.ToArray()), ea.BasicProperties, processingTask);
            };

            await (await GetRetriveChannelChannelToRabit()).BasicConsumeAsync(QueueName, false, consumer);

        }

        public async Task SendMessageWrapper(string Message, string sendQueueOrRouteKey, BasicProperties? props, string? exchange)
        {

            byte[] body = Encoding.UTF8.GetBytes(Message);
            IChannel Sendchanel = _sendChannel == null ? await GetSendChannelToRabit() : _sendChannel;

            if (exchange == null)
            {
                await CreateNewQueueForChanel(Sendchanel, sendQueueOrRouteKey);
            }
            await Sendchanel.BasicPublishAsync(exchange: exchange != null ? exchange : "",
                              routingKey: sendQueueOrRouteKey,
                              mandatory: true,
                              basicProperties: props,
                              body: body);

        }

        public async Task DataBaseCommonResponce(string RetriveMessage, IReadOnlyBasicProperties retriveProps,Func<string,Task<string>> processingTask)
        {
            string processingResult = await processingTask(RetriveMessage);
            BasicProperties sendProps = new BasicProperties();
            sendProps.CorrelationId = retriveProps.CorrelationId;
            await SendMessageWrapper(processingResult, retriveProps.ReplyTo, sendProps, null);
        }


    }
}
