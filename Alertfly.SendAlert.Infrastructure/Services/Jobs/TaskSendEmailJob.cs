using Alertfly.SendAlert.Core.Interfaces;
using Quartz;

namespace Alertfly.SendAlert.Infrastructure.Services.Jobs
{
    public class TaskSendEmailJob : IJob
    {
        public string Email { private get; set; }
        public string Name { private get; set; }
        public DateTime FlightDate { private get; set; }
        public string Origin { private get; set; }
        public string Destiny { private get; set; }
        public ISendEmailService SendEmailService { private get; set; }

        public Task Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;

            JobDataMap dataMap = context.MergedJobDataMap;

            string body = $"Olá {Name}, tudo bem? \n " +
                $"Lembrete da sua viagem de {Origin} para {Destiny}" +
                $"Data e horario da viagem: {FlightDate} ";

            string subject = $"Lembrete de viagem {Origin} p/ {Destiny}";

            Console.Out.WriteLineAsync("Sended Email!");

            SendEmailService.SendEmail(Email, subject, body);

            return Task.CompletedTask;

        }
    }
}
