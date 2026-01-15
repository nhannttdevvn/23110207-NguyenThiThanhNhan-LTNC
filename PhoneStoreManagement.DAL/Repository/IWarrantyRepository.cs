using PhoneStoreManagement.Entity.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Data.Repository;

public interface IWarrantyRepository : IRepository<Warranty>
{
    Task<List<Warranty>> LookupAsync(string keyword, CancellationToken ct = default);
}