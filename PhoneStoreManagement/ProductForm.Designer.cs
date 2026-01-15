namespace PhoneStoreManagement.Winforms;

partial class ProductForm
{
    private System.ComponentModel.IContainer components = null;

    private DataGridView dgvProducts;
    private TextBox txtSearch, txtCode, txtName, txtSale;
    private ComboBox cboBrand, cboSupplier, cboOrigin, cboVariant;
    private NumericUpDown numWarranty;
    private Button btnSearch, btnAdd, btnUpdate, btnDelete;

    private Label lblCode, lblName, lblBrand;
    private Label lblSale, lblWarranty, lblSupplier, lblOrigin, lblVariant;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        dgvProducts = new DataGridView();
        txtSearch = new TextBox();
        txtCode = new TextBox();
        txtName = new TextBox();
        txtSale = new TextBox();

        cboBrand = new ComboBox();
        cboSupplier = new ComboBox();
        cboOrigin = new ComboBox();
        cboVariant = new ComboBox();

        numWarranty = new NumericUpDown();

        btnSearch = new Button();
        btnAdd = new Button();
        btnUpdate = new Button();
        btnDelete = new Button();

        lblCode = new Label();
        lblName = new Label();
        lblBrand = new Label();
        lblSale = new Label();
        lblWarranty = new Label();
        lblSupplier = new Label();
        lblOrigin = new Label();
        lblVariant = new Label();

        Text = "Product Management";
        ClientSize = new System.Drawing.Size(1000, 650);
        StartPosition = FormStartPosition.CenterScreen;

        txtSearch.SetBounds(20, 20, 300, 28);
        btnSearch.Text = "Search";
        btnSearch.SetBounds(330, 20, 90, 28);
        btnSearch.Click += btnSearch_Click;

        dgvProducts.SetBounds(20, 60, 960, 320);
        dgvProducts.ReadOnly = true;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;

        int labelW = 90;
        int controlW = 220;
        int h = 26;
        int col1X = 20;
        int col2X = 360;
        int controlOffset = labelW + 10;
        int y = 400;
        int gap = 36;

        lblCode.Text = "Mã SP";
        lblCode.SetBounds(col1X, y + 5, labelW, h);
        txtCode.SetBounds(col1X + controlOffset, y, controlW, h);
        txtCode.ReadOnly = true;

        lblBrand.Text = "Hãng";
        lblBrand.SetBounds(col2X, y + 5, labelW, h);
        cboBrand.SetBounds(col2X + controlOffset, y, controlW, h);

        y += gap;
        lblName.Text = "Tên SP";
        lblName.SetBounds(col1X, y + 5, labelW, h);
        txtName.SetBounds(col1X + controlOffset, y, controlW, h);

        lblOrigin.Text = "Xuất xứ";
        lblOrigin.SetBounds(col2X, y + 5, labelW, h);
        cboOrigin.SetBounds(col2X + controlOffset, y, controlW, h);

        y += gap;
        lblVariant.Text = "Phiên bản";
        lblVariant.SetBounds(col1X, y + 5, labelW, h);
        cboVariant.SetBounds(col1X + controlOffset, y, controlW, h);

        lblSale.Text = "Giá bán";
        lblSale.SetBounds(col2X, y + 5, labelW, h);
        txtSale.SetBounds(col2X + controlOffset, y, 150, h);

        y += gap;
        lblWarranty.Text = "BH (tháng)";
        lblWarranty.SetBounds(col1X, y + 5, labelW, h);
        numWarranty.SetBounds(col1X + controlOffset, y, 150, h);

        lblSupplier.Text = "Nhà CC";
        lblSupplier.SetBounds(col2X, y + 5, labelW, h);
        cboSupplier.SetBounds(col2X + controlOffset, y, 150, h);

        int btnY = 400;
        int btnX = 720;

        btnAdd.Text = "Add";
        btnAdd.SetBounds(btnX, btnY, 120, 32);
        btnAdd.Click += btnAdd_Click;

        btnUpdate.Text = "Update";
        btnUpdate.SetBounds(btnX, btnY + 42, 120, 32);
        btnUpdate.Click += btnUpdate_Click;

        btnDelete.Text = "Delete";
        btnDelete.SetBounds(btnX, btnY + 84, 120, 32);
        btnDelete.Click += btnDelete_Click;

        Controls.AddRange(new Control[]
        {
            txtSearch, btnSearch, dgvProducts,
            lblCode, txtCode,
            lblName, txtName,
            lblBrand, cboBrand,
            lblVariant, cboVariant,
            lblOrigin, cboOrigin,
            lblSale, txtSale,
            lblWarranty, numWarranty,
            lblSupplier, cboSupplier,
            btnAdd, btnUpdate, btnDelete
        });

        Load += ProductForm_Load;
    }
}
