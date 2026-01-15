using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PhoneStoreManagement.Winforms
{
    public partial class InvoiceDetailForm : Form
    {
        private readonly int _invoiceId;
        private readonly IReportService _reportService;

        public InvoiceDetailForm(int invoiceId, IReportService reportService)
        {
            _invoiceId = invoiceId;
            _reportService = reportService;
            InitializeComponent();
        }

        private async void InvoiceDetailForm_Load(object sender, EventArgs e)
        {
            try
            {
                var invoice = await _reportService.GetInvoiceDetailAsync(_invoiceId);

                if (invoice == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin hóa đơn", "Thông báo");
                    this.Close();
                    return;
                }

                lblInvoiceId.Text = invoice.InvoiceId.ToString();
                lblCustomer.Text = invoice.Customer?.FullName ?? "N/A";
                lblPhone.Text = invoice.Customer?.Phone ?? "N/A";
                lblAddress.Text = invoice.Customer?.Address ?? "N/A";
                lblDate.Text = invoice.InvoiceDate.ToString("dd/MM/yyyy HH:mm");
                lblEmployee.Text = invoice.Employee?.EmployeeCode ?? "N/A";
                lblTotal.Text = invoice.TotalAmount.ToString("N0");

                dgvItems.DataSource = invoice.InvoiceItems.Select(x => new
                {
                    ProductName = x.Product?.ProductName ?? "Sản phẩm đã xóa",
                    x.Quantity,
                    x.UnitPrice,
                    x.LineTotal
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + (ex.InnerException?.Message ?? ex.Message), "Lỗi");
            }
        }
    }
}