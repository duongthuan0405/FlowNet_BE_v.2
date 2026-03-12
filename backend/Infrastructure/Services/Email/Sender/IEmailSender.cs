using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Email.Sender
{
    internal interface IEmailSender
    {
        Task SendEmailToAsync(EmailMessage message);
    }
}
