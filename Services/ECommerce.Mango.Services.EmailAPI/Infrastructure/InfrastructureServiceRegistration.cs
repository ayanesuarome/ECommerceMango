using ECommerce.Mango.Services.EmailAPI.Core.Application.Interfaces;
using ECommerce.Mango.Services.EmailAPI.Infrastructure.EmailServices;
using ECommerce.Mango.Services.EmailAPI.Infrastructure.Messagings;

namespace ECommerce.Mango.Services.EmailAPI.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
    {
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddSingleton<IAzureServiceBusConsumer, AzureServiceBusConsumer>();

        return services;
    }
}
