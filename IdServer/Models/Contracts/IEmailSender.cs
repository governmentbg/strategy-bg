using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdServer.Models.Contracts
{
    public interface IEmailSender
    {
        void SendMail(string address, string subject, string body);
    }
}
