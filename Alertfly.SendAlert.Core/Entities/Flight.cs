namespace Alertfly.SendAlert.Infrastructure;

public class Flight
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Origin { get; set; } = null!;

    public string Destiny { get; set; } = null!;

    public DateTime FlightDate { get; set; }

    public virtual ICollection<UserFlight> UserFlights { get; set; } = new List<UserFlight>();
}
