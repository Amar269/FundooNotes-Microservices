using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;
using SharedLibrary.Contracts.Events;
using SharedLibrary.Messaging.Configuration;
using NotesService.Application.Consumers;

namespace NotesService.Infrastructure.Messaging
{
    public class RabbitMqConsumerService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly RabbitMqSettings _settings;
        public RabbitMqConsumerService(IServiceScopeFactory scopeFactory, IOptions<RabbitMqSettings> settings)
        {
            _scopeFactory = scopeFactory;
            _settings = settings.Value;
        }


        protected override async Task ExecuteAsync( CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = _settings.HostName,
                UserName = _settings.UserName,
                Password = _settings.Password
            };

            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();
            await channel.QueueDeclareAsync(queue: "user.registered",durable: true,exclusive: false,autoDelete: false,arguments: null);
            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (sender, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();

                var json = Encoding.UTF8.GetString(body);

                var message  =
                    JsonSerializer.Deserialize<UserRegisteredEvent>(json);

                if (message != null)
                {
                    using var scope = _scopeFactory.CreateScope();

                    var userConsumer =
                        scope.ServiceProvider
                        .GetRequiredService<UserRegisteredConsumer>();

                    await userConsumer.Consume(message);

                }
            };
            await Task.Delay( Timeout.Infinite,stoppingToken);
        }
    }
}
