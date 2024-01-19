namespace ECommerce.Mango.Services.EmailAPI.Core.Application.Models;

public class EmailMessage
{
    public string To { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Body { get; set; } = null!;
}
