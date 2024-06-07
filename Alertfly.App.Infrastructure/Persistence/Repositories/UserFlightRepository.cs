using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Alertfly.App.Infrastructure.Persistence.Repositories
{
    public class UserFlightRepository : IUserFlightRepository
    {
        private readonly AppDbContext _context;
        public UserFlightRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserFlight?> GetByIdAsync(Guid id) => await _context.UserFlights.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<List<UserFlight>?> GetAllAsync() => await _context.UserFlights.ToListAsync();

      
        //BindFlightToUser
        public async Task AddAsync(UserFlight userFlight)
        {
            await _context.AddAsync(userFlight);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserFlight userFlight)
        {
            _context.Remove(userFlight);
            
            await _context.SaveChangesAsync();

        }
        public async Task UpdateAsync(UserFlight userFlight)
        {
            _context.UserFlights.Update(userFlight);

            await _context.SaveChangesAsync();

        }
    }
}
