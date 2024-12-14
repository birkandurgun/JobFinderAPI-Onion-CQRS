namespace JobFinderAPI.Application.Interfaces.Services
{
    public interface IPasswordHasher
    {
        string Hash(string password, string salt);
        string CreateSalt();
    }
}
