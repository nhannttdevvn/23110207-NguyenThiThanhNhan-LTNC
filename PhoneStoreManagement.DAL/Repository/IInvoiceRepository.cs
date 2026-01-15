using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhoneStoreManagement.Entity.Entities;

namespace PhoneStoreManagement.Data.Repository;

public interface IInvoiceRepository : IRepository<Invoice>
{
    Task<Invoice?> GetDetailAsync(int invoiceId, CancellationToken ct = default);
    Task<List<Invoice>> SearchAsync(string keyword, CancellationToken ct = default);
}
