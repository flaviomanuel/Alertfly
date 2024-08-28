using Alertfly.SendAlert.Core.DTOs;

namespace Alertfly.SendAlert.Core.Interfaces
{
    public interface IUserFlightRepository
    {
        Task<UserFlightDetailsDTO?> GetUserFlightDetailsByIdAsync(Guid userId, Guid flightId);

    }
}
