namespace PhoneStoreManagement.Winforms;

partial class WarehouseForm
{
    private System.ComponentModel.IContainer components = null;

    private Panel pnlHeader;
    private Label lblTitle;
    private GroupBox grpActions;
    private Panel pnlGridWrapper; // Panel phụ để tạo Margin cho DataGridView
    private DataGridView dgvWarehouse;
    private Button btnImport;
    private Button btnExportExcel;

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
        grpActions = new GroupBox();
        pnlGridWrapper = new Panel();
        dgvWarehouse = new DataGridView();
        btnImport = new Button();
        btnExportExcel = new Button();

        ((System.ComponentModel.ISupportInitialize)dgvWarehouse).BeginInit();
        pnlHeader.SuspendLayout();
        grpActions.SuspendLayout();
        pnlGridWrapper.SuspendLayout();
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
        lblTitle.Text = "QUẢN LÝ KHO HÀNG";

        // ===== grpActions (Dock: Top) =====
        grpActions.Dock = DockStyle.Top;
        grpActions.Height = 80;
        grpActions.Text = "Thao tác kho";
        grpActions.Padding = new Padding(10);

        btnImport.BackColor = Color.FromArgb(46, 204, 113);
        btnImport.FlatStyle = FlatStyle.Flat;
        btnImport.ForeColor = Color.White;
        btnImport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnImport.Location = new Point(20, 30);
        btnImport.Size = new Size(130, 35);
        btnImport.Text = "Nhập hàng";
        //in đậm
        btnImport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnImport.Click += btnImport_Click;

        btnExportExcel.BackColor = Color.FromArgb(230, 126, 34);
        btnExportExcel.FlatStyle = FlatStyle.Flat;
        btnExportExcel.ForeColor = Color.White;
        btnExportExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnExportExcel.Location = new Point(160, 30);
        btnExportExcel.Size = new Size(130, 35);
        btnExportExcel.Text = "Xuất Excel";
        // in đậm
        btnExportExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnExportExcel.Click += btnExportExcel_Click;

        grpActions.Controls.AddRange(new Control[] { btnImport, btnExportExcel });

        // ===== pnlGridWrapper (Tạo Margin trái phải 15px, dưới 15px) =====
        pnlGridWrapper.Dock = DockStyle.Fill;
        pnlGridWrapper.Padding = new Padding(15, 5, 15, 15);
        pnlGridWrapper.BackColor = Color.White;

        // ===== dgvWarehouse (Style: Header xanh đậm, Select xanh nhạt, No Border) =====
        dgvWarehouse.Dock = DockStyle.Fill;
        dgvWarehouse.BackgroundColor = Color.White;
        dgvWarehouse.BorderStyle = BorderStyle.None;
        dgvWarehouse.EnableHeadersVisualStyles = false;
        dgvWarehouse.AllowUserToAddRows = false;
        dgvWarehouse.ReadOnly = true;
        dgvWarehouse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvWarehouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvWarehouse.RowHeadersVisible = false;

        // Header Style (Xanh đậm)
        dgvWarehouse.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dgvWarehouse.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
        dgvWarehouse.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvWarehouse.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvWarehouse.ColumnHeadersHeight = 40;

        // Selection Style (Xanh nhạt)
        dgvWarehouse.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 234, 248);
        dgvWarehouse.DefaultCellStyle.SelectionForeColor = Color.Black;
        dgvWarehouse.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
        dgvWarehouse.RowTemplate.Height = 35;
        dgvWarehouse.GridColor = Color.FromArgb(236, 240, 241);

        pnlGridWrapper.Controls.Add(dgvWarehouse);

        // ===== WarehouseForm Config =====
        ClientSize = new Size(1000, 600);
        Controls.Add(pnlGridWrapper);
        Controls.Add(grpActions);
        Controls.Add(pnlHeader);
        Text = "Warehouse Management";
        StartPosition = FormStartPosition.CenterScreen;

        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        grpActions.ResumeLayout(false);
        pnlGridWrapper.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvWarehouse).EndInit();
        ResumeLayout(false);
    }
}