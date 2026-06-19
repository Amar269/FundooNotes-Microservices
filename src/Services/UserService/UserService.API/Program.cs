using MediatR;
using Microsoft.EntityFrameworkCore;
using UserService.Application.Commands.RegisterUser;
using UserService.Application.Interfaces;
using UserService.Infrastructure.Context;
using UserService.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

builder.Services.AddMediatR(
    typeof(RegisterUserCommandHandler).Assembly
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));




builder.Services.AddScoped<IUserRepository, UserRepository>();



var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();