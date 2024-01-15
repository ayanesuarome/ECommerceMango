using FluentValidation;

namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Commands.CreateCoupon
{
    public class CreateCouponCommandValidator : AbstractValidator<CreateCouponCommand>
    {
        public CreateCouponCommandValidator()
        {
            RuleFor(m => m.CouponCode)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}
