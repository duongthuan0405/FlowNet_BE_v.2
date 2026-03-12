using Application.Services.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Email.Authentication
{
    public class AuthenticatedEmailSender : IAuthenticatedEmailSender
    {
        public Task SendVerifyEmailOTP(string email, string otp)
        {
            throw new NotImplementedException();
        }
    }
}
