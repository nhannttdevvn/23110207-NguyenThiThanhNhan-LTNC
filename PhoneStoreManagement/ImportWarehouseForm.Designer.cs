namespace PhoneStoreManagement.Winforms
{
    partial class ImportWarehouseForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlFooter;
        private Panel pnlGridWrapper; // Panel để tạo Margin cho DataGridView
        private ComboBox cboProduct;
        private TextBox txtProductCode;
        private NumericUpDown numQuantity;
        private DataGridView dgvImportList; // DataGridView được thêm vào theo yêu cầu
        private Button btnSave;
        private Button btnCancel;
        private Label lblProduct;
        private Label lblCode;
        private Label lblQty;

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
            pnlFooter = new Panel();
            pnlGridWrapper = new Panel();
            cboProduct = new ComboBox();
            txtProductCode = new TextBox();
            numQuantity = new NumericUpDown();
            dgvImportList = new DataGridView();
            btnSave = new Button();
            btnCancel = new Button();
            lblProduct = new Label();
            lblCode = new Label();
            lblQty = new Label();

            pnlHeader.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlGridWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvImportList).BeginInit();
            SuspendLayout();

            // ===== pnlHeader =====
            pnlHeader.BackColor = Color.FromArgb(52, 152, 219);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 55;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 15);
            lblTitle.Text = "NHẬP KHO HÀNG HÓA";

            // ===== Căn chỉnh các controls nhập liệu phía trên =====
            int startX = 25;
            int startY = 70;
            int gap = 60;

            lblProduct.Text = "Sản phẩm:";
            lblProduct.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProduct.Location = new Point(startX, startY);
            lblProduct.AutoSize = true;

            cboProduct.Location = new Point(startX, startY + 20);
            cboProduct.Size = new Size(200, 25);
            cboProduct.DropDownStyle = ComboBoxStyle.DropDownList;

            lblCode.Text = "Mã sản phẩm:";
            lblCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCode.Location = new Point(startX + 220, startY);
            lblCode.AutoSize = true;

            txtProductCode.Location = new Point(startX + 220, startY + 20);
            txtProductCode.Size = new Size(135, 25);
            txtProductCode.ReadOnly = true;

            lblQty.Text = "Số lượng:";
            lblQty.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQty.Location = new Point(startX, startY + gap);
            lblQty.AutoSize = true;

            numQuantity.Location = new Point(startX, startY + gap + 20);
            numQuantity.Size = new Size(100, 25);
            numQuantity.Minimum = 1;

            // ===== pnlGridWrapper (Tạo Margin cho DataGridView) =====
            pnlGridWrapper.Dock = DockStyle.Bottom;
            pnlGridWrapper.Height = 250;
            pnlGridWrapper.Padding = new Padding(15, 0, 15, 10);
            pnlGridWrapper.BackColor = Color.White;
            pnlGridWrapper.Controls.Add(dgvImportList);

            // ===== dgvImportList (Style xanh đậm/nhạt, không viền) =====
            dgvImportList.Dock = DockStyle.Fill;
            dgvImportList.BackgroundColor = Color.White;
            dgvImportList.BorderStyle = BorderStyle.None;
            dgvImportList.EnableHeadersVisualStyles = false;
            dgvImportList.ReadOnly = true;
            dgvImportList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvImportList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvImportList.RowHeadersVisible = false;

            // Header xanh đậm
            dgvImportList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvImportList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvImportList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvImportList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvImportList.ColumnHeadersHeight = 35;

            // Select xanh nhạt
            dgvImportList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 234, 248);
            dgvImportList.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvImportList.GridColor = Color.FromArgb(236, 240, 241);
            dgvImportList.RowTemplate.Height = 30;

            // ===== pnlFooter =====
            pnlFooter.BackColor = Color.FromArgb(244, 244, 244);
            pnlFooter.Controls.Add(btnSave);
            pnlFooter.Controls.Add(btnCancel);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Height = 60;

            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(145, 12);
            btnSave.Size = new Size(110, 35);
            btnSave.Text = "Lưu dữ liệu";
            //in đậm
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            btnCancel.BackColor = Color.FromArgb(189, 195, 199);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(265, 12);
            btnCancel.Size = new Size(90, 35);
            btnCancel.Text = "Hủy";
            //in đậm
            btnCancel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            // ===== Form Config =====
            ClientSize = new Size(400, 650);
            Controls.Add(lblProduct);
            Controls.Add(cboProduct);
            Controls.Add(lblCode);
            Controls.Add(txtProductCode);
            Controls.Add(lblQty);
            Controls.Add(numQuantity);
            Controls.Add(pnlGridWrapper);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ImportWarehouseForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nhập kho hàng hóa";

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFooter.ResumeLayout(false);
            pnlGridWrapper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvImportList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}