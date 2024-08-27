namespace Alertfly.SendAlert.Infrastructure;

public class UserFlight
{
    public Guid UserId { get; set; }

    public Guid FlightId { get; set; }

    public Guid Id { get; set; }

    public DateTime AlertAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Flight Flight { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
