using ECommerce.Mango.Services.EmailAPI.Core.Application.Models;
using ECommerce.Mango.Services.EmailAPI.Infrastructure.Persistence.DatabaseContext;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;

namespace ECommerce.Mango.Services.EmailAPI.Extensions;

public static class CosmosDbInitExtension
{
    public static async Task<IApplicationBuilder> AzureCosmosDbInit(this IApplicationBuilder app, IConfiguration configuration)
    {
        CosmosSettings settings = app
            .ApplicationServices
            .GetRequiredService<IOptions<CosmosSettings>>()
        .Value;

        IDbContextFactory<EmailDbContext> factory = app
            .ApplicationServices
            .GetRequiredService<IDbContextFactory<EmailDbContext>>();

        using EmailDbContext dbContext = factory.CreateDbContext();
        try
        {
            var docs = await dbContext.EmailLoggers.FirstOrDefaultAsync();
        }
        catch (CosmosException ex)
        {
            if (ex.StatusCode == HttpStatusCode.NotFound)
            {
                await dbContext.Database.EnsureCreatedAsync();
                WriteLine("Database created");
            }
            else
            {
                WriteLine("Database already exist");
            }
        }

        return app;
    }
}
