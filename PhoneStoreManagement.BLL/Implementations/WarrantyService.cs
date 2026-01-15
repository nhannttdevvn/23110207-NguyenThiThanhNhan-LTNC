using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhoneStoreManagement.Data.Repository;
using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;

namespace PhoneStoreManagement.Data;

public class WarrantyService : IWarrantyService
{
    private readonly IUnitOfWork _uow;

    public WarrantyService(IUnitOfWork uow) => _uow = uow;

    public Task<List<Warranty>> LookupAsync(string phoneOrWarrantyNo, CancellationToken ct = default)
        => _uow.Warranties.LookupAsync(phoneOrWarrantyNo, ct);

    public bool IsExpired(Warranty w, DateTime? now = null)
    {
        var t = (now ?? DateTime.Now).Date;
        return t > w.EndDate.Date;
    }
}
