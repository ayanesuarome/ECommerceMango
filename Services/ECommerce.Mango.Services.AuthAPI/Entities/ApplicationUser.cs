using Microsoft.AspNetCore.Identity;

namespace ECommerce.Mango.Services.AuthAPI.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
