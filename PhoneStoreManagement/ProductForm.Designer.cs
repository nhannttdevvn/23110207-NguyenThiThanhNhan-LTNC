namespace PhoneStoreManagement.Winforms;

partial class ProductForm
{
    private System.ComponentModel.IContainer components = null;

    private Panel pnlHeader;
    private Label lblTitle;
    private GroupBox grpInput;
    private GroupBox grpSearch;
    private Panel pnlGridWrapper; // Panel phụ để tạo Margin cho DataGridView

    private DataGridView dgvProducts;
    private TextBox txtSearch, txtCode, txtName, txtSale;
    private ComboBox cboBrand, cboSupplier, cboOrigin, cboVariant;
    private Button btnSearch, btnAdd, btnUpdate, btnDelete;

    private Label lblCode, lblName, lblBrand, lblSale, lblSupplier, lblOrigin, lblVariant;

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
        dgvProducts = new DataGridView();

        txtSearch = new TextBox();
        txtCode = new TextBox();
        txtName = new TextBox();
        txtSale = new TextBox();
        cboBrand = new ComboBox();
        cboSupplier = new ComboBox();
        cboOrigin = new ComboBox();
        cboVariant = new ComboBox();

        btnSearch = new Button();
        btnAdd = new Button();
        btnUpdate = new Button();
        btnDelete = new Button();

        lblCode = new Label();
        lblName = new Label();
        lblBrand = new Label();
        lblSale = new Label();
        lblSupplier = new Label();
        lblOrigin = new Label();
        lblVariant = new Label();

        ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
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
        pnlHeader.Size = new Size(1200, 60);

        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(12, 13);
        lblTitle.Text = "QUẢN LÝ SẢN PHẨM";

        // ===== grpSearch =====
        grpSearch.Dock = DockStyle.Top;
        grpSearch.Height = 85;
        grpSearch.Text = "Tìm kiếm nhanh";
        grpSearch.Padding = new Padding(10);
        grpSearch.Location = new Point(0, 60);

        txtSearch.Location = new Point(20, 35);
        txtSearch.Size = new Size(400, 27);
        txtSearch.PlaceholderText = "Nhập tên sản phẩm cần tìm...";

        btnSearch.BackColor = Color.FromArgb(46, 204, 113);
        btnSearch.FlatStyle = FlatStyle.Flat;
        btnSearch.ForeColor = Color.White;
        btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnSearch.Location = new Point(430, 33);
        btnSearch.Size = new Size(120, 32);
        btnSearch.Text = "Tìm kiếm";
        btnSearch.Click += btnSearch_Click;
        grpSearch.Controls.AddRange(new Control[] { txtSearch, btnSearch });
        //in đậm
        btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

        // ===== grpInput =====
        grpInput.Dock = DockStyle.Left;
        grpInput.Width = 385;
        grpInput.Text = "Thông tin chi tiết sản phẩm";
        grpInput.Padding = new Padding(15);

        int labelX = 20;
        int inputX = 135;
        int y = 45;
        int gap = 48;
        int inputW = 220;

        lblCode.Text = "Mã SP:"; lblCode.Location = new Point(labelX, y); lblCode.AutoSize = true;
        txtCode.Location = new Point(inputX, y - 3); txtCode.Size = new Size(inputW, 25);
        txtCode.ReadOnly = true; txtCode.PlaceholderText = "[Tự động]";

        y += gap;
        lblName.Text = "Tên SP:"; lblName.Location = new Point(labelX, y); lblName.AutoSize = true;
        txtName.Location = new Point(inputX, y - 3); txtName.Size = new Size(inputW, 25);
        txtName.PlaceholderText = "Nhập tên sản phẩm...";

        y += gap;
        lblBrand.Text = "Hãng:"; lblBrand.Location = new Point(labelX, y); lblBrand.AutoSize = true;
        cboBrand.Location = new Point(inputX, y - 3); cboBrand.Size = new Size(inputW, 25);
        cboBrand.DropDownStyle = ComboBoxStyle.DropDownList;

        y += gap;
        lblVariant.Text = "Phiên bản:"; lblVariant.Location = new Point(labelX, y); lblVariant.AutoSize = true;
        cboVariant.Location = new Point(inputX, y - 3); cboVariant.Size = new Size(inputW, 25);
        cboVariant.DropDownStyle = ComboBoxStyle.DropDownList;

