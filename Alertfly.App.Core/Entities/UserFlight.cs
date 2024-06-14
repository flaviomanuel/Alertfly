
namespace Alertfly.App.Core.Entities
{
    public class UserFlight : IEntityBase
    {
        public UserFlight(Guid userId, Guid flightId, DateTime alertAt)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            FlightId = flightId;
            AlertAt = alertAt;
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime AlertAt { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Guid UserId { get; private set; }
        public User? User { get; private set; }

        public Guid FlightId { get; private set; }
        public Flight? Flight { get; private set; }


        public void UpdateAlertAt(DateTime alertAt) 
        { 
            AlertAt = alertAt;
        }


    }
}
