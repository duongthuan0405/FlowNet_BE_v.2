using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Email
{
    public interface IAuthenticatedEmailSender
    {
        Task SendVerifyEmailOTP(string email, string oTP);
    }
}
