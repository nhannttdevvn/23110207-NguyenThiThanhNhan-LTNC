using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Entity.Entities;

namespace PhoneStoreManagement.Data.Repository;

public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(PhoneDbContext db) : base(db) { }

    public Task<List<Customer>> SearchAsync(string keyword, CancellationToken ct = default)
    {
        keyword = (keyword ?? "").Trim().ToLower();
        var q = Db.Customers.AsNoTracking().AsQueryable();

        if (keyword.Length > 0)
        {
            q = q.Where(x =>
                x.FullName.ToLower().Contains(keyword) ||
                x.Phone.ToLower().Contains(keyword) ||
                x.Email.ToLower().Contains(keyword));
        }

        return q.OrderBy(x => x.FullName).ToListAsync(ct);
    }
}
