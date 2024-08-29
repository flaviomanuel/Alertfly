using Alertfly.App.Core.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System.Text;
using System.Text.Json;

namespace Alertfly.App.Infrastructure.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        private readonly ConnectionFactory _factory;
        public MessageBusService()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",

            };
        }

        public void Publish(object message, string queue, string routingKey, string exchange)
        {


            var messageJson = JsonSerializer.Serialize(message);

            var body = Encoding.UTF8.GetBytes(messageJson);

            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {

                    // Declara exchange
                    channel.ExchangeDeclare(exchange: exchange, ExchangeType.Topic, autoDelete: false);

                    // Declara fila
                    channel
                        .QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, null);

                    // Vincula Fila ao exchange
                    channel.QueueBind(queue, exchange, routingKey);

                    // Publica mensagem
                    channel
                        .BasicPublish(exchange, routingKey, basicProperties: null, body);

                }
            }
        }
    }
}
