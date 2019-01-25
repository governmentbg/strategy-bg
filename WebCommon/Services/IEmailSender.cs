using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCommon.Services
{
    public interface IEmailSender
    {
        Task SendMail(string address, string subject, string body);
        Task SendMail(string[] addressList, string subject, string body);
    }
}
