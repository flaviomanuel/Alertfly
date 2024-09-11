
using Alertfly.SendAlert.Core.DTOs;

namespace Alertfly.SendAlert.Core.Interfaces
{
    public interface ITaskSendEmailTrigger
    {
        Task CreateTriggerSendEmailAsync(UserFlightDetailsDTO userFlightDetails);
    }
}
