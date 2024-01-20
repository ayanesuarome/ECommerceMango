using ECommerce.Mango.Services.AuthAPI.Entities;

namespace ECommerce.Mango.Services.AuthAPI.Interfaces;

public interface IJwtTokenGenerator
{
    Task<string> GenerateToken(ApplicationUser user);
}
