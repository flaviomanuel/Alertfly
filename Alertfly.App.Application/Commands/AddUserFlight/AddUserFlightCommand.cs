﻿using MediatR;

namespace Alertfly.App.Application.Commands.AddUserFlight
{
    public class AddUserFlightCommand : IRequest<Unit>
    {
        public AddUserFlightCommand(Guid userId, Guid flightId, DateTime alertAt)
        {

            UserId = userId;
            FlightId = flightId;
            AlertAt = alertAt;
        }

        public DateTime AlertAt { get; private set; }
        public Guid UserId { get; private set; }
        public Guid FlightId { get; private set; }
    }
}
