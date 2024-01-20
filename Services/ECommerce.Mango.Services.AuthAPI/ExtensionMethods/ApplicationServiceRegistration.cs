using ECommerce.Mango.Services.AuthAPI.Models;
using ECommerce.Mango.Services.AuthAPI.Validations;
using FluentValidation;

namespace ECommerce.Mango.Services.AuthAPI.ExtensionMethods;

public static class ApplicationServiceRegistration
{
    /// <summary>
    /// Adds and configures FluentValidation services to the service collection.
    /// </summary>
    /// <param name="services">Collection of service descriptors</param>
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddTransient<IValidator<RegistrationRequest>, RegistrationRequestValidator>();

        return services;
    }
}
