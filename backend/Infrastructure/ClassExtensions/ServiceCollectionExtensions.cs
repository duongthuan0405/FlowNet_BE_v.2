using Application.Repositories;
using Application.Services.Email;
using Application.Services.Hashing;
using Application.Services.PasswordHashing;
using Application.Services.VerifyEmailOTPGeneration;
using Application.UseCases.Authentication.SignUp;
using Infrastructure.Repositories;
using Infrastructure.Services.Email.Authentication;
using Infrastructure.Services.Email.Sender;
using Infrastructure.Services.Hashing;
using Infrastructure.Services.PasswordHashing;
using Infrastructure.Services.VerifyEmailOTPGeneration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ClassExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDI(this IServiceCollection services, IConfiguration configuration)
        {
            AddApplicationServices(services);
            AddApplicationRepositories(services);
            AddApplicationDatabase(services, configuration);
            AddConfigurationOptions(services, configuration);
            return services;
        }

        private static void AddConfigurationOptions(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailCO>(configuration.GetSection("EMAIL"));
            services.Configure<OtpCO>(configuration.GetSection("OTP"));
        }

        private static void AddApplicationDatabase(IServiceCollection services, IConfiguration configuration)
        {
            
        }

        private static void AddApplicationRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPendingUserRepository, PendingUserRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();    

        }

        private static void AddApplicationServices(IServiceCollection services)
        {
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddSingleton<IHasher, SHA256Hasher>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IVerifyEmailOTPGenerator, VerifyEmailOTPGenerator>();
            services.AddSingleton<IAuthenticatedEmailSender, AuthenticatedEmailSender>();
        }
    }
}
