using ECommerce.Mango.Services.AuthAPI.Entities;
using ECommerce.Mango.Services.AuthAPI.Exceptions;
using ECommerce.Mango.Services.AuthAPI.Interfaces;
using ECommerce.Mango.Services.AuthAPI.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Text;

namespace ECommerce.Mango.Services.AuthAPI.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IValidator<RegistrationRequest> _registrationValidator;
    private readonly JwtSettings _jwtSettings;

    public AuthService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IJwtTokenGenerator jwtTokenGenerator,
        IValidator<RegistrationRequest> registrationValidator,
        IOptions<JwtSettings> options)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenGenerator = jwtTokenGenerator;
        _registrationValidator = registrationValidator;
        _jwtSettings = options.Value;
    }

    public async Task<AuthResponse> Login(AuthRequest request)
    {
        ApplicationUser user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            throw new BadRequestException("Invalid email or password");
        }

        SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if(!result.Succeeded)
        {
            throw new BadRequestException("Invalid email or password");
        }

        string securityToken = await _jwtTokenGenerator.GenerateToken(user);

        return new AuthResponse
        {
            Email = user.Email,
            FirstName = user.FirstName,
            PhoneNumber = user.PhoneNumber,
            Token = securityToken
        };
    }

    public async Task<RegistrationResponse> Register(RegistrationRequest request)
    {
        ValidationResult validationResult = await _registrationValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Invalid registration", validationResult);
        }

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

        await _userManager.AddToRoleAsync(user, "Customer");

        return new RegistrationResponse(user.Id);
    }
}
