﻿namespace ECommerce.Mango.Services.AuthAPI.Models;

public class AuthResponse
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Token { get; set; }
}
