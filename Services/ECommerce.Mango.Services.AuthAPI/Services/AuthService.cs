using ECommerce.Mango.Services.AuthAPI.Entities;
using ECommerce.Mango.Services.AuthAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Text;

namespace ECommerce.Mango.Services.AuthAPI.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityUser> _roleManager;
    private readonly JwtSettings _jwtSettings;

    public AuthService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityUser> roleManager,
        IOptions<JwtSettings> options)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _jwtSettings = options.Value;
    }

    public Task<AuthResponse> Login(AuthRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<RegistrationResponse> Register(RegistrationRequest request)
    {
        ApplicationUser user = new()
        {
            Email = request.Email,
            NormalizedEmail = request.Email.ToUpper(),
            UserName = request.Email,
            NormalizedUserName = request.Email.ToUpper(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
        };

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            StringBuilder errors = new();

            foreach (IdentityError error in result.Errors)
            {
                errors.AppendFormat("-{0}\n", error.Description);
            }

            throw new BadRequestException(result.Errors.ToString());
        }
    }
}
