using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.VerifyEmailOTPGeneration
{
    public class VerifyEmailOTPGenerationResult
    {
        public string OTP { get; set; }
        public DateTimeOffset ExpiredAt { get; set; }

        public VerifyEmailOTPGenerationResult(string otp, DateTimeOffset expireAt)
        {
            OTP = otp;
            ExpiredAt = expireAt;
        }
    }
}
