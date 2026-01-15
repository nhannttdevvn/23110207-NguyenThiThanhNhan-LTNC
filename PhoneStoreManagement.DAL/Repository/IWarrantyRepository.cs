using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhoneStoreManagement.Entity.Entities;

namespace PhoneStoreManagement.Data.Repository;

public interface IWarrantyRepository : IRepository<Warranty>
{
    Task<List<Warranty>> LookupAsync(string phoneOrWarrantyNo, CancellationToken ct = default);
}
