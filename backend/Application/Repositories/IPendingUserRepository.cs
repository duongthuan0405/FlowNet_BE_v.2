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
        Task<Guid> AddAsync(PendingUser? pendingUser);
        Task<PendingUser?> GetByUsernameOrEmailAsync(string username, string password);
        Task<PendingUser> UpdateAsync(PendingUser pendingUser);
    }
}
