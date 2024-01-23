using ECommerce.Mango.Gateway.Extensions;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// register Services
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "APIGateway",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Configuration.AddJsonFile(
    path: $"ocelot.{builder.Environment.EnvironmentName}.json",
    optional: false,
    reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseCors("APIGateway");
app.UseOcelot().GetAwaiter().GetResult();

app.Run();
