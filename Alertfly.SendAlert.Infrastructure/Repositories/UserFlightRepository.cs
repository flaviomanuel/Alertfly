using Alertfly.SendAlert.Core.DTOs;
using Alertfly.SendAlert.Core.Interfaces;
using Alertfly.SendAlert.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Alertfly.SendAlert.Infrastructure.Repositories
{
    public class UserFlightRepository : IUserFlightRepository
    {
        private readonly AlertflyContext _context;

        public UserFlightRepository(AlertflyContext context) => _context = context;

        public async Task<UserFlightDetailsDTO?> GetUserFlightDetailsById(Guid userId, Guid flightId)
        {

            var userFlightDetailsDto = await _context.UserFlights
                  .Include(uf => uf.User)
                  .Include(uf => uf.Flight)
                  .Select(uf => new UserFlightDetailsDTO
                  {
                      UserId = uf.UserId,
                      FlightId = uf.FlightId,
                      Name = uf.User.Name,
                      Email = uf.User.Email,
                      PhoneNumber = uf.User.PhoneNumber,
                      FlightTitle = uf.Flight.Title,
                      Origin = uf.Flight.Origin,
                      Destiny = uf.Flight.Destiny,
                      FlightDate = uf.Flight.FlightDate,
                      CreatedAt = uf.CreatedAt,
                      AlertAt = uf.AlertAt
                  }).SingleOrDefaultAsync(x => x.UserId == userId && x.FlightId == flightId);

            return userFlightDetailsDto;
        }
    }
}
