using ECommerce.Mango.Services.CouponAPI.Core.Domain.Entities;

namespace ECommerce.Mango.Services.CouponAPI.Core.Domain.Interfaces.Persistence;

public interface ICouponRepository
{
    Task<IReadOnlyList<Coupon>> GetAsync();
    Task<Coupon> GetByIdAsync(int id);
    Task<Coupon> GetByCouponAsync(string coupon);
    Task CreateAsync(Coupon entity);
    Task DeleteAsync(Coupon entity);
}
