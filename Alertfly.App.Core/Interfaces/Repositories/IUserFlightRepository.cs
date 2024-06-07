using Alertfly.App.Core.Entities;

namespace Alertfly.App.Core.Interfaces.Repositories
{
    public interface IUserFlightRepository
    {

        Task<UserFlight?> GetByIdAsync(Guid id);
        Task<List<UserFlight>?> GetAllAsync();
        Task AddAsync(UserFlight userFlight);
        Task UpdateAsync(UserFlight userFlight);
        Task DeleteAsync(UserFlight userFlight);
    }
}
