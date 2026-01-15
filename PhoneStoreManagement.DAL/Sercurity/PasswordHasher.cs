using System.Security.Cryptography;
using System.Text;

namespace PhoneStoreManagement.Data.Security;

public static class PasswordHasher
{
    public static string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(16);
        var bytes = Encoding.UTF8.GetBytes(password);
        var data = new byte[salt.Length + bytes.Length];

        Buffer.BlockCopy(salt, 0, data, 0, salt.Length);
        Buffer.BlockCopy(bytes, 0, data, salt.Length, bytes.Length);

        var hash = SHA256.HashData(data);
        return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
    }
}
