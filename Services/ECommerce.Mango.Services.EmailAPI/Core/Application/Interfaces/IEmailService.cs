using ECommerce.Mango.Services.EmailAPI.Core.Application.Models;

namespace ECommerce.Mango.Services.EmailAPI.Core.Application.Interfaces;

public interface IEmailService
{
    Task EmailCartAndLog(CartDto cartDto);
}
