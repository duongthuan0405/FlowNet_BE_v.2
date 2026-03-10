using Application.UseCases.Authentication.SignUp;

namespace Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var s = new SignUpUCInput()
            {

            };

            SignUpUCInputValidator validationRules = new SignUpUCInputValidator();
            var res =  await validationRules.ValidateAndReturnErrorDictionaryAsync(s);
            if(res == null)
            {
                return;
            }
            foreach(var kvp in res)
            {
                Console.WriteLine(kvp.Key);
                foreach(string er in kvp.Value)
                {
                    Console.WriteLine(er);
                }
            }
        }
    }
}
