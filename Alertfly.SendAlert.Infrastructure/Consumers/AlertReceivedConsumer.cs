using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

namespace Alertfly.SendAlert.Infrastructure.Consumers
{
    public class AlertReceivedConsumer : BackgroundService
    {
        private const string QUEUE_NAME = "AlertFlight";
        private const string ROUTING_KEY = "created.AlertFlight";

        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public AlertReceivedConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: QUEUE_NAME,
                durable: false,
                autoDelete: true,
                exclusive: false,
                arguments: null
            );

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
