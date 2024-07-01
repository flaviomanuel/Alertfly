namespace Alertfly.App.Core.Interfaces
{
    public interface IMessageBusService
    {
        void Publish(string queue, byte[] message);
    }
}
