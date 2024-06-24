using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WebAppPort.Data.IRepository;
using WebAppPort.Entities.MainModel;

namespace WebAppPort.Data.Repository
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;
        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string toAddress, string subject, string body)
        {

            if (String.IsNullOrEmpty(toAddress))
                return;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(toAddress);
                mail.From = new MailAddress($"test1278968@gmail.com");
                mail.Subject = "subject";

                mail.Body = body;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new NetworkCredential("demo.mailer272@gmail.com", "gawf kqzc zupr cogn"); // ***use valid credentials***
                smtp.Credentials = new NetworkCredential("test1278968@gmail.com", "eybt dkwr gesp fvri"); //sakshi credentials
                smtp.Port = 587;

                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
