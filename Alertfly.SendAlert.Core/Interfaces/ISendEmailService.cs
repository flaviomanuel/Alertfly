namespace Alertfly.SendAlert.Core.Interfaces
{
    public interface ISendEmailService
    {
        void SendEmail(string to, string subject, string body);
    }
}
