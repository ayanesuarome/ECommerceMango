using Azure.Messaging.ServiceBus;
using ECommerce.Mango.Services.EmailAPI.Core.Application.Interfaces;
using ECommerce.Mango.Services.EmailAPI.Core.Application.Models;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.Mango.Services.EmailAPI.Infrastructure.Messagings;

public class AzureServiceBusConsumer : IAzureServiceBusConsumer
{
    private readonly IEmailService _emailService;
    private readonly ServiceBusProcessor _processor;

    public AzureServiceBusConsumer(IConfiguration configuration, IEmailService emailService)
    {
        string serviceBusConnectionString = configuration.GetRequiredSection("ServiceBusSettings")
            .GetValue<string>("ConnectionString");
        string emailShoppingCartQueue = configuration.GetRequiredSection("ServiceBusSettings")
            .GetValue<string>("TopicAndQueueNames:EmailShoppingCartQueue");

        _emailService = emailService;

        ServiceBusClient client = new(serviceBusConnectionString);
        _processor = client.CreateProcessor(emailShoppingCartQueue);
    }

    public async Task Start()
    {
        _processor.ProcessMessageAsync += OnEmailCartRequestReceived;
        _processor.ProcessErrorAsync += ErrorHandler;
        await _processor.StartProcessingAsync();
    }

    public async Task Stop()
    {
        await _processor.StopProcessingAsync();
        await _processor.DisposeAsync();
    }

    private async Task OnEmailCartRequestReceived(ProcessMessageEventArgs args)
    {
        ServiceBusReceivedMessage message = args.Message;
        string body = Encoding.UTF8.GetString(message.Body);
        CartDto objMessage = JsonConvert.DeserializeObject<CartDto>(body);

        try
        {
            // TODO: log email
            await _emailService.EmailCartAndLog(objMessage);
            await args.CompleteMessageAsync(args.Message);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private Task ErrorHandler(ProcessErrorEventArgs args)
    {
        // TODO: log and send email
        Console.WriteLine(args.Exception.ToString());
        return Task.CompletedTask;
    }
}