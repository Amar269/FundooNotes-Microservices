using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Read ocelot.json
builder.Configuration
    .AddJsonFile("ocelot.json",
        optional: false,
        reloadOnChange: true);

// Register Ocelot
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

// Use Ocelot Middleware
await app.UseOcelot();

app.Run();

