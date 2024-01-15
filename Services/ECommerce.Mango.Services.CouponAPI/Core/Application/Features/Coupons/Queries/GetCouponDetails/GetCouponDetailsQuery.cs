using ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Shared;
using MediatR;

namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Queries.GetCouponDetails;

public record GetCouponDetailsQuery(int Id) : IRequest<CouponDetailsDto> { }
