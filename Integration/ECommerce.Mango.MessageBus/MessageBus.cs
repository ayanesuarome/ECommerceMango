using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.Mango.MessageBus;

public class MessageBus(string connectionString) : IMessageBus
{
    private readonly string connectionString = connectionString;

    public async Task PublishMessageAsync(string topicOrQueueName, object message)
    {
        await using ServiceBusClient client = new(connectionString);

        ServiceBusSender sender = client.CreateSender(topicOrQueueName);
        string jsonMessage = JsonConvert.SerializeObject(message);
        ServiceBusMessage busMessage = new(Encoding.UTF8.GetBytes(jsonMessage))
        {
            CorrelationId = Guid.NewGuid().ToString()
        };

        await sender.SendMessageAsync(busMessage);
        await sender.DisposeAsync();
    }
}
