using AutoMapper;
using ECommerce.Mango.Services.CouponAPI.Core.Application.Exceptions;
using ECommerce.Mango.Services.CouponAPI.Core.Domain.Entities;
using ECommerce.Mango.Services.CouponAPI.Core.Domain.Interfaces.Persistence;
using FluentValidation.Results;
using MediatR;

namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Commands.CreateCoupon;

public class CreateCouponCommandHandler(IMapper mapper, ICouponRepository repository)
    : IRequestHandler<CreateCouponCommand, int>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICouponRepository _repository = repository;

    public async Task<int> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
    {
        CreateCouponCommandValidator validator = new();
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if(!validationResult.IsValid)
        {
            throw new BadRequestException($"Invalid {nameof(Coupon)}", validationResult);
        }

        Coupon coupon = _mapper.Map<Coupon>(request);

        await _repository.CreateAsync(coupon);

        return coupon.Id;
    }
}
