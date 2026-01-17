namespace PhoneStoreManagement.Winforms
{
    partial class InvoiceDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private GroupBox grpInfo;
        private Panel pnlFooter;
        private Panel pnlGridWrapper;
        private Button btnExport;
        private DataGridView dgvItems;

        private Label lblCapId, lblCapCustomer, lblCapPhone, lblCapAddress, lblCapDate, lblCapEmployee, lblCapTotal;
        private Label lblInvoiceId, lblCustomer, lblPhone, lblAddress, lblDate, lblEmployee, lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            grpInfo = new GroupBox();
            pnlFooter = new Panel();
            pnlGridWrapper = new Panel();
            dgvItems = new DataGridView();
            btnExport = new Button();

            lblCapId = new Label(); lblInvoiceId = new Label();
            lblCapCustomer = new Label(); lblCustomer = new Label();
            lblCapPhone = new Label(); lblPhone = new Label();
            lblCapAddress = new Label(); lblAddress = new Label();
            lblCapDate = new Label(); lblDate = new Label();
            lblCapEmployee = new Label(); lblEmployee = new Label();
            lblCapTotal = new Label(); lblTotal = new Label();

            pnlHeader.SuspendLayout();
            grpInfo.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlGridWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();

            // ===== pnlHeader =====
            pnlHeader.BackColor = Color.FromArgb(52, 152, 219);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 65;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 15);
            lblTitle.Text = "CHI TIẾT HÓA ĐƠN";

            // ===== grpInfo =====
            grpInfo.Dock = DockStyle.Top;
            grpInfo.Height = 190;
            grpInfo.Text = "Thông tin chung";
            grpInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpInfo.Padding = new Padding(10);

            int labelX1 = 20, valueX1 = 130;
            int labelX2 = 380, valueX2 = 500;
            int y = 35, gap = 35;

            lblCapId.Text = "Mã hóa đơn:"; lblCapId.Location = new Point(labelX1, y); lblCapId.AutoSize = true;
            lblInvoiceId.Location = new Point(valueX1, y); lblInvoiceId.Size = new Size(200, 20); lblInvoiceId.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            lblCapDate.Text = "Ngày lập:"; lblCapDate.Location = new Point(labelX2, y); lblCapDate.AutoSize = true;
            lblDate.Location = new Point(valueX2, y); lblDate.Size = new Size(180, 20); lblDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            y += gap;
            lblCapCustomer.Text = "Khách hàng:"; lblCapCustomer.Location = new Point(labelX1, y); lblCapCustomer.AutoSize = true;
            lblCustomer.Location = new Point(valueX1, y); lblCustomer.Size = new Size(200, 20); lblCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            lblCapEmployee.Text = "Nhân viên:"; lblCapEmployee.Location = new Point(labelX2, y); lblCapEmployee.AutoSize = true;
            lblEmployee.Location = new Point(valueX2, y); lblEmployee.Size = new Size(180, 20); lblEmployee.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            y += gap;
            lblCapPhone.Text = "Số điện thoại:"; lblCapPhone.Location = new Point(labelX1, y); lblCapPhone.AutoSize = true;
            lblPhone.Location = new Point(valueX1, y); lblPhone.Size = new Size(200, 20); lblPhone.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            lblCapTotal.Text = "Tổng tiền:"; lblCapTotal.Location = new Point(labelX2, y); lblCapTotal.AutoSize = true;
            lblTotal.Location = new Point(valueX2 - 5, y - 5); lblTotal.Size = new Size(180, 30);
            lblTotal.Font = new Font("Segoe UI", 13F, FontStyle.Bold); lblTotal.ForeColor = Color.Crimson;

            y += gap;
            lblCapAddress.Text = "Địa chỉ:"; lblCapAddress.Location = new Point(labelX1, y); lblCapAddress.AutoSize = true;
            lblAddress.Location = new Point(valueX1, y); lblAddress.Size = new Size(550, 20); lblAddress.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            grpInfo.Controls.AddRange(new Control[] {
            lblCapId, lblInvoiceId, lblCapCustomer, lblCustomer, lblCapPhone, lblPhone,
            lblCapAddress, lblAddress, lblCapDate, lblDate, lblCapEmployee, lblEmployee,
            lblCapTotal, lblTotal
        });

            // ===== pnlGridWrapper (Tạo margin trái phải) =====
            pnlGridWrapper.Dock = DockStyle.Fill;
            pnlGridWrapper.Padding = new Padding(15, 10, 15, 10);
            pnlGridWrapper.BackColor = Color.White;
            pnlGridWrapper.Controls.Add(dgvItems);

            // ===== dgvItems Style =====
            dgvItems.Dock = DockStyle.Fill;
            dgvItems.BackgroundColor = Color.White;
            dgvItems.BorderStyle = BorderStyle.None;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.ReadOnly = true;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.RowHeadersVisible = false;
            dgvItems.EnableHeadersVisualStyles = false;
            dgvItems.GridColor = Color.FromArgb(236, 240, 241);

            // Header Style: Xanh đậm
            dgvItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvItems.ColumnHeadersHeight = 40;

            // Selection Style: Xanh nhạt
            dgvItems.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 234, 248);
            dgvItems.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvItems.RowTemplate.Height = 35;

            // ===== pnlFooter =====
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Height = 65;
            pnlFooter.BackColor = Color.FromArgb(244, 244, 244);
            pnlFooter.Controls.Add(btnExport);

            btnExport.Text = "Xuất hóa đơn";
            //in đậm
            btnExport.Font = new Font(btnExport.Font, FontStyle.Bold);
            btnExport.Size = new Size(160, 40);
            btnExport.BackColor = Color.FromArgb(46, 204, 113);
            btnExport.ForeColor = Color.White;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExport.Location = new Point(520, 12);
            btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // ===== Form Main Config =====
            ClientSize = new Size(700, 700);
            Controls.Add(pnlGridWrapper);
            Controls.Add(grpInfo);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "InvoiceDetailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết hóa đơn bán hàng";

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            pnlFooter.ResumeLayout(false);
            pnlGridWrapper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
        }
    }
}