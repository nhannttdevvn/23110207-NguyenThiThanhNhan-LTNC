namespace PhoneStoreManagement.Winforms;

partial class EmployeeForm
{
    private System.ComponentModel.IContainer components = null;

    private Panel pnlHeader;
    private Label lblTitle;
    private GroupBox grpInput;
    private GroupBox grpSearch;
    private Panel pnlGridWrapper; // Panel phụ để tạo Margin

    private Label lblEmployeeCode;
    private Label lblFullName;
    private Label lblPhone;
    private Label lblEmail;
    private Label lblHomeTown;
    private Label lblUsername;

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
    private DataGridView dgvEmployees;

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
        grpInput = new GroupBox();
        grpSearch = new GroupBox();
        pnlGridWrapper = new Panel();
        dgvEmployees = new DataGridView();

        lblEmployeeCode = new Label();
        lblFullName = new Label();
        lblPhone = new Label();
        lblEmail = new Label();
        lblHomeTown = new Label();
        lblUsername = new Label();

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
        pnlHeader.SuspendLayout();
        grpInput.SuspendLayout();
        grpSearch.SuspendLayout();
        pnlGridWrapper.SuspendLayout();
        SuspendLayout();

        // ===== pnlHeader =====
        pnlHeader.BackColor = Color.FromArgb(52, 152, 219);
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(1100, 60);

        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(12, 13);
        lblTitle.Text = "QUẢN LÝ NHÂN VIÊN";

        // ===== grpSearch =====
        grpSearch.Controls.Add(txtSearch);
        grpSearch.Controls.Add(btnSearch);
        grpSearch.Dock = DockStyle.Top;
        grpSearch.Font = new Font("Segoe UI", 10F);
        grpSearch.Location = new Point(0, 60);
        grpSearch.Size = new Size(1100, 80);
        grpSearch.Text = "Tìm kiếm";

        txtSearch.Location = new Point(20, 35);
        txtSearch.Size = new Size(350, 29);

        btnSearch.BackColor = Color.FromArgb(46, 204, 113);
        btnSearch.FlatStyle = FlatStyle.Flat;
        btnSearch.ForeColor = Color.White;
        btnSearch.Location = new Point(380, 33);
        btnSearch.Size = new Size(100, 33);
        btnSearch.Text = "Tìm kiếm";
        //in đậm
        btnSearch.Font = new Font(btnSearch.Font, FontStyle.Bold);
        btnSearch.UseVisualStyleBackColor = false;

        // ===== grpInput (Left Side) =====
        grpInput.Dock = DockStyle.Left;
        grpInput.Width = 350;
        grpInput.Text = "Thông tin chi tiết";
        grpInput.Font = new Font("Segoe UI", 9F);

        int labelX = 15;
        int inputX = 110;
        int y = 40;
        int gap = 40;

        lblEmployeeCode.Text = "Mã NV:";
        lblEmployeeCode.Location = new Point(labelX, y);
        txtEmployeeCode.Location = new Point(inputX, y - 3);
        txtEmployeeCode.Size = new Size(220, 25);
        txtEmployeeCode.ReadOnly = true;

        y += gap;
        lblFullName.Text = "Họ tên:";
        lblFullName.Location = new Point(labelX, y);
        txtFullName.Location = new Point(inputX, y - 3);
        txtFullName.Size = new Size(220, 25);

        y += gap;
        lblPhone.Text = "SĐT:";
        lblPhone.Location = new Point(labelX, y);
        txtPhone.Location = new Point(inputX, y - 3);
        txtPhone.Size = new Size(220, 25);

        y += gap;
        lblEmail.Text = "Email:";
        lblEmail.Location = new Point(labelX, y);
        txtEmail.Location = new Point(inputX, y - 3);
        txtEmail.Size = new Size(220, 25);

        y += gap;
        lblHomeTown.Text = "Quê quán:";
        lblHomeTown.Location = new Point(labelX, y);
        txtHomeTown.Location = new Point(inputX, y - 3);
        txtHomeTown.Size = new Size(220, 25);

        y += gap;
        lblUsername.Text = "Tài khoản:";
        lblUsername.Location = new Point(labelX, y);
        txtUsername.Location = new Point(inputX, y - 3);
        txtUsername.Size = new Size(220, 25);

        y += gap + 20;
        btnAdd.Text = "Thêm";
        btnAdd.BackColor = Color.DodgerBlue;
        btnAdd.ForeColor = Color.White;
        btnAdd.FlatStyle = FlatStyle.Flat;
        btnAdd.Location = new Point(20, y);
        btnAdd.Size = new Size(90, 35);
        //in đậm
        btnAdd.Font = new Font(btnAdd.Font, FontStyle.Bold);

        btnUpdate.Text = "Sửa";
        btnUpdate.BackColor = Color.Orange;
        btnUpdate.ForeColor = Color.White;
        btnUpdate.FlatStyle = FlatStyle.Flat;
        btnUpdate.Location = new Point(120, y);
        btnUpdate.Size = new Size(90, 35);
        //in đậm
        btnUpdate.Font = new Font(btnUpdate.Font, FontStyle.Bold);
        btnDelete.Text = "Xóa";
        btnDelete.BackColor = Color.Crimson;
        btnDelete.ForeColor = Color.White;
        btnDelete.FlatStyle = FlatStyle.Flat;
        btnDelete.Location = new Point(220, y);
        btnDelete.Size = new Size(90, 35);
        //in đậm
        btnDelete.Font = new Font(btnDelete.Font, FontStyle.Bold);

        grpInput.Controls.AddRange(new Control[] {
            lblEmployeeCode, txtEmployeeCode, lblFullName, txtFullName,
            lblPhone, txtPhone, lblEmail, txtEmail, lblHomeTown, txtHomeTown,
            lblUsername, txtUsername, btnAdd, btnUpdate, btnDelete
        });

        // ===== pnlGridWrapper (Margin cho DataGridView) =====
        pnlGridWrapper.Dock = DockStyle.Fill;
        pnlGridWrapper.Padding = new Padding(15, 0, 15, 15);
        pnlGridWrapper.BackColor = Color.White;
        pnlGridWrapper.Controls.Add(dgvEmployees);

        // ===== dgvEmployees Style =====
        dgvEmployees.Dock = DockStyle.Fill;
        dgvEmployees.BackgroundColor = Color.White;
        dgvEmployees.BorderStyle = BorderStyle.None;
        dgvEmployees.EnableHeadersVisualStyles = false;
        dgvEmployees.ReadOnly = true;
        dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvEmployees.RowHeadersVisible = false;
        dgvEmployees.GridColor = Color.FromArgb(236, 240, 241);

        // Header Style (Xanh đậm)
        dgvEmployees.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
        dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvEmployees.ColumnHeadersHeight = 40;

        // Selection Style (Xanh nhạt)
        dgvEmployees.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 234, 248);
        dgvEmployees.DefaultCellStyle.SelectionForeColor = Color.Black;
        dgvEmployees.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
        dgvEmployees.RowTemplate.Height = 35;

        // ===== Form Config =====
        ClientSize = new Size(1100, 600);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Quản lý nhân viên";
        Controls.Add(pnlGridWrapper);
        Controls.Add(grpInput);
        Controls.Add(grpSearch);
        Controls.Add(pnlHeader);

        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        grpSearch.ResumeLayout(false);
        grpSearch.PerformLayout();
        grpInput.ResumeLayout(false);
        grpInput.PerformLayout();
        pnlGridWrapper.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
        ResumeLayout(false);
    }
}