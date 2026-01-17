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

            dgvInvoices.CellDoubleClick += dgvInvoices_CellDoubleClick;

            this.Load += StatisticForm_Load;
        }

        private async void StatisticForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadInvoicesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo form: {ex.Message}");
            }
        }

        private void ConfigureGrid()
        {
            if (dgvInvoices.Columns.Count > 0)
            {
                dgvInvoices.Columns["InvoiceNo"].HeaderText = "Mã hóa đơn";
                dgvInvoices.Columns["CustomerName"].HeaderText = "Tên khách hàng";
                dgvInvoices.Columns["Address"].HeaderText = "Địa chỉ";
                dgvInvoices.Columns["BuyDate"].HeaderText = "Ngày mua";
                dgvInvoices.Columns["BuyDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvInvoices.Columns["EmployeeCode"].HeaderText = "Mã nhân viên";
                dgvInvoices.Columns["TotalAmount"].HeaderText = "Tổng tiền";
                dgvInvoices.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
            }
        }

        // ===== LOAD INVOICE =====
        private async Task LoadInvoicesAsync(string? keyword = null)
        {
            try
            {
                _invoices = await _reportService.GetInvoicesAsync(keyword);

                if (_invoices == null)
                {
                    dgvInvoices.DataSource = null;
                    lblTotalRevenue.Text = "Tổng doanh thu: 0 VNĐ";
                    return;
                }

                dgvInvoices.DataSource = _invoices.Select(x => new
                {
                    x.InvoiceNo,
                    CustomerName = x.Customer?.FullName ?? "N/A",
                    Address = x.Customer?.Address ?? "N/A",
                    BuyDate = x.InvoiceDate,
                    EmployeeCode = x.Employee?.EmployeeCode ?? "N/A",
                    TotalAmount = x.TotalAmount
                }).ToList();

                ConfigureGrid();

                lblTotalRevenue.Text = $"Tổng doanh thu: {_invoices.Sum(x => x.TotalAmount):N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                await LoadInvoicesAsync(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}");
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (_invoices == null || !_invoices.Any())
                {
                    MessageBox.Show("Không có dữ liệu để xuất Excel!", "Thông báo");
                    return;
                }

                using var dialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    FileName = $"Invoices_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
                };

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                var bytes = _reportService.ExportInvoiceExcelBytes(_invoices);
                System.IO.File.WriteAllBytes(dialog.FileName, bytes);

                MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                // Sử dụng TryParse hoặc kiểm tra null để an toàn hơn
                var cellValue = dgvInvoices.Rows[e.RowIndex].Cells["InvoiceId"].Value;
                // lấy id hóa đơn, mở form xem chi tiết
                if (cellValue == null) return;

                int invoiceId = Convert.ToInt32(cellValue);

                using var frm = new InvoiceDetailForm(invoiceId, _reportService);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem chi tiết: {ex.Message}");
            }
        }
    }
}