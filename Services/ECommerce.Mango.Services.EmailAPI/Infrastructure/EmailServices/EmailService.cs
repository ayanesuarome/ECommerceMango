using ECommerce.Mango.Services.EmailAPI.Core.Application.Interfaces;
using ECommerce.Mango.Services.EmailAPI.Core.Application.Models;
using ECommerce.Mango.Services.EmailAPI.Core.Domain.Entities;
using ECommerce.Mango.Services.EmailAPI.Core.Domain.Interfaces;
using System.Text;

namespace ECommerce.Mango.Services.EmailAPI.Infrastructure.EmailServices;

public class EmailService(IEmailSender emailSender, IEmailRepository repository) : IEmailService
{
    private readonly IEmailSender _emailSender = emailSender;
    private readonly IEmailRepository _repository = repository;

    public async Task EmailCartAndLog(CartDto cart)
    {
        ArgumentNullException.ThrowIfNull(cart);

        string message = PrepareEmailTemplate(cart);

        EmailMessage emailMessage = new()
        {
            To = cart.CartHeader.Email,
            Subject = "Mango System - Your Shopping Cart",
            Body = message
        };

        bool emailSent = await _emailSender.SendEmail(emailMessage);

        EmailLogger emailLog = new()
        {
            Email = cart.CartHeader.Email,
            EmailSent = emailSent ? DateTime.Now : null,
            Sent = emailSent,
            Message = message
        };

        await _repository.InsertEmailAsync(emailLog);
    }

    private string PrepareEmailTemplate(CartDto cart)
    {
        // TODO: implement Builder pattern to use helper html components
        StringBuilder message = new();
        message.AppendLine("<br />");
        message.AppendLine("Cart Email Requested");
        message.AppendLine("<br />");
        message.AppendLine($"Total {cart.CartHeader.CartTotal}");
        message.AppendLine("<br />");
        message.AppendLine("<ul>");
        
        foreach (CartDetailsDto item in cart.CartDetails)
        {
            message.AppendLine("<li>");
            message.AppendLine($"{item.Product?.Name} x {item.Count}");
            message.AppendLine("</li>");
        }
        
        message.AppendLine("</ul>");

        return message.ToString();
    }
}
