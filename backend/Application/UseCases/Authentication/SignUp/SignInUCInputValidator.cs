using Application.UseCases.Validator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Authentication.SignUp
{
    public class SignUpUCInputValidator : CustomAbstractValidator<SignUpUCInput>
    {
        public SignUpUCInputValidator()
        {
            RuleFor(signUp => signUp.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Username is required");

            RuleFor(signUp => signUp.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("HashedPassword is required.")
                .MinimumLength(6)
                .WithMessage("HashedPassword must have at least 6 characters.");

            RuleFor(signUp => signUp.ConfirmPassword)
                .Must((signUp, confirmPassword) => confirmPassword.Equals(signUp.Password))
                .WithMessage("Confirm HashedPassword is not matched.");

            RuleFor(signUp => signUp.Email)
                .NotEmpty()
                .WithMessage("Email is requires")
                .EmailAddress()
                .WithMessage("Email's format is invalid.");

            RuleFor(signUp => signUp.LastName)
                .NotEmpty()
                .WithMessage("Last name is requires");

            RuleFor(signUp => signUp.FirstName)
                .NotEmpty()
                .WithMessage("First name is requires");

            RuleFor(signUp => signUp.Gender)
                .NotEmpty()
                .WithMessage("Gender is requires");
        }
    }
}
