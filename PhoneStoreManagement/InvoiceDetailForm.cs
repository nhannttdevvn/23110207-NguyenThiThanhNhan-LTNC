using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
// Thư viện xử lý PDF
using iTextSharp.text;
using iTextSharp.text.pdf;
// Thư viện của bạn
using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;

namespace PhoneStoreManagement.Winforms
{
    public partial class InvoiceDetailForm : Form
    {
        private readonly int _invoiceId;
        private readonly IReportService _reportService;
        private Invoice _currentInvoice;

        public InvoiceDetailForm(int invoiceId, IReportService reportService)
        {
            _invoiceId = invoiceId;
            _reportService = reportService;
            InitializeComponent();
            this.Load += InvoiceDetailForm_Load;

            // Cấu hình nút xuất PDF
           
            btnExport.Click += btnExportPDF_Click;
        }

        private async void InvoiceDetailForm_Load(object sender, EventArgs e)
        {
            await LoadInvoiceDetails();
        }

        private void ConfigureGrid()
        {
            if (dgvItems.Columns.Count > 0)
            {
                dgvItems.Columns["STT"].HeaderText = "STT";
                dgvItems.Columns["SanPham"].HeaderText = "Tên sản phẩm";
                dgvItems.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvItems.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvItems.Columns["ThanhTien"].HeaderText = "Thành tiền";
            }
        }

        private async Task LoadInvoiceDetails()
        {
            try
            {
                _currentInvoice = await _reportService.GetInvoiceDetailAsync(_invoiceId);
                if (_currentInvoice == null) { this.Close(); return; }

                // Hiển thị thông tin (giả định các label đã khai báo trong Designer)
                lblInvoiceId.Text = _currentInvoice.InvoiceId.ToString("D6");
                lblCustomer.Text = _currentInvoice.Customer?.FullName ?? "Khách vãng lai";
                lblPhone.Text = _currentInvoice.Customer?.Phone ?? "N/A";
                lblAddress.Text = _currentInvoice.Customer?.Address ?? "N/A";
                lblDate.Text = _currentInvoice.InvoiceDate.ToString("dd/MM/yyyy HH:mm");
                lblEmployee.Text = _currentInvoice.Employee?.FullName ?? "Hệ thống";
                lblTotal.Text = string.Format("{0:N0} VNĐ", _currentInvoice.TotalAmount);

                dgvItems.DataSource = _currentInvoice.InvoiceItems.Select(x => new
                {
                    STT = _currentInvoice.InvoiceItems.ToList().IndexOf(x) + 1,
                    SanPham = x.Product?.ProductName ?? "N/A",
                    SoLuong = x.Quantity,
                    DonGia = x.UnitPrice.ToString("N0"),
                    ThanhTien = x.LineTotal.ToString("N0")
                }).ToList();
                ConfigureGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (_currentInvoice == null) return;

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF File|*.pdf", FileName = $"HD_{_currentInvoice.InvoiceId}.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportToPDF(_currentInvoice, sfd.FileName);
                        MessageBox.Show("Xuất PDF thành công!");
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
                }
            }
        }

        private void ExportToPDF(Invoice inv, string filePath)
        {
            // Giải quyết lỗi 'Font' ambiguous bằng cách chỉ định rõ iTextSharp.text.Font
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");
            BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fontText = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font fontTableHead = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);

            // Khởi tạo Document của iTextSharp
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 30f, 30f, 30f, 30f);

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Tiêu đề
                iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("HÓA ĐƠN BÁN HÀNG", fontHeader);
                title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                doc.Add(title);
                doc.Add(new iTextSharp.text.Paragraph("\n"));

                // Thông tin khách hàng
                doc.Add(new iTextSharp.text.Paragraph($"Mã đơn: {inv.InvoiceId:D6}", fontText));
                doc.Add(new iTextSharp.text.Paragraph($"Khách hàng: {inv.Customer?.FullName}", fontText));
                doc.Add(new iTextSharp.text.Paragraph($"Ngày: {inv.InvoiceDate:dd/MM/yyyy HH:mm}", fontText));
                doc.Add(new iTextSharp.text.Paragraph("--------------------------------------------------", fontText));

                // Bảng hàng hóa
                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;
                table.AddCell(new PdfPCell(new Phrase("Sản phẩm", fontTableHead)));
                table.AddCell(new PdfPCell(new Phrase("SL", fontTableHead)));
                table.AddCell(new PdfPCell(new Phrase("Đơn giá", fontTableHead)));
                table.AddCell(new PdfPCell(new Phrase("Thành tiền", fontTableHead)));

                foreach (var item in inv.InvoiceItems)
                {
                    table.AddCell(new Phrase(item.Product?.ProductName, fontText));
                    table.AddCell(new Phrase(item.Quantity.ToString(), fontText));
                    table.AddCell(new Phrase(item.UnitPrice.ToString("N0"), fontText));
                    table.AddCell(new Phrase(item.LineTotal.ToString("N0"), fontText));
                }
                doc.Add(table);

                doc.Add(new iTextSharp.text.Paragraph("\n"));
                iTextSharp.text.Paragraph total = new iTextSharp.text.Paragraph($"TỔNG TIỀN: {inv.TotalAmount:N0} VNĐ", fontHeader);
                total.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
                doc.Add(total);

                doc.Close();
            }
        }
    }
}