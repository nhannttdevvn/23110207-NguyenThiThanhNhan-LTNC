using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhoneStoreManagement.Entity.Entities;

namespace PhoneStoreManagement.Services.Interfaces;

public interface IWarrantyService
{
    Task<List<Warranty>> LookupAsync(string phoneOrWarrantyNo, CancellationToken ct = default);
    bool IsExpired(Warranty w, DateTime? now = null);
}
