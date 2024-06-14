using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Alertfly.App.Infrastructure.Persistence.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AppDbContext _context;
        public FlightRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<List<Flight>> GetAllAsync() => _context.Flights.ToListAsync();
        public Task<Flight?> GetByIdAsync(Guid id) => _context.Flights.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Flight> AddAsync(Flight flight)
        {
            await _context.Flights.AddAsync(flight);

            await _context.SaveChangesAsync();

            return flight;
        }
        public async Task<Flight> UpdateAsync(Flight flight)
        {
            _context.Flights.Update(flight);

            await _context.SaveChangesAsync();

            return flight;
        }
        public async Task DeleteAsync(Flight flight)
        {
            _context.Flights.Remove(flight);

            await _context.SaveChangesAsync();
        }

    }
}
