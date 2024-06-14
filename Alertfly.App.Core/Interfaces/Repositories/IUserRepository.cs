using Alertfly.App.Core.Entities;

namespace Alertfly.App.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<List<User>> GetAllAsync();
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task DeleteByIdAsync(User user);
    }
}
