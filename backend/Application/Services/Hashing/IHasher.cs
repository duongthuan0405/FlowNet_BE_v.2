using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Hashing
{
    public interface IHasher
    {
        string Hash(string stringNeedToBeHashed, StringType type = StringType.UTF8);

    }
}
