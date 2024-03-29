﻿using ECommerce.Mango.Services.CouponAPI.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Mango.Services.CouponAPI.Persistence.Migrations;

public static class MigrationHelper
{
    public static WebApplication ApplyPendingMigrations(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        CouponEFDbContext dbContext = scope.ServiceProvider.GetRequiredService<CouponEFDbContext>();

        if(dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
        }

        return app;
    }
}
