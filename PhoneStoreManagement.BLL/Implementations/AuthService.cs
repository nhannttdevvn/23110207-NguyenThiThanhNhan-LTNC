using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Data;
using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;

namespace PhoneStoreManagement.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly PhoneDbContext _db;

    public AuthService(PhoneDbContext db)
    {
        _db = db;
    }

    // ================= ADMIN LOGIN =================
    public async Task<AdminAuthResult?> LoginAdminAsync(
        string username,
        string password,
        CancellationToken ct = default)
    {
        var admin = await _db.AppAdminAccounts
            .FirstOrDefaultAsync(x =>
                x.Username == username && x.IsActive, ct);

        if (admin == null) return null;
        if (!Verify(password, admin.PasswordHash)) return null;

        return new AdminAuthResult(
            admin.AdminId,
            admin.Username
        );
    }

    // ================= HASH =================
    public static string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(16);
        var bytes = Encoding.UTF8.GetBytes(password);

        var data = new byte[salt.Length + bytes.Length];
        Buffer.BlockCopy(salt, 0, data, 0, salt.Length);
        Buffer.BlockCopy(bytes, 0, data, salt.Length, bytes.Length);

        var hash = SHA256.HashData(data);
        return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
    }

    private static bool Verify(string password, string stored)
    {
        var parts = stored.Split('.', 2);
        if (parts.Length != 2) return false;

        var salt = Convert.FromBase64String(parts[0]);
        var expected = Convert.FromBase64String(parts[1]);

        var bytes = Encoding.UTF8.GetBytes(password);
        var data = new byte[salt.Length + bytes.Length];
        Buffer.BlockCopy(salt, 0, data, 0, salt.Length);
        Buffer.BlockCopy(bytes, 0, data, salt.Length, bytes.Length);

        var hash = SHA256.HashData(data);
        return CryptographicOperations.FixedTimeEquals(hash, expected);
    }
}
