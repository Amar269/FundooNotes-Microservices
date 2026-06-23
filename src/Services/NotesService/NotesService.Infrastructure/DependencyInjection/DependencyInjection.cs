using Microsoft.Extensions.DependencyInjection;
using NotesService.Application.Interfaces;
using NotesService.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using NotesService.Infrastructure.Caching;
using Microsoft.Extensions.Caching.StackExchangeRedis;


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

        return services;
    }
}