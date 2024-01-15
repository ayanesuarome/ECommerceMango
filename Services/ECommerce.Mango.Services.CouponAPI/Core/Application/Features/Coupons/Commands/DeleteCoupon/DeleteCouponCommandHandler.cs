using ECommerce.Mango.Services.CouponAPI.Core.Application.Exceptions;
using ECommerce.Mango.Services.CouponAPI.Core.Domain.Entities;
using ECommerce.Mango.Services.CouponAPI.Core.Domain.Interfaces.Persistence;
using MediatR;

namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Commands.DeleteCoupon;

public class DeleteCouponCommandHandler(ICouponRepository repository) : IRequestHandler<DeleteCouponCommand>
{
    private readonly ICouponRepository _repository = repository;

    public async Task Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
    {
        Coupon coupon = await _repository.GetByIdAsync(request.Id);

        if(coupon == null)
        {
            throw new NotFoundException(nameof(Coupon), request.Id);
        }

        await _repository.DeleteAsync(coupon);
    }
}
