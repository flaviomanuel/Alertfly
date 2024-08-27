using Microsoft.EntityFrameworkCore;

namespace Alertfly.SendAlert.Infrastructure.Persistence;

public class AlertflyContext : DbContext
{
    public AlertflyContext()
    {
    }

    public AlertflyContext(DbContextOptions<AlertflyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFlight> UserFlights { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<UserFlight>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.FlightId });

            entity.HasIndex(e => e.FlightId, "IX_UserFlights_FlightId");

            entity.HasOne(d => d.Flight).WithMany(p => p.UserFlights)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.UserFlights)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    public void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
