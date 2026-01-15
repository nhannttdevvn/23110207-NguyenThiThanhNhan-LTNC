using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement.Winforms
{
    public partial class StatisticForm : Form
    {
        private readonly IReportService _reportService;
        private List<Invoice> _invoices = new();

        public StatisticForm(IReportService reportService)
        {
            _reportService = reportService;
            InitializeComponent();
        }

        private async void StatisticForm_Load(object sender, EventArgs e)
        {
            await LoadInvoicesAsync();
        }

        // ===== LOAD INVOICE =====
        private async Task LoadInvoicesAsync(string? keyword = null)
        {
            _invoices = await _reportService.GetInvoicesAsync(keyword);

            dgvInvoices.DataSource = _invoices.Select(x => new
            {
                x.InvoiceId,
                CustomerName = x.Customer.FullName,
                Address = x.Customer.Address,
                BuyDate = x.InvoiceDate,
                EmployeeCode = x.Employee.EmployeeCode,
                TotalAmount = x.TotalAmount
            }).ToList();

            lblTotalRevenue.Text =
                $"Tổng doanh thu: {_invoices.Sum(x => x.TotalAmount):N0} VNĐ";
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadInvoicesAsync(txtSearch.Text.Trim());
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = $"Invoices_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var bytes = _reportService.ExportInvoiceExcelBytes(_invoices);
            File.WriteAllBytes(dialog.FileName, bytes);

            MessageBox.Show("Xuất Excel thành công!");
        }

        private void dgvInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int invoiceId = Convert.ToInt32(
                dgvInvoices.Rows[e.RowIndex].Cells["InvoiceId"].Value
            );

            using var frm = new InvoiceDetailForm(invoiceId, _reportService);
            frm.ShowDialog();
        }
    }
}
