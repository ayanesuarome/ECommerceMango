using AutoMapper;
using Blazored.LocalStorage;
using ECommerce.Mango.BlazorUI.Interfaces;
using ECommerce.Mango.BlazorUI.Models.Coupons;
using ECommerce.Mango.BlazorUI.Services.Base;

namespace ECommerce.Mango.BlazorUI.Services.Coupons
{
    public class CouponService(IMapper mapper, ICouponClient client, ILocalStorageService localStorage)
        : BaseHttpService(localStorage), ICouponService
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICouponClient _client = client;

        public async Task<List<CouponVM>> GetCouponListAsync()
        {
            ICollection<CouponDto> coupons = await _client.CouponAllAsync();
            return _mapper.Map<List<CouponVM>>(coupons);
        }

        public Task<CouponVM> GetCouponDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CouponVM> GetCouponDetailsByIdAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Guid>> CreateCouponAsync(CouponVM coupon)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Guid>> DeleteCouponAsync(int coupon)
        {
            throw new NotImplementedException();
        }
    }
}
