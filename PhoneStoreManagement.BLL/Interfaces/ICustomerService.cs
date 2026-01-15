using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhoneStoreManagement.Entity.Entities;

namespace PhoneStoreManagement.Services.Interfaces;

public interface ICustomerService
{
    Task<List<Customer>> SearchAsync(string keyword, CancellationToken ct = default);
    Task<Customer?> GetAsync(int id, CancellationToken ct = default);
    Task<int> CreateAsync(Customer c, CancellationToken ct = default);
    Task UpdateAsync(Customer c, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);
}

