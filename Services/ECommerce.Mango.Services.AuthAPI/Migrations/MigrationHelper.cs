using ECommerce.Mango.Services.AuthAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Mango.Services.AuthAPI.Migrations;

public static class MigrationHelper
{
    public static WebApplication ApplyPendingMigrations(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        AppIdentityEFDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppIdentityEFDbContext>();

        if(dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
        }

        return app;
    }
}
