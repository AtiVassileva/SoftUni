using System.Security.Cryptography;
using System.Text;
using BattleCards.Services.Contracts;

namespace BattleCards.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return string.Empty;
            }

            // Create a SHA256   
            using var sha256Hash = SHA256.Create();

            // ComputeHash - returns byte array  
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convert byte array to a string   
            var builder = new StringBuilder();

            for (var i = 0; i < bytes.Length; i++)
            {
                var @byte = bytes[i];
                builder.Append(@byte.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}