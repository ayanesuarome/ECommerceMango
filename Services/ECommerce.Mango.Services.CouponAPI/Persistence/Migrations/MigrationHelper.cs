using ECommerce.Mango.Services.CouponAPI.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Mango.Services.CouponAPI.Persistence.Migrations;

public static class MigrationHelper
{
    public static void ApplyMigration(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        CouponDbContext dbContext = scope.ServiceProvider.GetRequiredService<CouponDbContext>();

        if(dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
        }
    }
}
