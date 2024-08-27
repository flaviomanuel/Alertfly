using Alertfly.SendAlert.Application.ViewModels;
using Alertfly.SendAlert.Core.Interfaces;
using Alertfly.SendAlert.Infrastructure.IntegrationEvents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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

            consumer.Received += async (sender, eventArgs) =>
            {
                var receivedUserFlightAlertBytes = eventArgs.Body.ToArray();
                var receivedUserFlightAlertJson = Encoding.UTF8.GetString(receivedUserFlightAlertBytes);

                var receivedAlertFlightViewModel = JsonSerializer.Deserialize<ReceivedAlertFlightIntegrationEvent>(receivedUserFlightAlertJson);


                SendEmailAlert();

            };

        }

        private void SendEmailAlert(ReceivedAlertFlightIntegrationEvent receivedAlertFlight)
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                var sendEmailService = scope.ServiceProvider.GetRequiredService<ISendEmailService>();

                sendEmailService.SendEmail(receivedAlertFlight.e);

            }
        }
    }
}
