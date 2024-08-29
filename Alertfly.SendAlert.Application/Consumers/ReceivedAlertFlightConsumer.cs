using Alertfly.SendAlert.Core.Interfaces;
using Alertfly.SendAlert.Infrastructure.IntegrationEvents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Alertfly.SendAlert.Application.Consumers
{
    public class ReceivedAlertFlightConsumer : BackgroundService
    {
        private const string QUEUE_ALERTFLIGHT_NAME = "AlertFlight";
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public ReceivedAlertFlightConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                    QUEUE_ALERTFLIGHT_NAME,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                var receivedUserFlightAlertBytes = eventArgs.Body.ToArray();
                var receivedUserFlightAlertJson = Encoding.UTF8.GetString(receivedUserFlightAlertBytes);

                var receivedAlertFlightIntegrationEvent = JsonSerializer.Deserialize<ReceivedAlertFlightIntegrationEvent>(receivedUserFlightAlertJson);

                if (receivedAlertFlightIntegrationEvent is null)
                {
                    throw new Exception("Erro ao deserializar objeto ReceivedAlertFlightIntegrationEvent!");
                }

                SendEmailAlert(receivedAlertFlightIntegrationEvent);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(QUEUE_ALERTFLIGHT_NAME, false, consumer);

            return Task.CompletedTask;
        }

        private void SendEmailAlert(ReceivedAlertFlightIntegrationEvent receivedAlertFlight)
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                var sendAlertService = scope.ServiceProvider.GetRequiredService<ISendAlertService>();

                sendAlertService.SendAlertWithEmailAsync(receivedAlertFlight.UserId, receivedAlertFlight.FlightId);

            }
        }
    }
}
