using ECommerce.Mango.Services.CouponAPI.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Mango.Services.CouponAPI.Persistence;

public static class PersistenceServiceRegistration
{
    private const string CouponSqlServerDbContext = "CouponSqlServerDbContext";

    public static IServiceCollection AddCouponEFDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CouponDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("CouponSqlServerDbContext")));

        return services;
    }
}
