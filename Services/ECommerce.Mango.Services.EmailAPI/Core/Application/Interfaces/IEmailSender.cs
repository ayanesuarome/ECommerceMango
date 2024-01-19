using ECommerce.Mango.Services.EmailAPI.Core.Application.Models;
using ECommerce.Mango.Services.EmailAPI.Core.Domain.Entities;
using System.Reflection.Metadata;

namespace ECommerce.Mango.Services.EmailAPI.Core.Application.Interfaces;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}
