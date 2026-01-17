namespace PhoneStoreManagement.Winforms;

partial class SupplierForm
{
    private System.ComponentModel.IContainer components = null;

    private Panel pnlHeader;
    private Label lblTitle;
    private GroupBox grpInfo;
    private GroupBox grpSearch;
    private Panel pnlGridWrapper; // Panel phụ để tạo Margin cho DataGridView

    private DataGridView dgvSuppliers;
    private TextBox txtSearch, txtCode, txtName, txtHotline, txtEmail;
    private Button btnSearch, btnAdd, btnUpdate, btnDelete;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlHeader = new Panel();
        lblTitle = new Label();
        grpSearch = new GroupBox();
        grpInfo = new GroupBox();
        pnlGridWrapper = new Panel();
        dgvSuppliers = new DataGridView();

        txtSearch = new TextBox();
        txtCode = new TextBox();
        txtName = new TextBox();
        txtHotline = new TextBox();
        txtEmail = new TextBox();

        btnSearch = new Button();
        btnAdd = new Button();
        btnUpdate = new Button();
        btnDelete = new Button();

        ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
        pnlHeader.SuspendLayout();
        grpSearch.SuspendLayout();
        grpInfo.SuspendLayout();
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
        lblTitle.Text = "QUẢN LÝ NHÀ CUNG CẤP";

        // ===== grpSearch (Dock: Top) =====
        grpSearch.Dock = DockStyle.Top;
        grpSearch.Height = 80;
        grpSearch.Text = "Tìm kiếm";
        grpSearch.Font = new Font("Segoe UI", 10F);

        txtSearch.Location = new Point(20, 32);
        txtSearch.Size = new Size(400, 27);
        txtSearch.PlaceholderText = "Nhập tên nhà cung cấp cần tìm...";

        btnSearch.BackColor = Color.FromArgb(46, 204, 113);
        btnSearch.FlatStyle = FlatStyle.Flat;
        btnSearch.ForeColor = Color.White;
        btnSearch.Location = new Point(430, 30);
        btnSearch.Size = new Size(100, 32);
        btnSearch.Text = "Tìm kiếm";
        //in đậm
        btnSearch.Font = new Font(btnSearch.Font, FontStyle.Bold);
        btnSearch.Click += btnSearch_Click;
        grpSearch.Controls.AddRange(new Control[] { txtSearch, btnSearch });

        // ===== grpInfo (Dock: Left) =====
        grpInfo.Dock = DockStyle.Left;
        grpInfo.Width = 350;
        grpInfo.Text = "Thông tin chi tiết";
        grpInfo.Font = new Font("Segoe UI", 9F);

        int labelX = 20;
        int inputX = 110;
        int y = 45;
        int gap = 45;
        int inputW = 210;

        Label lblCode = new Label { Text = "Mã NCC:", Location = new Point(labelX, y), AutoSize = true };
        txtCode.Location = new Point(inputX, y - 3); txtCode.Size = new Size(inputW, 25); txtCode.ReadOnly = true;

        y += gap;
        Label lblName = new Label { Text = "Tên NCC:", Location = new Point(labelX, y), AutoSize = true };
        txtName.Location = new Point(inputX, y - 3); txtName.Size = new Size(inputW, 25);

        y += gap;
        Label lblHotline = new Label { Text = "Hotline:", Location = new Point(labelX, y), AutoSize = true };
        txtHotline.Location = new Point(inputX, y - 3); txtHotline.Size = new Size(inputW, 25);

        y += gap;
        Label lblEmail = new Label { Text = "Email:", Location = new Point(labelX, y), AutoSize = true };
        txtEmail.Location = new Point(inputX, y - 3); txtEmail.Size = new Size(inputW, 25);

        y += gap + 30;
        btnAdd.Text = "Thêm"; btnAdd.BackColor = Color.DodgerBlue; btnAdd.ForeColor = Color.White;
        btnAdd.FlatStyle = FlatStyle.Flat; btnAdd.Location = new Point(20, y); btnAdd.Size = new Size(90, 35);
        btnAdd.Click += btnAdd_Click;
        //in đậm
        btnAdd.Font = new Font(btnAdd.Font, FontStyle.Bold);

        btnUpdate.Text = "Sửa"; btnUpdate.BackColor = Color.Orange; btnUpdate.ForeColor = Color.White;
        btnUpdate.FlatStyle = FlatStyle.Flat; btnUpdate.Location = new Point(125, y); btnUpdate.Size = new Size(90, 35);
        btnUpdate.Click += btnUpdate_Click;
             //in đậm
        btnUpdate.Font = new Font(btnUpdate.Font, FontStyle.Bold);


        btnDelete.Text = "Xóa"; btnDelete.BackColor = Color.Crimson; btnDelete.ForeColor = Color.White;
        btnDelete.FlatStyle = FlatStyle.Flat; btnDelete.Location = new Point(230, y); btnDelete.Size = new Size(90, 35);
        btnDelete.Click += btnDelete_Click;
        //in đậm
        btnDelete.Font = new Font(btnDelete.Font, FontStyle.Bold);

        grpInfo.Controls.AddRange(new Control[] {
        lblCode, txtCode, lblName, txtName,
        lblHotline, txtHotline, lblEmail, txtEmail,
        btnAdd, btnUpdate, btnDelete
    });

        // ===== pnlGridWrapper (Tạo Margin trái phải cho Grid) =====
        pnlGridWrapper.Dock = DockStyle.Fill;
        pnlGridWrapper.Padding = new Padding(15, 5, 15, 15); // Margin: Trái 15, Trên 5, Phải 15, Dưới 15
        pnlGridWrapper.BackColor = Color.White;

        // ===== dgvSuppliers (Cấu hình Header xanh đậm, Select xanh nhạt, Bỏ viền) =====
        dgvSuppliers.Dock = DockStyle.Fill;
        dgvSuppliers.BackgroundColor = Color.White;
        dgvSuppliers.BorderStyle = BorderStyle.None; // Bỏ viền ngoài
        dgvSuppliers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgvSuppliers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dgvSuppliers.EnableHeadersVisualStyles = false; // Để tự chỉnh màu Header
        dgvSuppliers.ReadOnly = true;
        dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvSuppliers.RowHeadersVisible = false;

        // Header Style (Xanh đậm)
        dgvSuppliers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
        dgvSuppliers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvSuppliers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvSuppliers.ColumnHeadersHeight = 40;

        // Row Select Style (Xanh nhạt)
        dgvSuppliers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 234, 248);
        dgvSuppliers.DefaultCellStyle.SelectionForeColor = Color.Black;
        dgvSuppliers.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
        dgvSuppliers.RowTemplate.Height = 35;
        dgvSuppliers.GridColor = Color.FromArgb(236, 240, 241);

        dgvSuppliers.SelectionChanged += dgvSuppliers_SelectionChanged;
        pnlGridWrapper.Controls.Add(dgvSuppliers);

        // ===== Form Config =====
        ClientSize = new Size(1100, 600);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Quản lý nhà cung cấp";

        this.Controls.Add(pnlGridWrapper);
        this.Controls.Add(grpInfo);
        this.Controls.Add(grpSearch);
        this.Controls.Add(pnlHeader);

        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        grpSearch.ResumeLayout(false);
        grpSearch.PerformLayout();
        grpInfo.ResumeLayout(false);
        grpInfo.PerformLayout();
        pnlGridWrapper.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();

        this.Load += new EventHandler(this.SupplierForm_Load);
        ResumeLayout(false);
    }
}