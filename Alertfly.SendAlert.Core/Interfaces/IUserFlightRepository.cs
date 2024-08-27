using Alertfly.SendAlert.Core.DTOs;

namespace Alertfly.SendAlert.Core.Interfaces
{
    public interface IUserFlightRepository
    {
        Task<UserFlightDetailsDTO?> GetUserFlightDetailsById(Guid userId, Guid flightId);

    }
}
