using AutoMapper;
using ECommerce.Mango.Services.CouponAPI.Core.Domain.Entities;
using ECommerce.Mango.Services.CouponAPI.Core.Domain.Interfaces.Persistence;
using MediatR;

namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Queries.GetCouponDetails;

public class GetCouponDetailsQueryHandler(IMapper mapper, ICouponRepository repository)
    : IRequestHandler<GetCouponDetailsQueryList, CouponDetailsDto>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICouponRepository _repository = repository;

    public async Task<CouponDetailsDto> Handle(GetCouponDetailsQueryList request, CancellationToken cancellationToken)
    {
        Coupon coupon = await _repository.GetByIdAsync(request.Id);

        if (coupon == null)
        {
            // TODO:
            //throw new NotFoundException(nameof(Coupon), request.Id);
        }

        return _mapper.Map<CouponDetailsDto>(coupon);
    }
}
