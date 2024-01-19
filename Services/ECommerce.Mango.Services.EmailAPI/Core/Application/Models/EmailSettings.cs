namespace ECommerce.Mango.Services.EmailAPI.Core.Application.Models;

public class EmailSettings
{
    public string ApiKey { get; set; } = null!;
    public string FromAddress { get; set; } = null!;
    public string FromName { get; set; } = null!;
}
