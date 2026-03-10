using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    internal class ConflictUniqueValueException : BusinessException
    {
        public ConflictUniqueValueException()
        {
        }

        public ConflictUniqueValueException(Dictionary<string, List<string>>? errors = null) : base(errors)
        {
           
        }

        public ConflictUniqueValueException(string? message, Dictionary<string, List<string>>? errors = null) : base(message, errors)
        {
           
        }

        public ConflictUniqueValueException(string? message, Exception? innerException, Dictionary<string, List<string>>? errors = null) : base(message, innerException, errors)
        {
           
        }
    }
}
