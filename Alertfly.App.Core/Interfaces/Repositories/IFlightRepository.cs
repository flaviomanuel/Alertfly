using Alertfly.App.Core.Entities;

namespace Alertfly.App.Core.Interfaces.Repositories
{
    public interface IFlightRepository
    {
        Task<Flight?> GetByIdAsync(Guid id);
        Task<List<Flight>> GetAllAsync(Guid id);
        Task<Flight> AddAsync(Flight flight);
        Task<Flight> UpdateAsync(Flight flight);
        Task DeleteAsync(Flight flight);
    }
}
