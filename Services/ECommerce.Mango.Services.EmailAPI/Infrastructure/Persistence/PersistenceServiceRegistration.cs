using ECommerce.Mango.Services.EmailAPI.Core.Application.Models;
using ECommerce.Mango.Services.EmailAPI.Core.Domain.Interfaces;
using ECommerce.Mango.Services.EmailAPI.Infrastructure.Persistence.DatabaseContext;
using ECommerce.Mango.Services.EmailAPI.Infrastructure.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ECommerce.Mango.Services.EmailAPI.Infrastructure.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddEmailLoggerDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        CosmosSettings settings = serviceProvider
            .GetRequiredService<IOptions<CosmosSettings>>()
            .Value;

        services.AddDbContextFactory<EmailDbContext>(options => options
            .UseCosmos(
                accountEndpoint: settings.EndPointUri,
                accountKey: settings.PrimaryKey,
                databaseName: "MangoEmail"));

        return services;
    }

    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddSingleton<IEmailRepository, EmailRepository>();

        return services;
    }
}
