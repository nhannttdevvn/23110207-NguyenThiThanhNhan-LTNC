using PhoneStoreManagement.Entity.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Services.Interfaces;

public interface IWarrantyService
{
    Task<List<Warranty>> SearchWarrantyAsync(string keyword);
}