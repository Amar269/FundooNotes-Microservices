using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotesService.Application.Consumers;
using NotesService.Application.Interfaces;
using NotesService.Infrastructure.Caching;
using NotesService.Infrastructure.Messaging;
using NotesService.Infrastructure.Repositories;


namespace NotesService.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services , IConfiguration configuration)
    {
        services.AddScoped<INoteRepository, NoteRepository>();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration =
                configuration["Redis:ConnectionString"];
        });

        services.AddScoped<ICacheService, CacheService>();
        services.AddScoped<UserRegisteredConsumer>();
        

        return services;
    }
}