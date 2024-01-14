using AutoMapper;
using ECommerce.Mango.Services.CouponAPI.Core.Domain.Entities;
using ECommerce.Mango.Services.CouponAPI.Core.Domain.Interfaces.Persistence;
using MediatR;

namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Queries.GetCouponList;

public class GetCouponListQueryHandler(IMapper mapper, ICouponRepository repository)
    : IRequestHandler<GetCouponListQuery, List<CouponDto>>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICouponRepository _repository = repository;

    public async Task<List<CouponDto>> Handle(GetCouponListQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Coupon> coupons = await _repository.GetAsync();
        return _mapper.Map<List<CouponDto>>(coupons);
    }
}
