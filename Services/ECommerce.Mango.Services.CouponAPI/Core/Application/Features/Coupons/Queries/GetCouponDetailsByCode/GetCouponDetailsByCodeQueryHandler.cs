using AutoMapper;
using ECommerce.Mango.Services.CouponAPI.Core.Application.Exceptions;
using ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Shared;
using ECommerce.Mango.Services.CouponAPI.Core.Domain.Entities;
using ECommerce.Mango.Services.CouponAPI.Core.Domain.Interfaces.Persistence;
using MediatR;

namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Queries.GetCouponDetailsByCode;

public class GetCouponDetailsByCodeQueryHandler(IMapper mapper, ICouponRepository repository) : IRequestHandler<GetCouponDetailsByCodeQuery, CouponDetailsDto>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICouponRepository _repository = repository;

    public async Task<CouponDetailsDto> Handle(GetCouponDetailsByCodeQuery request, CancellationToken cancellationToken)
    {
        Coupon coupon = await _repository.GetByCouponAsync(request.Code);

        if(coupon == null)
        {
            throw new NotFoundException(nameof(Coupon), request.Code);
        }

        return _mapper.Map<CouponDetailsDto>(coupon);
    }
}
