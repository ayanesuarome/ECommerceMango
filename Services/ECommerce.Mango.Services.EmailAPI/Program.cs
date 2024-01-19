using ECommerce.Mango.Services.EmailAPI.Core.Application;
using ECommerce.Mango.Services.EmailAPI.Core.Application.Models;
using ECommerce.Mango.Services.EmailAPI.Extensions;
using ECommerce.Mango.Services.EmailAPI.Infrastructure;
using ECommerce.Mango.Services.EmailAPI.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEmailLoggerDbContext(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseAzureServiceBusConsumer();
await app.AzureCosmosDbInit(app.Configuration);

app.Run();
