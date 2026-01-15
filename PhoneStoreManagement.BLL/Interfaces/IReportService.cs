using PhoneStoreManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Services.Interfaces;

public interface IReportService
{
    Task<List<Invoice>> GetInvoicesAsync(
        string keyword = "",
        DateTime? fromDate = null,
        DateTime? toDate = null,
        CancellationToken ct = default
    );

    Task<decimal> GetTotalRevenueAsync(
        DateTime? fromDate = null,
        DateTime? toDate = null,
        CancellationToken ct = default
    );

    byte[] ExportInvoiceExcelBytes(List<Invoice> invoices);

    Task<Invoice> GetInvoiceDetailAsync(int invoiceId);
}
