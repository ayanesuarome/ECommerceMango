using ECommerce.Mango.Services.EmailAPI.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Mango.Services.EmailAPI.Infrastructure.Persistence.Configurations
{
    public class EmailLoggerConfiguration : IEntityTypeConfiguration<EmailLogger>
    {
        public void Configure(EntityTypeBuilder<EmailLogger> builder)
        {
            builder.ToContainer("EmailLoggers")
                .HasNoDiscriminator()
                .HasPartitionKey(e => e.Uid);
        }
    }
}
