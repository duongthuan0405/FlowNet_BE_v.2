using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class BusinessException : Exception
    {
        public Dictionary<string, List<string>> Errors { get; private set; }

        public BusinessException()
        {
            Errors = new();
        }

        public BusinessException(Dictionary<string, List<string>>? errors = null)
        {
            Errors = errors ?? new();
        }

        public BusinessException(string? message, Dictionary<string, List<string>>? errors = null) : base(message)
        {
            Errors = errors ?? new();
        }

        public BusinessException(string? message, Exception? innerException, Dictionary<string, List<string>>? errors = null) : base(message, innerException)
        {
            Errors = errors ?? new();
        }
    }
}
