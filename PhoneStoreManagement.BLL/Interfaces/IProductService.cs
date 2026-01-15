using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhoneStoreManagement.Entity.Entities;

namespace PhoneStoreManagement.Services.Interfaces;

public interface IProductService
{
    Task<List<Product>> SearchAsync(string keyword, CancellationToken ct = default);
    Task<Product?> GetAsync(int id, CancellationToken ct = default);
    Task<int> CreateAsync(Product p, CancellationToken ct = default);
    Task<Product?> GetByCodeAsync(string code, CancellationToken token = default);

    Task UpdateAsync(Product p, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);

}
