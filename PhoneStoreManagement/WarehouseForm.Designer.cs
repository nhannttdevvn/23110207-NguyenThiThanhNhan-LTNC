namespace PhoneStoreManagement.Winforms;

partial class WarehouseForm
{
    private System.ComponentModel.IContainer components = null;

    private DataGridView dgvWarehouse;
    private Button btnImport;
    private Button btnExportExcel;
    private Label lblTitle;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        dgvWarehouse = new DataGridView();
        btnImport = new Button();
        btnExportExcel = new Button();
        lblTitle = new Label();

        ((System.ComponentModel.ISupportInitialize)dgvWarehouse).BeginInit();
        SuspendLayout();

        // ===== Title =====
        lblTitle.Text = "QUẢN LÝ KHO HÀNG";
        lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        lblTitle.Location = new Point(20, 15);
        lblTitle.AutoSize = true;

        // ===== Grid =====
        dgvWarehouse.Location = new Point(20, 60);
        dgvWarehouse.Size = new Size(760, 360);
        dgvWarehouse.ReadOnly = true;
        dgvWarehouse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvWarehouse.AutoGenerateColumns = false;

        // ===== Buttons =====
        btnImport.Text = "Nhập kho";
        btnImport.Location = new Point(20, 440);
        btnImport.Click += btnImport_Click;

        btnExportExcel.Text = "Xuất Excel";
        btnExportExcel.Location = new Point(130, 440);
        btnExportExcel.Click += btnExportExcel_Click;

        // ===== Form =====
        ClientSize = new Size(820, 500);
        Text = "Warehouse";
        StartPosition = FormStartPosition.CenterScreen;
        Controls.AddRange(new Control[]
        {
            lblTitle,
            dgvWarehouse,
            btnImport,
            btnExportExcel
        });

        ResumeLayout(false);
    }
}
