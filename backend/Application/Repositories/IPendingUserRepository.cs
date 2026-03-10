using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IPendingUserRepository
    {
        Task AddAsync(PendingUser? pendingUser);
        Task<PendingUser?> GetByUsernameOrEmailAsync(string username, string password);
        Task UpdateAsync(PendingUser pendingUser);
    }
}
