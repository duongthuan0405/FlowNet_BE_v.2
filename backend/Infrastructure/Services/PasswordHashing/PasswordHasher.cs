using Application.Services.PasswordHashing;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.PasswordHashing
{
    internal class PasswordHasher : IPasswordHasher
    {
        private static readonly PasswordHasher<string> _hasher = new PasswordHasher<string>();
        public string HashPassword(string username, string password)
        {
            return _hasher.HashPassword(username, password);
        }

        public bool VerifyPassword(string username, string providedPassword, string hashedPassword)
        {
            var result = _hasher.VerifyHashedPassword(username, hashedPassword, providedPassword);

            return result == PasswordVerificationResult.Success
           || result == PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}
