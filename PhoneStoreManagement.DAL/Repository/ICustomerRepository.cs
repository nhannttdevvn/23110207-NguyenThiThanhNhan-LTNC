using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStoreManagement.Entity.Entities;

namespace PhoneStoreManagement.Data.Repository;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<List<Customer>> SearchAsync(string keyword, CancellationToken ct = default);
}

