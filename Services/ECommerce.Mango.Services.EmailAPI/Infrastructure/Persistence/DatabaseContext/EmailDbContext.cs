using ECommerce.Mango.Services.EmailAPI.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Mango.Services.EmailAPI.Infrastructure.Persistence.DatabaseContext;

public sealed class EmailDbContext : DbContext
{
    public EmailDbContext(DbContextOptions<EmailDbContext> options)
        : base(options)
    {
    }

    public DbSet<EmailLogger> EmailLoggers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmailDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
