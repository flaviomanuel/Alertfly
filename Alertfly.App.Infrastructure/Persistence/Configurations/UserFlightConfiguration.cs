using Alertfly.App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alertfly.App.Infrastructure.Persistence.Configurations
{
    public class UserFlightConfiguration : IEntityTypeConfiguration<UserFlight>
    {
        public void Configure(EntityTypeBuilder<UserFlight> builder)
        {
            
            builder
                .HasKey(x => new {x.UserId, x.FlightId });

            builder
                .HasOne(uf => uf.User)
                .WithMany(u => u.UserFlights)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(uf => uf.Flight)
                .WithMany(f => f.UserFlights)
                .HasForeignKey(uf => uf.FlightId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
