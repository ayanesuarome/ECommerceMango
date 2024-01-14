using ECommerce.Mango.Services.CouponAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Mango.Services.CouponAPI.Persistence.DatabaseContext;

public sealed class CouponDbContext : DbContext
{
    public CouponDbContext(DbContextOptions<CouponDbContext> options)
        :base(options)
    {
    }

    public DbSet<Coupon> Coupons { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
            DateTime now = DateTime.Now;
            entry.Entity.DateModified = now;

            if(entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CouponDbContext).Assembly);
    }
}
