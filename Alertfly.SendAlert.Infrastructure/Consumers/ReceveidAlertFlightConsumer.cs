﻿using Alertfly.SendAlert.Core.Interfaces;
using Alertfly.SendAlert.Infrastructure.IntegrationEvents;
using Alertfly.SendAlert.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace Alertfly.SendAlert.Infrastructure.Consumers
{
    public class ReceveidAlertFlightConsumer : BackgroundService
    {
        private const string QUEUE_NAME = "AlertFlight";
        private const string ROUTING_KEY = "created.AlertFlight";

        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public ReceveidAlertFlightConsumer(IServiceProvider serviceProvider)
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
                autoDelete: false,
                exclusive: false,
                arguments: null
            );

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, EventArgs) =>
            {
                var alertFlightInfoBytes = EventArgs.Body.ToArray();
                var alertFlightInfoJson = Encoding.UTF8.GetString(alertFlightInfoBytes);

                var receivedAlertFlight = JsonSerializer.Deserialize<ReceivedAlertFlightIntegrationEvent>(alertFlightInfoJson);

                await SendAlertAsync(receivedAlertFlight);

                _channel.BasicAck(EventArgs.DeliveryTag, false);

            };

            _channel.BasicConsume(QUEUE_NAME, false, consumer);

            return Task.CompletedTask;
        }

        private async Task SendAlertAsync(ReceivedAlertFlightIntegrationEvent receivedAlertFlight)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sendAlertService = scope.ServiceProvider.GetRequiredService<ISendAlertService>();

               await sendAlertService.SendAlertWithEmailAsync(receivedAlertFlight.UserId, receivedAlertFlight.FlightId);
                
            }
        }
    }
}
