using IdServer.Models.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace IdServer.Models.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;

        public EmailSender(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public void SendMail(string address, string subject, string body)
        {

            SmtpClient client = new SmtpClient(configuration.GetSection("EmailService").GetValue<string>("server"));
            var emailUser = configuration.GetSection("EmailService").GetValue<string>("user");
            var emailPass = configuration.GetSection("EmailService").GetValue<string>("pass");
            if (!string.IsNullOrEmpty(emailUser))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(emailUser, emailPass);
            }
            else
            {
                client.UseDefaultCredentials = true;
            };

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(configuration.GetSection("EmailService").GetValue<string>("mailbox"));
            mailMessage.To.Add(address);
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = subject;
            try
            {
                client.Send(mailMessage);
            }
            catch (Exception ex) { }
        }
    }
}
