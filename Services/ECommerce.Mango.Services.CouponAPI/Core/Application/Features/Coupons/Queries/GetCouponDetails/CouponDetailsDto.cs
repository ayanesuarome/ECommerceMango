using ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Shared;

namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Queries.GetCouponDetails;

public class CouponDetailsDto : BaseDto
{
    public string CouponCode { get; set; } = null!;
    public double DiscountAmount { get; set; }
    public int MinimumAmount { get; set; }
}
