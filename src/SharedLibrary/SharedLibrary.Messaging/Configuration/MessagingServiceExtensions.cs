using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Messaging.Interfaces;
using SharedLibrary.Messaging.Services;

namespace SharedLibrary.Messaging.Configuration;

public static class MessagingServiceExtensions
{
    public static IServiceCollection AddRabbitMqMessaging(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<RabbitMqSettings>(configuration.GetSection("RabbitMq"));

        services.AddSingleton<IRabbitMqPublisher,
            RabbitMqPublisher>();

        return services;
    }
}