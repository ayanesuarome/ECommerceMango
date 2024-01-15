using AutoMapper;
using ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Commands.CreateCoupon;
using ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Queries.GetCouponList;
using ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Shared;
using ECommerce.Mango.Services.CouponAPI.Core.Domain.Entities;

namespace ECommerce.Mango.Services.CouponAPI.Core.Application.MappingProfiles;

public class CouponProfile : Profile
{
    public CouponProfile()
    {
        CreateMap<Coupon, CouponDto>();
        
        CreateMap<CreateCouponCommand, Coupon>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.DateModified, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore());
        
        CreateMap<Coupon, CouponDetailsDto>();
    }
}
