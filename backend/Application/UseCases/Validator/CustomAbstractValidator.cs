using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Validator
{
    public class CustomAbstractValidator<T> : AbstractValidator<T> where T : class
    {
        public CustomAbstractValidator() : base()
        {

        }

        public async Task<Dictionary<string, List<string>>?> ValidateAndReturnErrorDictionaryAsync(T arg)
        {
            var res = await this.ValidateAsync(arg);
            if(res.IsValid)
            {
                return null;
            }

            var rawResult = res.ToDictionary();
            return rawResult.ToDictionary(rR => rR.Key, rR => rR.Value.ToList());
        }
    }
}
