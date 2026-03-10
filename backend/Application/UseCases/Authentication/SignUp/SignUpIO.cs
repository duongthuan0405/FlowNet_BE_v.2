using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Authentication.SignUp
{
    public class SignUpUCInput
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    public class SignUpUCOutput
    {
        public DateTimeOffset VerifyEmailOTPExpiredAt = DateTimeOffset.UtcNow;
    }
}
