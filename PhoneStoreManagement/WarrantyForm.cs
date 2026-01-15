using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhoneStoreManagement.Services.Interfaces;

namespace PhoneStoreManagement.Winforms
{
    public partial class WarrantyForm : Form
    {
        private readonly IWarrantyService _warrantySvc;

        public WarrantyForm(IWarrantyService warrantySvc)
        {
            _warrantySvc = warrantySvc;
            InitializeComponent();
            ConfigGrid();

            // Đăng ký sự kiện Load của Form
            this.Load += WarrantyForm_Load;
        }

        private async void WarrantyForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync(string keyword = "")
        {
            try
            {
                var results = await _warrantySvc.SearchWarrantyAsync(keyword);

                dgvWarranty.DataSource = null;
                if (results != null && results.Any())
                {
                    dgvWarranty.DataSource = results.Select(w => new {
                        w.WarrantyId,
                        w.CustomerName,
                        w.CustomerPhone,
                        ProductName = w.InvoiceItem?.Product?.ProductName ?? "N/A",
                        w.StartDate,
                        w.EndDate,
                        w.Status
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtSearch.Text.Trim();
            await LoadDataAsync(keyword);
        }

        private void ConfigGrid()
        {
            dgvWarranty.AutoGenerateColumns = false;
            dgvWarranty.Columns.Clear();
            dgvWarranty.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "WarrantyId", HeaderText = "Mã BH" });
            dgvWarranty.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CustomerName", HeaderText = "Khách hàng" });
            dgvWarranty.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CustomerPhone", HeaderText = "SĐT" });
            dgvWarranty.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Sản phẩm", Width = 250 });
            dgvWarranty.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StartDate", HeaderText = "Ngày bán", DefaultCellStyle = { Format = "dd/MM/yyyy" } });
            dgvWarranty.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EndDate", HeaderText = "Hết hạn", DefaultCellStyle = { Format = "dd/MM/yyyy" } });
            dgvWarranty.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Trạng thái" });
        }
    }
}