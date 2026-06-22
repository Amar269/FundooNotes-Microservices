using System;
using System.Collections.Generic;
using System.Text;
using CollaboratorService.Application.Interfaces;
using CollaboratorService.Infrastructure.Context;
using CollaboratorService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CollaboratorService.Infrastructure.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<CollaboratorDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();

            return services;
        }
    }
}
