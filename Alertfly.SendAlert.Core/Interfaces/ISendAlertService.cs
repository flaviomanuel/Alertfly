using Alertfly.SendAlert.Core.DTOs;

namespace Alertfly.SendAlert.Core.Interfaces
{
    public interface ISendAlertService
    {
        Task SendAlertWithEmailAsync(Guid userId, Guid flightId);
    }
}
