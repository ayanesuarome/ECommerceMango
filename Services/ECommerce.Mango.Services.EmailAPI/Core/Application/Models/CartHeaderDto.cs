namespace ECommerce.Mango.Services.EmailAPI.Core.Application.Models;

public class CartHeaderDto
{
    public int CartHeaderDtoId { get; set; }
    public string? UserId { get; set; }
    public string? CouponCode { get; set; }
    public double Discount { get; set; }
    public double CartTotal { get; set; }
    public string? FirstName { get; set; }
    public string? LastNameName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
}