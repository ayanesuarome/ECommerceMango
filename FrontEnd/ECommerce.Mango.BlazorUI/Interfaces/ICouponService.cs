using ECommerce.Mango.BlazorUI.Models.Coupons;
using ECommerce.Mango.BlazorUI.Services.Base;

namespace ECommerce.Mango.BlazorUI.Interfaces;

public interface ICouponService
{
    Task<List<CouponVM>> GetCouponListAsync();
    Task<CouponVM> GetCouponDetailsAsync(int id);
    Task<CouponVM> GetCouponDetailsByIdAsync(string code);
    Task<Response<Guid>> CreateCouponAsync(CouponVM coupon);
    Task<Response<Guid>> DeleteCouponAsync(int coupon);
}
