using JobFinderAPI.Application.Interfaces.Services;
using JobFinderAPI.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace JobFinderAPI.Infrastructure.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHashingSettings _settings;

        public PasswordHasher(IOptions<PasswordHashingSettings> options)
        {
            _settings = options.Value;
        }
        public string Hash(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string pepperPasswordSalt = $"{_settings.Pepper}{password}{salt}";
                byte[] hashValue = Encoding.UTF8.GetBytes(pepperPasswordSalt);
                for(int i = 0; i< _settings.Iteration; i++)
                    hashValue = sha256.ComputeHash(hashValue);
                return Convert.ToBase64String(hashValue);
            }
        }

        public string CreateSalt()
        {
            var saltBytes = new byte[32];

            using (var random = RandomNumberGenerator.Create())
                random.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        
    }
}
