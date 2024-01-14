using ECommerce.Mango.Services.CouponAPI.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Mango.Services.CouponAPI.Persistence.Configurations;

public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.Property(property => property.CouponCode)
            .IsRequired();

        builder.HasData(
            new Coupon
            {
                Id = 1,
                CouponCode = "10OFF",
                DiscountAmount = 10,
                MinimumAmount = 20,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            }, new Coupon
            {
                Id = 2,
                CouponCode = "20OFF",
                DiscountAmount = 20,
                MinimumAmount = 40,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            });
    }
}
