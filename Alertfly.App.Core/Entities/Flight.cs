namespace Alertfly.App.Core.Entities
{
    public class Flight : IEntityBase
    {
        public Flight(string title, string origin, string destiny, DateTime flightDate)
        {
            Id = Guid.NewGuid();
            Title = title;
            Origin = origin;
            Destiny = destiny;
            FlightDate = flightDate;
        }
        public Guid Id {  get; private set; }
        public string Title { get; private set; }
        public string Origin { get; private set; }
        public string Destiny { get; private set; }
        public DateTime FlightDate { get; private set; }

        public List<UserFlight>? UserFlights { get; private set; }


    }
}
