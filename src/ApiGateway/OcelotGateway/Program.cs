using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration
    .AddJsonFile("ocelot.json",
        optional: false,
        reloadOnChange: true);

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
             .AllowAnyHeader()
             .AllowAnyMethod();

    });
    options.AddPolicy("RestrictedOrigin", policy =>
    {
        policy.WithOrigins("https://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });

});


builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAll");
}
else
{
    app.UseCors("RestrictedOrigin");
}


await app.UseOcelot();

app.Run();

