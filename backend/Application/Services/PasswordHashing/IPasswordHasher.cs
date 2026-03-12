using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PasswordHashing
{
    public interface IPasswordHasher
    {
        string HashPassword(string username, string password);
        public bool VerifyPassword(string username, string providedPassword, string hashedPassword);
    }
}
