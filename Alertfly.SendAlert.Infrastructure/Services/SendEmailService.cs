using Alertfly.SendAlert.Core.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Alertfly.SendAlert.Infrastructure.Services
{
    public class SendEmailService : ISendEmailService
    {
     
        public void SendEmail(string to, string subject, string body)
        {
            using SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "localhost";
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("usuario", "senha");

            var mailMessage = CreateMailMessage("meuEmail", to, subject, body);

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao enviar Email!" + ex);
            }
        }
    
        private MailMessage CreateMailMessage(string from, string to, string subject, string body) 
        {
            using MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(from);
            mailMessage.To.Add(new MailAddress(to));
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            return mailMessage;
        }
    }
}
