using Alertfly.SendAlert.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Alertfly.SendAlert.Infrastructure.Services
{
    public class SendEmailService : ISendEmailService
    {
        private string EMAIL_ADDRESS;
        private string PASSWORD;
        private string HOST;
        private int PORT;

        private readonly IConfiguration _configuration;

        public SendEmailService(IConfiguration configuration)
        {
            _configuration = configuration;

            EMAIL_ADDRESS = _configuration["EmailServiceInfos:EmailAdress"];
            PASSWORD = _configuration["EmailServiceInfos:Password"];
            HOST = _configuration["EmailServiceInfos:Host"];
            PORT = int.Parse(_configuration["EmailServiceInfos:Port"]);
        }

        public void SendEmail(string to, string subject, string body)
        {
            using SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = HOST;
            smtpClient.Port = PORT;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(EMAIL_ADDRESS, PASSWORD);

            using var mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(EMAIL_ADDRESS);
            mailMessage.To.Add(new MailAddress(to));
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao enviar Email!" + ex);
            }
        }
    

    }
}
