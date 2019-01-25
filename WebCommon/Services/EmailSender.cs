using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebCommon.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;

        public EmailSender(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public Task SendMail(string address, string subject, string body)
        {
            return SendMail(new string[] { address }, subject, body);
        }

        public Task SendMail(string[] addressList, string subject, string body)
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
            foreach (var address in addressList)
            {
                mailMessage.Bcc.Add(address);
            }
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = subject;
            try
            {
                return Task.FromResult(client.SendMailAsync(mailMessage));
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}
