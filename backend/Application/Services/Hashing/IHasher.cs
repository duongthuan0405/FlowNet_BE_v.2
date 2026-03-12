
namespace Application.Services.Hashing
{
    public interface IHasher
    {
        string Hash(string stringNeedToBeHashed, StringType type = StringType.UTF8);

    }
}
