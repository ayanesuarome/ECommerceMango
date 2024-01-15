namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Shared;

public class CouponDetailsDto : BaseDto
{
    public string CouponCode { get; set; } = null!;
    public double DiscountAmount { get; set; }
    public int MinimumAmount { get; set; }
}
