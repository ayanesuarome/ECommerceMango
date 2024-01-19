using System.ComponentModel.DataAnnotations;

namespace ECommerce.Mango.Services.EmailAPI.Core.Application.Models;

public class ProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string ImageUrl { get; set; }
    public int Count { get; set; }
}
