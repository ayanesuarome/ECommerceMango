using ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Shared;
using MediatR;

namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Queries.GetCouponDetailsByCode;

public record GetCouponDetailsByCodeQuery(string Code) : IRequest<CouponDetailsDto>
{
}
