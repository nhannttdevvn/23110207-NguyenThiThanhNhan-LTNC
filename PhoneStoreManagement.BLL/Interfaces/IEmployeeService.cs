using PhoneStoreManagement.Entity.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Services.Interfaces;

public interface IEmployeeService
{
    // ===== GET ALL =====
    Task<List<AppUser>> GetAllAsync(
        CancellationToken ct = default);

    // ===== SEARCH =====
    Task<List<AppUser>> SearchAsync(
        string keyword,
        CancellationToken ct = default);

    // ===== GET BY ID =====
    Task<AppUser?> GetAsync(
        int id,
        CancellationToken ct = default);

    // ===== CREATE =====
    Task<int> CreateAsync(
        AppUser u,
        string plainPassword,
        CancellationToken ct = default);

    // ===== UPDATE =====
    Task UpdateAsync(
        AppUser u,
        CancellationToken ct = default);

    // ===== RESET PASSWORD =====
    Task ResetPasswordAsync(
        int id,
        string newPlainPassword,
        CancellationToken ct = default);

    // ===== DELETE =====
    Task DeleteAsync(
        int id,
        CancellationToken ct = default);

    // ===== VALIDATE (TRÙNG DỮ LIỆU) =====
    bool IsEmailExists(
        string email,
        string? ignoreId = null);

    bool IsPhoneExists(
        string phone,
        string? ignoreId = null);
}
