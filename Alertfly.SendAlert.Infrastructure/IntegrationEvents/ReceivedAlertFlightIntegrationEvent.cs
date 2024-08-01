using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alertfly.SendAlert.Infrastructure.IntegrationEvents
{
    public class ReceivedAlertFlightIntegrationEvent
    {
        public ReceivedAlertFlightIntegrationEvent(Guid id, Guid userId, Guid flightId, DateTime alertAt, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            FlightId = flightId;
            AlertAt = alertAt;
            CreatedAt = createdAt;
        }

        public Guid Id { get; private set; }
        public DateTime AlertAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid UserId { get; private set; }
        public Guid FlightId { get; private set; }
    }
}
