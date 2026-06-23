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
            await Task.CompletedTask;
        }
    }
}
