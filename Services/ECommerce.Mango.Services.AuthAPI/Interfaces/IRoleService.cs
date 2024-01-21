namespace ECommerce.Mango.Services.AuthAPI.Interfaces;

public interface IRoleService
{
    Task<bool> AssignRole(string email, string roleName);
    Task<bool> CreateRole(string roleName);
}
