using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Authentication.SignUp
{
    public class SignUpUCOutput
    {
        public DateTimeOffset VerifyEmailOTPExpiredAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
