using ECommerce.Mango.Services.AuthAPI.Entities;
using ECommerce.Mango.Services.AuthAPI.Exceptions;
using ECommerce.Mango.Services.AuthAPI.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace ECommerce.Mango.Services.AuthAPI.Services;

public class RoleService : IRoleService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleService(UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<bool> AssignRole(string email, string roleName)
    {
        ApplicationUser user = await _userManager.FindByEmailAsync(email);
        
        if (user == null)
        {
            throw new BadRequestException("Invalid email or role");
        }
        
        bool roleExist = await _roleManager.RoleExistsAsync(roleName);
        
        if (!roleExist)
        {
            throw new BadRequestException("Invalid email or role");
        }

        IdentityResult result = await _userManager.AddToRoleAsync(user, roleName);

        if (!result.Succeeded)
        {
            StringBuilder errors = new();

            foreach (IdentityError error in result.Errors)
            {
                errors.AppendFormat("-{0}\n", error.Description);
            }
            throw new BadRequestException(result.Errors.ToString());
        }

        return true;
    }

    public async Task<bool> CreateRole(string role)
    {
        bool roleExist = await _roleManager.RoleExistsAsync(role);

        if (roleExist)
        {
            throw new BadRequestException("Role already exist");
        }

        IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(role));

        if (!result.Succeeded)
        {
            StringBuilder errors = new();

            foreach (IdentityError error in result.Errors)
            {
                errors.AppendFormat("-{0}\n", error.Description);
            }
            throw new BadRequestException(result.Errors.ToString());
        }

        return true;
    }
}
