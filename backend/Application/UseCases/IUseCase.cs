using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public interface IUseCase<TIn, TOut>
    {
        TIn Execute(TIn input);
    }
}
