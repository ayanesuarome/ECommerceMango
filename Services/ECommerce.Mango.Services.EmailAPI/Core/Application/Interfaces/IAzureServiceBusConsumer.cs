namespace ECommerce.Mango.Services.EmailAPI.Core.Application.Interfaces;

public interface IAzureServiceBusConsumer
{
    Task Start();
    Task Stop();
}
