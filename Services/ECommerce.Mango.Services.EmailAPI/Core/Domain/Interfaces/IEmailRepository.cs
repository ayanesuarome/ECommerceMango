using ECommerce.Mango.Services.EmailAPI.Core.Domain.Entities;
using System.Reflection.Metadata;

namespace ECommerce.Mango.Services.EmailAPI.Core.Domain.Interfaces;

public interface IEmailRepository
{
    Task InsertEmailAsync(EmailLogger email);
    Task<EmailLogger> LoadEmailAsync(string uid);
}
