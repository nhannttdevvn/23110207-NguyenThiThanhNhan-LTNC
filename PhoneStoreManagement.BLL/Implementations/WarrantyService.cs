using PhoneStoreManagement.Data.Repository;
using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Services.Implementations;

public class WarrantyService : IWarrantyService
{
    private readonly IWarrantyRepository _repo;

    public WarrantyService(IWarrantyRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Warranty>> SearchWarrantyAsync(string keyword)
    {
        return await _repo.LookupAsync(keyword);
    }
}