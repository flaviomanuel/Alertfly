using Alertfly.SendAlert.Core.Interfaces;
using Quartz;

namespace Alertfly.SendAlert.Infrastructure.Services.Jobs
{
    public class TaskSchedulerJob : IJob
    {
        public string To { private get; set; }
        public string Subject { private get; set; }
        public string Body { private get; set; }


        private readonly ISendEmailService _sendEmailService;
        public TaskSchedulerJob(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;

            JobDataMap dataMap = context.MergedJobDataMap;


            _sendEmailService.SendEmail(To, Subject, Body);

            await Console.Out.WriteLineAsync("Sended Email!");
        }
    }
}
