using Application.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User?> GetByUsernameOrEmailAsync(string username, string email)
        {
            return Task.FromResult<User?>(null);
        }
    }
}
