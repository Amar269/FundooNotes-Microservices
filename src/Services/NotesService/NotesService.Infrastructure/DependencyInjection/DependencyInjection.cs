using Microsoft.Extensions.DependencyInjection;
using NotesService.Application.Interfaces;
using NotesService.Infrastructure.Repositories;

namespace NotesService.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<INoteRepository, NoteRepository>();

        return services;
    }
}