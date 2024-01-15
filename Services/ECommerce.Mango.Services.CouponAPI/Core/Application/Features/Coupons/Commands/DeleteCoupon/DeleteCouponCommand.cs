using MediatR;

namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Commands.DeleteCoupon;

public record DeleteCouponCommand(int Id) : IRequest { }
