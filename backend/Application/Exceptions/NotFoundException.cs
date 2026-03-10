using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NotFoundException : BusinessException
    {
        public string TypeOf { get; private set; }
        public NotFoundException(string typeOfNotFound)
        {
            TypeOf = typeOfNotFound;
        }

        public NotFoundException(string typeOfNotFound, Dictionary<string, List<string>>? errors = null) : base($"{typeOfNotFound} not found." , errors)
        {
            TypeOf = typeOfNotFound;
        }

        public NotFoundException(string? message, string typeOfNotFound, Dictionary<string, List<string>>? errors = null) : base(message, errors)
        {
            TypeOf = typeOfNotFound;
        }

        public NotFoundException(string? message, Exception? innerException, string typeOfNotFound, Dictionary<string, List<string>>? errors = null) : base(message, innerException, errors)
        {
            TypeOf = typeOfNotFound;
        }
    }
}
