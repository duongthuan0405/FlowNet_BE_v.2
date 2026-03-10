using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PendingUser
    {
        private Guid _id = Guid.Empty;
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _email = string.Empty;
        private string _lastName = string.Empty;
        private string _firstName = string.Empty;
        private DateTimeOffset _dateOfBirth = DateTimeOffset.UtcNow;
        private Gender _gender = Gender.Other;

        private string _hashedVerifyEmailOTP = string.Empty;
        private DateTimeOffset _otpVerifyEmailExpiredAt = DateTimeOffset.UtcNow;

        public Guid Id { get => _id; set => _id = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Email { get => _email; set => _email = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public DateTimeOffset DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public Gender Gender { get => _gender; set => _gender = value; }
        public string HashedVerifyEmailOTP { get => _hashedVerifyEmailOTP; set => _hashedVerifyEmailOTP = value; }
        public DateTimeOffset OtpVerifyEmailExpiredAt { get => _otpVerifyEmailExpiredAt; set => _otpVerifyEmailExpiredAt = value; }
    }
}
