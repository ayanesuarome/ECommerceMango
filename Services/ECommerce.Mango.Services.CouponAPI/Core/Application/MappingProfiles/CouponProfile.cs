using AutoMapper;
using ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Queries.GetCouponDetails;
using ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Queries.GetCouponList;
using ECommerce.Mango.Services.CouponAPI.Core.Domain.Entities;

namespace ECommerce.Mango.Services.CouponAPI.Core.Application.MappingProfiles;

public class CouponProfile : Profile
{
    public CouponProfile()
    {
        CreateMap<Coupon, CouponDto>();
        CreateMap<Coupon, CouponDetailsDto>();
    }
}
