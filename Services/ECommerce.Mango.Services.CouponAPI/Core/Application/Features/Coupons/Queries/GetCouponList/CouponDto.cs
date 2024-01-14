namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Queries.GetCouponList;

public class CouponDto
{
    public int Id { get; set; }
    public string CouponCode { get; set; } = null!;
    public double DiscountAmount { get; set; }
    public int MinimumAmount { get; set; }
}