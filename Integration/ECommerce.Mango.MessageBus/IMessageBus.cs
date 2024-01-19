namespace ECommerce.Mango.MessageBus;

public interface IMessageBus
{
    Task PublishMessageAsync(string topicOrQueueName, object message);
}
