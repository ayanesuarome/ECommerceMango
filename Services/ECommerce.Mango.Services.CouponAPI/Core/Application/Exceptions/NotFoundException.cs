namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Exceptions;

public class NotFoundException(string name, object key) : Exception($"{name} ({key}) not found") { }
