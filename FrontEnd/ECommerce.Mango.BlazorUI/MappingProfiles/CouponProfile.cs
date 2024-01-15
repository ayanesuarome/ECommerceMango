using AutoMapper;
using ECommerce.Mango.BlazorUI.Models.Coupons;
using ECommerce.Mango.BlazorUI.Services.Coupons;

namespace ECommerce.Mango.BlazorUI.MappingProfiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<CouponDto, CouponVM>();
        }
    }
}
