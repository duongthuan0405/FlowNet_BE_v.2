using Application.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class PendingUserRepository : IPendingUserRepository
    {
        public Task<Guid> AddAsync(PendingUser? pendingUser)
        {
            return Task.FromResult(Guid.NewGuid());
        }

        public Task<PendingUser?> GetByUsernameOrEmailAsync(string username, string password)
        {
            return Task.FromResult<PendingUser?>(null);
        }

        public Task UpdateAsync(PendingUser pendingUser)
        {
            return Task.CompletedTask;
        }
    }
}
