using MediatR;

namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Queries.GetCouponDetails;

public record GetCouponDetailsQueryList(int Id) : IRequest<CouponDetailsDto>
{
}
