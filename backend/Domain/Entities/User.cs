using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        private Guid _id = Guid.Empty;
        private string _username = string.Empty;
        private string _hashedPassword = string.Empty;
        private string _email = string.Empty;

        public Guid Id { get => _id; set => _id = value; }
        public string Username { get => _username; set => _username = value; }
        public string HashedPassword { get => _hashedPassword; set => _hashedPassword = value; }
        public string Email { get => _email; set => _email = value; }
    }
}
