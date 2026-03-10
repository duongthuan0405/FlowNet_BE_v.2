using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Transaction
{
    public interface IUnitOfWork
    {
        Task BeginAsync();
        Task FinishAsync();
        Task RollbackAsync();
    }
}
