using CollaboratorService.Application;
using CollaboratorService.Infrastructure.DependencyInjection;
using Microsoft.OpenApi.Models;
using MediatR;
using CollaboratorService.Application.Commands.AddCollaborator;
using CollaboratorService.Application.Interfaces;
using CollaboratorService.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Collaborator Service API",
            Version = "v1"
        });
});

builder.Services.AddMediatR(
    typeof(AddCollaboratorCommandHandler).Assembly
);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHttpClient<IUserServiceClient, UserServiceClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7221/");
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();