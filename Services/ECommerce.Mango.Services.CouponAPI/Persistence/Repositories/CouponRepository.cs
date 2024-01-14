using ECommerce.Mango.Services.CouponAPI.Core.Domain.Entities;
using ECommerce.Mango.Services.CouponAPI.Core.Domain.Interfaces.Persistence;
using ECommerce.Mango.Services.CouponAPI.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Mango.Services.CouponAPI.Persistence.Repositories;

public class CouponRepository(CouponDbContext dbContext) : ICouponRepository
{
    private readonly CouponDbContext _dbContext = dbContext;
    private DbSet<Coupon> Entities => _dbContext.Set<Coupon>();

    public virtual IQueryable<Coupon> Table => Entities;
    public virtual IQueryable<Coupon> TableNoTracking => Entities.AsNoTracking();

    public async Task<IReadOnlyList<Coupon>> GetAsync()
    {
        return await TableNoTracking.ToListAsync();
    }

    public async Task<Coupon> GetByIdAsync(int id)
    {
        return await TableNoTracking.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task CreateAsync(Coupon entity)
    {
        try
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
