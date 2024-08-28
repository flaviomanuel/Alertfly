

using Alertfly.SendAlert.Core.DTOs;
using Alertfly.SendAlert.Core.Interfaces;
using Alertfly.SendAlert.Infrastructure.Services.Jobs;
using Quartz;

namespace Alertfly.SendAlert.Infrastructure.Services.Triggers
{
    public class TaskSendEmailTrigger : ITaskSendEmailTrigger
    {
        private readonly IJobDetail job = JobBuilder.Create<TaskSendEmailJob>()
                .WithIdentity("sendEmail-job", "sendEmail-job-group")
                .Build();

        public void CreateTriggerSendEmail(UserFlightDetailsDTO userFlightDetails)
        {
            JobDataMap fligtDateJobDataMap = new JobDataMap(new Dictionary<string, DateTime>() 
            { 
                {"flightDate", userFlightDetails.FlightDate } 
            });

            var trigger = TriggerBuilder.Create()
                .WithIdentity("sendEmail-trigger", "sendEmail-trigger-group")
                .StartAt(userFlightDetails.AlertAt)
                .UsingJobData("to", userFlightDetails.Email)
                .UsingJobData("name", userFlightDetails.Name)
                .UsingJobData(fligtDateJobDataMap)
                .UsingJobData("origin", userFlightDetails.Origin)
                .UsingJobData("destiny", userFlightDetails.Destiny)
                .ForJob(job)
                .Build();
            
        }
    }
}
