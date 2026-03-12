using Application.Services.Hashing;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Hashing
{
    public class SHA256Hasher : IHasher
    {
        public string Hash(string stringNeedToBeHashed, StringType type = StringType.UTF8)
        {
            try
            {
                using var sha256 = SHA256.Create();

                byte[] bytes = null!;
                switch (type)
                {
                    case StringType.Base64String:
                        bytes = Convert.FromBase64String(stringNeedToBeHashed);
                        break;
                    case StringType.Base64URL:
                        bytes = WebEncoders.Base64UrlDecode(stringNeedToBeHashed);
                        break;
                    default:
                        bytes = Encoding.UTF8.GetBytes(stringNeedToBeHashed);
                        break;
                }

                byte[] hashedOTPBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashedOTPBytes);
            }
            catch
            {
                return "";
            }
        }
    }
}
