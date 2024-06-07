using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Alertfly.App.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<User?> GetByIdAsync(Guid id) => _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        public Task<List<User>> GetAllAsync(Guid id) => _context.Users.ToListAsync();
        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);

            await _context.SaveChangesAsync();

            return user;
        }
        public async Task DeleteByIdAsync(User user)
        {
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }

    }
}
