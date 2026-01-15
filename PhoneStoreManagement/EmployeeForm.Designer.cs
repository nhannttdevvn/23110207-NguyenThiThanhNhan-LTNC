namespace PhoneStoreManagement.Winforms;

partial class EmployeeForm
{
    private System.ComponentModel.IContainer components = null;

    private DataGridView dgvEmployees;

    private Label lblEmployeeCode;
    private Label lblFullName;
    private Label lblPhone;
    private Label lblEmail;
    private Label lblHomeTown;
    private Label lblUsername;
    private Label lblSearch;

    private TextBox txtEmployeeCode;
    private TextBox txtFullName;
    private TextBox txtPhone;
    private TextBox txtEmail;
    private TextBox txtHomeTown;
    private TextBox txtUsername;
    private TextBox txtSearch;

    private Button btnAdd;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnSearch;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        dgvEmployees = new DataGridView();

        lblEmployeeCode = new Label();
        lblFullName = new Label();
        lblPhone = new Label();
        lblEmail = new Label();
        lblHomeTown = new Label();
        lblUsername = new Label();
        lblSearch = new Label();

        txtEmployeeCode = new TextBox();
        txtFullName = new TextBox();
        txtPhone = new TextBox();
        txtEmail = new TextBox();
        txtHomeTown = new TextBox();
        txtUsername = new TextBox();
        txtSearch = new TextBox();

        btnAdd = new Button();
        btnUpdate = new Button();
        btnDelete = new Button();
        btnSearch = new Button();

        ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
        SuspendLayout();

        // ===== FORM =====
        Text = "Quản lý nhân viên";
        ClientSize = new Size(1000, 520);
        StartPosition = FormStartPosition.CenterScreen;

        // ===== LAYOUT CONFIG =====
        int labelW = 100;
        int inputW = 220;
        int rowH = 26;
        int gapY = 36;

        int leftX = 20;
        int rightX = 360;
        int y = 20;

        // ===== SEARCH =====
        lblSearch.Text = "Tìm kiếm";
        lblSearch.SetBounds(rightX, y + 5, labelW, rowH);

        txtSearch.SetBounds(rightX + labelW + 10, y, 220, rowH);
        txtSearch.TextChanged += txtSearch_TextChanged;

        btnSearch.Text = "Search";
        btnSearch.SetBounds(rightX + labelW + 240, y - 1, 90, 30);
        btnSearch.Click += btnSearch_Click;

        // ===== INPUT =====
        y += gapY;

        lblEmployeeCode.Text = "Mã NV";
        lblEmployeeCode.SetBounds(leftX, y + 5, labelW, rowH);
        txtEmployeeCode.SetBounds(leftX + labelW + 10, y, inputW, rowH);
        txtEmployeeCode.ReadOnly = true;

        y += gapY;
        lblFullName.Text = "Họ tên";
        lblFullName.SetBounds(leftX, y + 5, labelW, rowH);
        txtFullName.SetBounds(leftX + labelW + 10, y, inputW, rowH);

        y += gapY;
        lblPhone.Text = "SĐT";
        lblPhone.SetBounds(leftX, y + 5, labelW, rowH);
        txtPhone.SetBounds(leftX + labelW + 10, y, inputW, rowH);

        y += gapY;
        lblEmail.Text = "Email";
        lblEmail.SetBounds(leftX, y + 5, labelW, rowH);
        txtEmail.SetBounds(leftX + labelW + 10, y, inputW, rowH);

        y += gapY;
        lblHomeTown.Text = "Quê quán";
        lblHomeTown.SetBounds(leftX, y + 5, labelW, rowH);
        txtHomeTown.SetBounds(leftX + labelW + 10, y, inputW, rowH);

        y += gapY;
        lblUsername.Text = "Tài khoản";
        lblUsername.SetBounds(leftX, y + 5, labelW, rowH);
        txtUsername.SetBounds(leftX + labelW + 10, y, inputW, rowH);

        // ===== BUTTONS =====
        y += gapY + 10;

        btnAdd.Text = "Thêm";
        btnAdd.SetBounds(leftX, y, 90, 32);
        btnAdd.Click += btnAdd_Click;

        btnUpdate.Text = "Sửa";
        btnUpdate.SetBounds(leftX + 100, y, 90, 32);
        btnUpdate.Click += btnUpdate_Click;

        btnDelete.Text = "Xóa";
        btnDelete.SetBounds(leftX + 200, y, 90, 32);
        btnDelete.Click += btnDelete_Click;

        // ===== GRID =====
        dgvEmployees.SetBounds(rightX, 70, 600, 380);
        dgvEmployees.ReadOnly = true;
        dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvEmployees.CellClick += dgvEmployees_CellClick;

        // ===== ADD CONTROLS =====
        Controls.AddRange(new Control[]
        {
        lblSearch, txtSearch, btnSearch,

        lblEmployeeCode, txtEmployeeCode,
        lblFullName, txtFullName,
        lblPhone, txtPhone,
        lblEmail, txtEmail,
        lblHomeTown, txtHomeTown,
        lblUsername, txtUsername,

        btnAdd, btnUpdate, btnDelete,
        dgvEmployees
        });

        ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

}
