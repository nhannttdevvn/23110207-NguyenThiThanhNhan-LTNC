using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhoneStoreManagement.Entity.Entities;

namespace PhoneStoreManagement.Data.Repository;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> SearchAsync(string keyword, CancellationToken ct = default);
}

