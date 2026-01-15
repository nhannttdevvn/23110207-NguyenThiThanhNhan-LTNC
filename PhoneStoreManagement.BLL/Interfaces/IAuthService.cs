namespace PhoneStoreManagement.Services.Interfaces;

public record AdminAuthResult(
    int AdminId,
    string Username
);

public interface IAuthService
{
    Task<AdminAuthResult?> LoginAdminAsync(
        string username,
        string password,
        CancellationToken ct = default);
}
