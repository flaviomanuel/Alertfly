namespace Alertfly.App.Core.Interfaces
{
    public interface IMessageBusService
    {
        void Publish(object message, string queue, string routingKey, string exchange);
    }
}
