using ECommerce.Mango.Services.EmailAPI.Extensions;
using ECommerce.Mango.Services.EmailAPI.Infrastructure;
using ECommerce.Mango.Services.EmailAPI.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEmailLoggerDbContext(builder.Configuration);
//builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices();

var app = builder.Build();

app.MapGet("/", () => "Email API service!");

//app.UseAzureServiceBusConsumer();
await app.AzureCosmosDbInit(app.Configuration);

app.Run();
