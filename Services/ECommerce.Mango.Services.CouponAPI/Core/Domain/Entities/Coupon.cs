namespace ECommerce.Mango.Services.CouponAPI.Core.Domain.Entities;

public class Coupon : BaseEntity
{
    public string CouponCode { get; set; } = null!;
    public double DiscountAmount { get; set; }
    public int MinimumAmount { get; set; }
}
