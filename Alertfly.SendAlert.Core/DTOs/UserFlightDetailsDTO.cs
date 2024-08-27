namespace Alertfly.SendAlert.Core.DTOs
{
    public class UserFlightDetailsDTO
    {
        public Guid UserId { get; set; }
        public Guid FlightId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string FlightTitle { get; set; }
        public string Origin { get; set; }
        public string Destiny { get; set; }
        public DateTime FlightDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime AlertAt { get; set; }

    }
}
