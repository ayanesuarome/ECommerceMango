using ECommerce.Mango.Services.AuthAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ECommerce.Mango.Services.AuthAPI.Data.DatabaseContext;

public sealed class AppIdentityEFDbContext : IdentityDbContext<ApplicationUser>
{
    public AppIdentityEFDbContext(DbContextOptions<AppIdentityEFDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
