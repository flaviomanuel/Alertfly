

using Alertfly.SendAlert.Core.DTOs;
using Alertfly.SendAlert.Core.Interfaces;
using Alertfly.SendAlert.Infrastructure.Services.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;

namespace Alertfly.SendAlert.Infrastructure.Services.Triggers
{
    public class TaskSendEmailTrigger : ITaskSendEmailTrigger
    {
        private readonly ISendEmailService _sendEmailService;

        public TaskSendEmailTrigger(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }



        public async Task CreateTriggerSendEmailAsync(UserFlightDetailsDTO userFlightDetails)
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler _scheduler = await factory.GetScheduler();


            await _scheduler.Start();


            IJobDetail job = JobBuilder.Create<TaskSendEmailJob>()
                 .WithIdentity("sendEmail-job", "sendEmail-job-group")
                 .Build();

            JobDataMap fligtDateJobDataMap = new JobDataMap(new Dictionary<string, DateTime>()
            {
                {"flightDate", userFlightDetails.FlightDate }
            });

            JobDataMap sendEmailServiceDataMap = new JobDataMap(new Dictionary<string, ISendEmailService>()
            {
                {"sendEmailService", _sendEmailService }
            });


            var trigger = TriggerBuilder.Create()
                .WithIdentity("sendEmail-trigger", "sendEmail-trigger-group")
                .StartAt(userFlightDetails.AlertAt)
                .UsingJobData("email", userFlightDetails.Email)
                .UsingJobData("name", userFlightDetails.Name)
                .UsingJobData(fligtDateJobDataMap)
                .UsingJobData("origin", userFlightDetails.Origin)
                .UsingJobData("destiny", userFlightDetails.Destiny)
                .UsingJobData(sendEmailServiceDataMap)
                .ForJob("sendEmail-job", "sendEmail-job-group")
                .Build();

            await _scheduler.ScheduleJob(job, trigger);


        }
    }
}
