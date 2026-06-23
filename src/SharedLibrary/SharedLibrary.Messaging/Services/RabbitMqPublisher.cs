using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using SharedLibrary.Messaging.Configuration;
using SharedLibrary.Messaging.Interfaces;

namespace SharedLibrary.Messaging.Services;

public class RabbitMqPublisher : IRabbitMqPublisher
{
    private readonly RabbitMqSettings _settings;

    public RabbitMqPublisher(
        IOptions<RabbitMqSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task PublishAsync<T>(
        string queueName,
        T message)
    {
        var factory = new ConnectionFactory
        {
            HostName = _settings.HostName,
            UserName = _settings.UserName,
            Password = _settings.Password
        };

        using var connection =
            await factory.CreateConnectionAsync();

        using var channel =
            await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var json =
            JsonSerializer.Serialize(message);

        var body =
            Encoding.UTF8.GetBytes(json);

        await channel.BasicPublishAsync(
            exchange: string.Empty,
            routingKey: queueName,
            body: body);
    }
}