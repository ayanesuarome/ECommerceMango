namespace ECommerce.Mango.Services.EmailAPI.Core.Domain.Entities;

public class EmailLogger
{
    /// <summary>
    /// Partition key.
    /// </summary>
    public string Uid { get; set; } = null!;
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string Message { get; set; } = null!;
    public DateTime? EmailSent { get; set; }
    public bool Sent { get; set; }
}
