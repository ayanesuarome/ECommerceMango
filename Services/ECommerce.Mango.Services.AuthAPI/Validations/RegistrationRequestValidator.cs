using ECommerce.Mango.Services.AuthAPI.Models;
using FluentValidation;

namespace ECommerce.Mango.Services.AuthAPI.Validations
{
    public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
    {
        public RegistrationRequestValidator()
        {
            RuleFor(m => m.FirstName)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(m => m.LastName)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(m => m.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .EmailAddress()
                .WithMessage("{PropertyName} invalid");
        }
    }
}
