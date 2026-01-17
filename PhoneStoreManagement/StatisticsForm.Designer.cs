namespace PhoneStoreManagement.Winforms
{
    partial class StatisticForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private GroupBox grpFilter;
        private Panel pnlFooter;
        private Panel pnlGridWrapper; // Panel phụ để tạo Margin

        private DataGridView dgvInvoices;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnExportExcel;
        private Label lblTotalRevenue;

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
            grpFilter = new GroupBox();
            pnlFooter = new Panel();
            pnlGridWrapper = new Panel();
            dgvInvoices = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnExportExcel = new Button();
            lblTotalRevenue = new Label();

            pnlHeader.SuspendLayout();
            grpFilter.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlGridWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).BeginInit();
            SuspendLayout();

            // ===== pnlHeader (Dock: Top) =====
            pnlHeader.BackColor = Color.FromArgb(52, 152, 219);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 60;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 13);
            lblTitle.Text = "THỐNG KÊ DOANH THU";

            // ===== grpFilter (Dock: Top) =====
            grpFilter.Dock = DockStyle.Top;
            grpFilter.Height = 80;
            grpFilter.Text = "Bộ lọc tìm kiếm";
            grpFilter.Padding = new Padding(10);

            txtSearch.Location = new Point(20, 32);
            txtSearch.Size = new Size(350, 27);
            txtSearch.PlaceholderText = "Nhập mã hóa đơn hoặc khách hàng...";

            btnSearch.BackColor = Color.FromArgb(46, 204, 113);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(385, 30);
            btnSearch.Size = new Size(110, 32);
            btnSearch.Text = "Tìm kiếm";
            btnSearch.Click += btnSearch_Click;
            // in đậm
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            btnExportExcel.BackColor = Color.FromArgb(230, 126, 34);
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(505, 30);
            btnExportExcel.Size = new Size(130, 32);
            btnExportExcel.Text = "Xuất Excel";
            btnExportExcel.Click += btnExportExcel_Click;
            // in đậm
            btnExportExcel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            grpFilter.Controls.AddRange(new Control[] { txtSearch, btnSearch, btnExportExcel });

            // ===== pnlFooter (Dock: Bottom) =====
            pnlFooter.BackColor = Color.FromArgb(236, 240, 241);
            pnlFooter.Controls.Add(lblTotalRevenue);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Height = 50;

            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalRevenue.ForeColor = Color.FromArgb(192, 57, 43);
            lblTotalRevenue.Location = new Point(15, 13);
            lblTotalRevenue.Text = "Tổng doanh thu: 0 VNĐ";

            // ===== pnlGridWrapper (Tạo Margin trái phải) =====
            pnlGridWrapper.Dock = DockStyle.Fill;
            pnlGridWrapper.Padding = new Padding(15, 5, 15, 15);
            pnlGridWrapper.BackColor = Color.White;
            pnlGridWrapper.Controls.Add(dgvInvoices);

            // ===== dgvInvoices Style =====
            dgvInvoices.Dock = DockStyle.Fill;
            dgvInvoices.BackgroundColor = Color.White;
            dgvInvoices.BorderStyle = BorderStyle.None;
            dgvInvoices.EnableHeadersVisualStyles = false;
            dgvInvoices.AllowUserToAddRows = false;
            dgvInvoices.ReadOnly = true;
            dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoices.RowHeadersVisible = false;

            // Header Style (Xanh đậm)
            dgvInvoices.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvInvoices.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvInvoices.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInvoices.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvInvoices.ColumnHeadersHeight = 40;

            // Selection Style (Xanh nhạt)
            dgvInvoices.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 234, 248);
            dgvInvoices.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvInvoices.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvInvoices.GridColor = Color.FromArgb(236, 240, 241);
            dgvInvoices.RowTemplate.Height = 35;

            // ===== StatisticForm Config =====
            ClientSize = new Size(1100, 650);
            Controls.Add(pnlGridWrapper);
            Controls.Add(pnlFooter);
            Controls.Add(grpFilter);
            Controls.Add(pnlHeader);
            Text = "Statistic Management";
            StartPosition = FormStartPosition.CenterScreen;

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            pnlGridWrapper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).EndInit();
            ResumeLayout(false);
        }
    }
}