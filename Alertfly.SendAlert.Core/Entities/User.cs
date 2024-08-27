namespace Alertfly.SendAlert.Infrastructure;

public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<UserFlight> UserFlights { get; set; } = new List<UserFlight>();
}