        y += gap;
        lblOrigin.Text = "Xuất xứ:"; lblOrigin.Location = new Point(labelX, y); lblOrigin.AutoSize = true;
        cboOrigin.Location = new Point(inputX, y - 3); cboOrigin.Size = new Size(inputW, 25);
        cboOrigin.DropDownStyle = ComboBoxStyle.DropDownList;

        y += gap;
        lblSale.Text = "Giá bán:"; lblSale.Location = new Point(labelX, y); lblSale.AutoSize = true;
        txtSale.Location = new Point(inputX, y - 3); txtSale.Size = new Size(inputW, 25);
        txtSale.PlaceholderText = "Ví dụ: 15000000";

        y += gap;
        lblSupplier.Text = "Nhà CC:"; lblSupplier.Location = new Point(labelX, y); lblSupplier.AutoSize = true;
        cboSupplier.Location = new Point(inputX, y - 3); cboSupplier.Size = new Size(inputW, 25);
        cboSupplier.DropDownStyle = ComboBoxStyle.DropDownList;

        y += gap + 25;
        btnAdd.Text = "Thêm"; btnAdd.BackColor = Color.DodgerBlue; btnAdd.ForeColor = Color.White;
        btnAdd.FlatStyle = FlatStyle.Flat; btnAdd.Location = new Point(20, y); btnAdd.Size = new Size(105, 42);
        btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnAdd.Click += btnAdd_Click;
        //in đậm
        btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

        btnUpdate.Text = "Sửa"; btnUpdate.BackColor = Color.Orange; btnUpdate.ForeColor = Color.White;
        btnUpdate.FlatStyle = FlatStyle.Flat; btnUpdate.Location = new Point(135, y); btnUpdate.Size = new Size(105, 42);
        btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnUpdate.Click += btnUpdate_Click;
        //in đậm
        btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

        btnDelete.Text = "Xóa"; btnDelete.BackColor = Color.Crimson; btnDelete.ForeColor = Color.White;
        btnDelete.FlatStyle = FlatStyle.Flat; btnDelete.Location = new Point(250, y); btnDelete.Size = new Size(105, 42);
        btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnDelete.Click += btnDelete_Click;
        //in đậm
        btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

        grpInput.Controls.AddRange(new Control[] {
            lblCode, txtCode, lblName, txtName, lblBrand, cboBrand,
            lblVariant, cboVariant, lblOrigin, cboOrigin, lblSale, txtSale,
            lblSupplier, cboSupplier, btnAdd, btnUpdate, btnDelete
        });

        // ===== pnlGridWrapper (Margin trái phải 15px, dưới 15px) =====
        pnlGridWrapper.Dock = DockStyle.Fill;
        pnlGridWrapper.Padding = new Padding(15, 0, 15, 15);
        pnlGridWrapper.BackColor = Color.White;

        // ===== dgvProducts (Style: Header xanh đậm, Select xanh nhạt, No Border) =====
        dgvProducts.Dock = DockStyle.Fill;
        dgvProducts.BackgroundColor = Color.White;
        dgvProducts.BorderStyle = BorderStyle.None;
        dgvProducts.EnableHeadersVisualStyles = false;
        dgvProducts.ReadOnly = true;
        dgvProducts.RowHeadersVisible = false;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // Header Style
        dgvProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
        dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvProducts.ColumnHeadersHeight = 40;

        // Selection Style
        dgvProducts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 234, 248);
        dgvProducts.DefaultCellStyle.SelectionForeColor = Color.Black;
        dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
        dgvProducts.RowTemplate.Height = 35;
        dgvProducts.GridColor = Color.FromArgb(236, 240, 241);

        dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
        pnlGridWrapper.Controls.Add(dgvProducts);

        // ===== Form Config =====
        ClientSize = new Size(1200, 750);
        Text = "Hệ thống Quản lý Sản phẩm - Phone Store";
        StartPosition = FormStartPosition.CenterScreen;
        Controls.Add(pnlGridWrapper);
        Controls.Add(grpInput);
        Controls.Add(grpSearch);
        Controls.Add(pnlHeader);

        ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        grpSearch.ResumeLayout(false);
        grpSearch.PerformLayout();
        grpInput.ResumeLayout(false);
        grpInput.PerformLayout();
        pnlGridWrapper.ResumeLayout(false);
        ResumeLayout(false);
    }
}