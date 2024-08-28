
using Alertfly.SendAlert.Core.DTOs;

namespace Alertfly.SendAlert.Core.Interfaces
{
    public interface ITaskSendEmailTrigger
    {
        void CreateTriggerSendEmail(UserFlightDetailsDTO userFlightDetails);
    }
}
