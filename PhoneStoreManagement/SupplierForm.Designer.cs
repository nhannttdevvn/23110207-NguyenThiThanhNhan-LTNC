namespace PhoneStoreManagement.Winforms;

partial class SupplierForm
{
    private System.ComponentModel.IContainer components = null;

    private DataGridView dgvSuppliers;
    private TextBox txtSearch, txtCode, txtName, txtHotline, txtEmail;
    private Button btnSearch, btnAdd, btnUpdate, btnDelete;
    private GroupBox grpSearch, grpInfo;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
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

        grpSearch = new GroupBox();
        grpInfo = new GroupBox();

        // ================= SEARCH GROUP =================
        grpSearch.Text = "🔍 Tìm kiếm nhà cung cấp";
        grpSearch.SetBounds(10, 10, 780, 70);

        txtSearch.SetBounds(20, 30, 600, 28);

        btnSearch.Text = "Search";
        btnSearch.SetBounds(640, 28, 100, 30);
        btnSearch.Click += btnSearch_Click;

        grpSearch.Controls.AddRange(new Control[]
        {
            txtSearch, btnSearch
        });

        // ================= GRID =================
        dgvSuppliers.SetBounds(10, 90, 780, 200);
        dgvSuppliers.ReadOnly = true;
        dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvSuppliers.MultiSelect = false;
        dgvSuppliers.RowTemplate.Height = 30;
        dgvSuppliers.ColumnHeadersHeight = 40;
        dgvSuppliers.SelectionChanged += dgvSuppliers_SelectionChanged;

        // ================= INFO GROUP =================
        grpInfo.Text = "📋 Thông tin nhà cung cấp";
        grpInfo.SetBounds(10, 300, 780, 110);

        var lblCode = new Label { Text = "Mã NCC", Left = 20, Top = 30 };
        var lblName = new Label { Text = "Tên NCC", Left = 170, Top = 30 };
        var lblHotline = new Label { Text = "Hotline", Left = 380, Top = 30 };
        var lblEmail = new Label { Text = "Email", Left = 540, Top = 30 };

        txtCode.SetBounds(20, 55, 130, 25);
        txtCode.ReadOnly = true;

        txtName.SetBounds(170, 55, 190, 25);
        txtHotline.SetBounds(380, 55, 140, 25);
        txtEmail.SetBounds(540, 55, 220, 25);

        grpInfo.Controls.AddRange(new Control[]
        {
            lblCode, lblName, lblHotline, lblEmail,
            txtCode, txtName, txtHotline, txtEmail
        });

        // ================= BUTTONS =================
        btnAdd.Text = "Add";
        btnAdd.SetBounds(380, 420, 80, 32);
        btnAdd.Click += btnAdd_Click;

        btnUpdate.Text = "Update";
        btnUpdate.SetBounds(470, 420, 80, 32);
        btnUpdate.Click += btnUpdate_Click;

        btnDelete.Text = "Delete";
        btnDelete.SetBounds(560, 420, 80, 32);
        btnDelete.Click += btnDelete_Click;

        // ================= FORM =================
        Controls.AddRange(new Control[]
        {
            grpSearch,
            dgvSuppliers,
            grpInfo,
            btnAdd, btnUpdate, btnDelete
        });

        Text = "Supplier Management";
        ClientSize = new System.Drawing.Size(800, 470);
        StartPosition = FormStartPosition.CenterScreen;
        Load += SupplierForm_Load;
    }
}
