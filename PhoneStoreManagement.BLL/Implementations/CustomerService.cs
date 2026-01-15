using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStoreManagement.Data.Repository;
using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;
namespace PhoneStoreManagement.Data;


public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _uow;

    public CustomerService(IUnitOfWork uow) => _uow = uow;

    public Task<List<Customer>> SearchAsync(string keyword, CancellationToken ct = default)
        => _uow.Customers.SearchAsync(keyword, ct);

    public Task<Customer?> GetAsync(int id, CancellationToken ct = default)
        => _uow.Customers.GetByIdAsync(id, ct);

    public async Task<int> CreateAsync(Customer c, CancellationToken ct = default)
    {
        await _uow.Customers.AddAsync(c, ct);
        await _uow.SaveChangesAsync(ct);
        return c.CustomerId;
    }

    public async Task UpdateAsync(Customer c, CancellationToken ct = default)
    {
        _uow.Customers.Update(c);
        await _uow.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var c = await _uow.Customers.GetByIdAsync(id, ct);
        if (c is null) return;
        _uow.Customers.Remove(c);
        await _uow.SaveChangesAsync(ct);
    }
}
