using Alertfly.App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Alertfly.App.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User>Users { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<UserFlight> UserFlights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
