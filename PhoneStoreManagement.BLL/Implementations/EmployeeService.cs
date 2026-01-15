using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Data;
using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;
using PhoneStoreManagement.Services.Implementations; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Services.Implementations;

public class EmployeeService : IEmployeeService
{
    private readonly PhoneDbContext _db;

    public EmployeeService(PhoneDbContext db)
    {
        _db = db;
    }

    // ================= GET ALL =================
    public Task<List<AppUser>> GetAllAsync(CancellationToken ct = default)
    {
        return _db.AppUsers
            .AsNoTracking()
            .OrderBy(x => x.AppUserId)
            .ToListAsync(ct);
    }

    // ================= SEARCH =================
    public Task<List<AppUser>> SearchAsync(string keyword, CancellationToken ct = default)
    {
        keyword = (keyword ?? "").Trim().ToLower();

        var q = _db.AppUsers.AsNoTracking();

        if (!string.IsNullOrEmpty(keyword))
        {
            q = q.Where(x =>
                x.FullName.ToLower().Contains(keyword) ||
                (x.Phone ?? "").ToLower().Contains(keyword) ||
                (x.Email ?? "").ToLower().Contains(keyword) ||
                (x.EmployeeCode ?? "").ToLower().Contains(keyword));
        }

        return q.OrderBy(x => x.AppUserId).ToListAsync(ct);
    }

    // ================= GET BY ID =================
    public Task<AppUser?> GetAsync(int id, CancellationToken ct = default)
    {
        return _db.AppUsers.FirstOrDefaultAsync(x => x.AppUserId == id, ct);
    }

    // ================= CREATE =================
    public async Task<int> CreateAsync(AppUser u, string plainPassword, CancellationToken ct = default)
    {
        var lastCode = await _db.AppUsers
            .OrderByDescending(x => x.AppUserId)
            .Select(x => x.EmployeeCode)
            .FirstOrDefaultAsync(ct);

        int next = 1;
        if (!string.IsNullOrEmpty(lastCode) && lastCode.Length >= 3)
        {
            int.TryParse(lastCode.Substring(2), out next);
            next++;
        }

        u.EmployeeCode = $"NV{next:D3}";
        u.PasswordHash = AuthService.HashPassword(plainPassword);
        u.IsActive = true;

        u.AppRoleId = 2; // Staff – QUAN TRỌNG

        _db.AppUsers.Add(u);
        await _db.SaveChangesAsync(ct);

        return u.AppUserId;
    }

    // ================= UPDATE =================
    public async Task UpdateAsync(AppUser u, CancellationToken ct = default)
    {
        var existing = await _db.AppUsers
            .FirstOrDefaultAsync(x => x.AppUserId == u.AppUserId, ct);

        if (existing == null) return;

        // ❌ Check trùng username (trừ chính nó)
        if (await _db.AppUsers.AnyAsync(x =>
            x.Username == u.Username &&
            x.AppUserId != u.AppUserId, ct))
            throw new InvalidOperationException("Tên đăng nhập đã tồn tại");

        // ❌ Check trùng email
        if (!string.IsNullOrEmpty(u.Email) &&
            await _db.AppUsers.AnyAsync(x =>
                x.Email == u.Email &&
                x.AppUserId != u.AppUserId, ct))
            throw new InvalidOperationException("Email đã tồn tại");

        // ❌ Check trùng phone
        if (!string.IsNullOrEmpty(u.Phone) &&
            await _db.AppUsers.AnyAsync(x =>
                x.Phone == u.Phone &&
                x.AppUserId != u.AppUserId, ct))
            throw new InvalidOperationException("Số điện thoại đã tồn tại");

        // Giữ field hệ thống
        u.EmployeeCode = existing.EmployeeCode;
        u.PasswordHash = existing.PasswordHash;

        _db.Entry(existing).CurrentValues.SetValues(u);
        await _db.SaveChangesAsync(ct);
    }

    // ================= RESET PASSWORD =================
    public async Task ResetPasswordAsync(int id, string newPlainPassword, CancellationToken ct = default)
    {
        var u = await _db.AppUsers.FirstOrDefaultAsync(x => x.AppUserId == id, ct);
        if (u == null) return;

        u.PasswordHash = AuthService.HashPassword(newPlainPassword);
        await _db.SaveChangesAsync(ct);
    }

    // ================= DELETE =================
    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var u = await _db.AppUsers.FirstOrDefaultAsync(x => x.AppUserId == id, ct);
        if (u == null) return;

        _db.AppUsers.Remove(u);
        await _db.SaveChangesAsync(ct);
    }

    // ================= VALIDATE =================
    public bool IsEmailExists(string email, string? ignoreEmployeeCode = null)
    {
        return _db.AppUsers.Any(x =>
            x.Email == email &&
            (ignoreEmployeeCode == null || x.EmployeeCode != ignoreEmployeeCode));
    }

    public bool IsPhoneExists(string phone, string? ignoreEmployeeCode = null)
    {
        return _db.AppUsers.Any(x =>
            x.Phone == phone &&
            (ignoreEmployeeCode == null || x.EmployeeCode != ignoreEmployeeCode));
    }
}
