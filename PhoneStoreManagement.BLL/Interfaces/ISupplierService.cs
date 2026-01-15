using PhoneStoreManagement.Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Services.Interfaces
{
    public interface ISupplierService
    {
        IQueryable<Supplier> Query();

        Task<List<Supplier>> GetAllAsync(CancellationToken ct = default);
        Task<List<Supplier>> SearchAsync(string keyword, CancellationToken ct = default);
        Task<Supplier?> GetAsync(int id, CancellationToken ct = default);
        Task<int> CreateAsync(Supplier s, CancellationToken ct = default);
        Task UpdateAsync(Supplier s, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);

        Task<bool> ExistsPhoneAsync(string phone, int? ignoreId = null);
        Task<bool> ExistsEmailAsync(string email, int? ignoreId = null);
    }
}
