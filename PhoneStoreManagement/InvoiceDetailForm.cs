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
            var invoice = await _reportService.GetInvoiceDetailAsync(_invoiceId);

            lblInvoiceId.Text = invoice.InvoiceId.ToString();
            lblCustomer.Text = invoice.Customer.FullName;
            lblPhone.Text = invoice.Customer.Phone;
            lblAddress.Text = invoice.Customer.Address;
            lblDate.Text = invoice.InvoiceDate.ToString("dd/MM/yyyy HH:mm");
            lblEmployee.Text = invoice.Employee.EmployeeCode;
            lblTotal.Text = invoice.TotalAmount.ToString("N0");

            dgvItems.DataSource = invoice.InvoiceItems.Select(x => new
            {
                ProductName = x.Product.ProductName,
                x.Quantity,
                x.UnitPrice,
                x.LineTotal
            }).ToList();
        }
    }
}
