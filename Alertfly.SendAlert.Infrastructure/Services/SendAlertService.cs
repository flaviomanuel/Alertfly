using Alertfly.SendAlert.Core.DTOs;
using Alertfly.SendAlert.Core.Interfaces;

namespace Alertfly.SendAlert.Infrastructure.Services
{
    public class SendAlertService : ISendAlertService
    {
        private readonly IUserFlightRepository _userFlightRepository;
        private readonly ITaskSendEmailTrigger _taskSendEmailTrigger;
        public SendAlertService(IUserFlightRepository userFlightRepository, ITaskSendEmailTrigger taskSendEmailTrigger)
        {
            _userFlightRepository = userFlightRepository;
            _taskSendEmailTrigger = taskSendEmailTrigger;
        }
        public async Task SendAlertWithEmailAsync(UserFlightDetailsDTO userFlightDetails)
        {

            var userFlightDetailsDto = await _userFlightRepository.GetUserFlightDetailsByIdAsync(userFlightDetails.UserId, userFlightDetails.FlightId);

            if (userFlightDetailsDto is null) {
                throw new Exception("Informações do voo e do usuário não encontradas! ");
            }

            _taskSendEmailTrigger.CreateTriggerSendEmail(userFlightDetails);

        }
    }
}
