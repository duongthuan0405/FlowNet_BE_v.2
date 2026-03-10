using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class BadInputException : BusinessException
    {
        public BadInputException()
        {
        }

        public BadInputException(Dictionary<string, List<string>>? errors = null) : base("Input is invalid", errors)
        {
        }

        public BadInputException(string? message, Dictionary<string, List<string>>? errors = null) : base(message, errors)
        {
        }

        public BadInputException(string? message, Exception? innerException, Dictionary<string, List<string>>? errors = null) : base(message, innerException, errors)
        {
        }
    }
}
