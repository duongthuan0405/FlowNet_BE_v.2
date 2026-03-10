using Application.UseCases.Validator;
using Domain.Enums;
using FluentValidation;
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
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.Other;
        public DateTimeOffset DateOfBirth { get; set; } = DateTimeOffset.UtcNow; 

    }

    public class SignUpUCOutput
    {
        public DateTimeOffset VerifyEmailOTPExpiredAt { get; set; } = DateTimeOffset.UtcNow;
    }

   
}
