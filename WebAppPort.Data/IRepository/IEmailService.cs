using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAppPort.Data.IRepository
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toAddress, string subject, string body);
    }
}
