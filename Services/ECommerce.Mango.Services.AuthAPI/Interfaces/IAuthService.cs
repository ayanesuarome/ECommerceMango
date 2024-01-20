using ECommerce.Mango.Services.AuthAPI.Models;

namespace ECommerce.Mango.Services.AuthAPI.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}
