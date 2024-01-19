using ECommerce.Mango.Services.EmailAPI.Core.Application.Interfaces;
using ECommerce.Mango.Services.EmailAPI.Core.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ECommerce.Mango.Services.EmailAPI.Infrastructure.EmailServices;

public class EmailSender : IEmailSender
{
    private readonly EmailSettings _emailSettings;
    private readonly SendGridClient _client;

    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
        _client = new SendGridClient(apiKey: _emailSettings.ApiKey);
    }

    public async Task<bool> SendEmail(EmailMessage email)
    {
        SendGridMessage message = new()
        {
            From = new(email: _emailSettings.FromAddress, name: _emailSettings.FromName),
            Subject = email.Subject,
            PlainTextContent = email.Body,
            HtmlContent = email.Body
        };

        message.AddTo(email.To);

        var response = await _client.SendEmailAsync(message);

        return response.IsSuccessStatusCode;
    }
}
