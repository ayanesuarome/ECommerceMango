using ECommerce.Mango.Services.AuthAPI.Data.DatabaseContext;
using ECommerce.Mango.Services.AuthAPI.Entities;
using ECommerce.Mango.Services.AuthAPI.Interfaces;
using ECommerce.Mango.Services.AuthAPI.Models;
using ECommerce.Mango.Services.AuthAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ECommerce.Mango.Services.AuthAPI.Extensions
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityEFDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppIdentitySqlServerDbContext")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityEFDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IRoleService, RoleService>();

            services.Configure<JwtSettings>(configuration.GetRequiredSection(nameof(JwtSettings)));

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            JwtSettings jwtSettings = serviceProvider.GetRequiredService<IOptions<JwtSettings>>().Value;

            return services;
        }
    }
}
