using DocumentFormat.OpenXml.Drawing;
using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Data;
using PhoneStoreManagement.Data.Repository;
using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _uow;

        public SupplierService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IQueryable<Supplier> Query()
        {
            return _uow.Suppliers.GetAll();
        }

        public Task<List<Supplier>> GetAllAsync(CancellationToken ct = default)
        {
            return _uow.Suppliers.GetAll().ToListAsync(ct);
        }

        public Task<List<Supplier>> SearchAsync(string keyword, CancellationToken ct = default)
        {
            return _uow.Suppliers.SearchAsync(keyword ?? "", ct);
        }

        public Task<Supplier?> GetAsync(int id, CancellationToken ct = default)
        {
            return _uow.Suppliers.GetByIdAsync(id, ct);
        }

        public async Task<int> CreateAsync(Supplier s, CancellationToken ct = default)
        {
            await _uow.Suppliers.AddAsync(s, ct);
            await _uow.SaveChangesAsync(ct);
            return s.SupplierId;
        }

        public async Task UpdateAsync(Supplier s, CancellationToken ct = default)
        {
            _uow.Suppliers.Update(s);
            await _uow.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var s = await _uow.Suppliers.GetByIdAsync(id, ct);
            if (s == null) return;

            _uow.Suppliers.Remove(s);
            await _uow.SaveChangesAsync(ct);
        }
        public async Task<bool> ExistsPhoneAsync(string phone, int? ignoreId = null)
        {
            return await Query()
                .AnyAsync(x => x.Phone == phone &&
                    (!ignoreId.HasValue || x.SupplierId != ignoreId.Value));
        }

        public async Task<bool> ExistsEmailAsync(string email, int? ignoreId = null)
        {
            return await Query()
                .AnyAsync(x => x.Email == email &&
                    (!ignoreId.HasValue || x.SupplierId != ignoreId.Value));
        }
    }
}
