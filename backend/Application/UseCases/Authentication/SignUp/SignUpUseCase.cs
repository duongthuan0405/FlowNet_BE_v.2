
using Application.Exceptions;
using Application.Repositories;
using Domain.Entities;
using Application.Services.VerifyEmailOTPGeneration;
using Application.Services.Hashing;
using Application.Services.PasswordHashing;
using Application.Transaction;
using Application.Services.Email;

namespace Application.UseCases.Authentication.SignUp
{
    public class SignUpUseCase : ISignUpUseCase
    {
        private readonly SignUpUCInputValidator _validator;
        private readonly IUserRepository _userRepository;
        private readonly IPendingUserRepository _pendingUserRepository;
        private readonly IVerifyEmailOTPGenerator _verifyEmailOTPGenerator;
        private readonly IHasher _hasher;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticatedEmailSender _authenticatedEmailSender;

        public SignUpUseCase(
            SignUpUCInputValidator validator, 
            IUserRepository userRepository, 
            IPendingUserRepository pendingUserRepository, 
            IVerifyEmailOTPGenerator verifyEmailOTPGenerator,
            IHasher hasher, 
            IPasswordHasher passwordHasher, 
            IUnitOfWork unitOfWork,
            IAuthenticatedEmailSender authenticatedEmailSender)
        {
            _validator = validator;
            _userRepository = userRepository;
            _pendingUserRepository = pendingUserRepository;
            _verifyEmailOTPGenerator = verifyEmailOTPGenerator;
            _hasher = hasher;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
            _authenticatedEmailSender = authenticatedEmailSender;
        }

        public async Task<SignUpUCOutput> ExecuteAsync(SignUpUCInput input)
        {
            var validateResult = await _validator.ValidateAndReturnErrorDictionaryAsync(input);
            if (validateResult != null) {
                throw new BadInputException(validateResult);
            }

            User? user = await _userRepository.GetByUsernameOrEmailAsync(input.Username, input.Email);

            if(user != null)
            {
                if(user.Email == input.Email || user.Username == input.Username)
                {
                    throw new ConflictUniqueValueException("Username or Email has already been used.");
                }
            }

            PendingUser? pendingUser = await _pendingUserRepository.GetByUsernameOrEmailAsync(input.Username, input.Password);
            VerifyEmailOTPGenerationResult otpResult = _verifyEmailOTPGenerator.Generate();
            try
            {
                await _unitOfWork.BeginAsync();
                if (pendingUser != null)
                {
                    pendingUser.HashedVerifyEmailOTP = _hasher.Hash(otpResult.OTP, StringType.UTF8);
                    pendingUser.OtpVerifyEmailExpiredAt = otpResult.ExpiredAt;
                    pendingUser.Username = input.Username;
                    pendingUser.Email = input.Email;
                    pendingUser.HashedPassword = _passwordHasher.HashPassword(input.Username, input.Password);
                    pendingUser.LastName = input.LastName;
                    pendingUser.FirstName = input.FirstName;
                    pendingUser.Gender = input.Gender;
                    pendingUser.DateOfBirth = input.DateOfBirth;

                    await _pendingUserRepository.UpdateAsync(pendingUser);
                    await _authenticatedEmailSender.SendVerifyEmailOTP(input.Email, otpResult.OTP);
                    return new SignUpUCOutput() { VerifyEmailOTPExpiredAt = otpResult.ExpiredAt };
                }

                pendingUser = new PendingUser()
                {
                    Id = Guid.NewGuid(),
                    Username = input.Username,
                    Email = input.Email,
                    HashedPassword = _passwordHasher.HashPassword(input.Username, input.Password),
                    HashedVerifyEmailOTP = _hasher.Hash(otpResult.OTP, StringType.UTF8),
                    LastName = input.LastName,
                    FirstName = input.FirstName,
                    Gender = input.Gender,
                    DateOfBirth = input.DateOfBirth,
                    OtpVerifyEmailExpiredAt = otpResult.ExpiredAt


                };

                await _pendingUserRepository.AddAsync(pendingUser);
                await _authenticatedEmailSender.SendVerifyEmailOTP(pendingUser.Email, otpResult.OTP);
                return new SignUpUCOutput() { VerifyEmailOTPExpiredAt = otpResult.ExpiredAt };
            }
            catch(Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await _unitOfWork.FinishAsync();
            }
        }
    }
}
