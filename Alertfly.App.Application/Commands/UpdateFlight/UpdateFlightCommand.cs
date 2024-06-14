using MediatR;

namespace Alertfly.App.Application.Commands.UpdateFlight
{
    public class UpdateFlightCommand : IRequest<Unit>
    {
        public UpdateFlightCommand(Guid id, string title, string origin, string destiny, DateTime flightDate)
        {
            Id = id;
            Title = title;
            Origin = origin;
            Destiny = destiny;
            FlightDate = flightDate;
        }
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Origin { get; private set; }
        public string Destiny { get; private set; }
        public DateTime FlightDate { get; private set; }

    }
}
