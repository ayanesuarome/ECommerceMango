using MediatR;

namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Queries.GetCouponList;

public record GetCouponListQuery : IRequest<List<CouponDto>>
{
}
