namespace PhoneStoreManagement.Winforms;

partial class ImportWarehouseForm
{
    private ComboBox cboProduct;
    private TextBox txtProductCode;
    private NumericUpDown numQuantity;
    private Button btnSave;
    private Button btnCancel;
    private Label lblProduct;
    private Label lblCode;
    private Label lblQty;

    private void InitializeComponent()
    {
        cboProduct = new ComboBox();
        txtProductCode = new TextBox();
        numQuantity = new NumericUpDown();
        btnSave = new Button();
        btnCancel = new Button();
        lblProduct = new Label();
        lblCode = new Label();
        lblQty = new Label();

        SuspendLayout();

        // Label
        lblProduct.Text = "Sản phẩm";
        lblProduct.Location = new Point(20, 20);

        cboProduct.Location = new Point(20, 40);
        cboProduct.Width = 260;
        cboProduct.DropDownStyle = ComboBoxStyle.DropDownList;
        cboProduct.SelectedIndexChanged += cboProduct_SelectedIndexChanged;

        lblCode.Text = "Mã sản phẩm";
        lblCode.Location = new Point(20, 75);

        txtProductCode.Location = new Point(20, 95);
        txtProductCode.ReadOnly = true;
        txtProductCode.Width = 260;

        lblQty.Text = "Số lượng nhập";
        lblQty.Location = new Point(20, 130);

        numQuantity.Location = new Point(20, 150);
        numQuantity.Minimum = 1;
        numQuantity.Maximum = 100000;
        numQuantity.Value = 1;

        btnSave.Text = "Nhập kho";
        btnSave.Location = new Point(20, 190);
        btnSave.Click += btnSave_Click;

        btnCancel.Text = "Hủy";
        btnCancel.Location = new Point(130, 190);
        btnCancel.Click += (s, e) => Close();

        ClientSize = new Size(320, 240);
        Text = "Nhập kho";

        Controls.AddRange(new Control[]
        {
            lblProduct, cboProduct,
            lblCode, txtProductCode,
            lblQty, numQuantity,
            btnSave, btnCancel
        });

        ResumeLayout(false);
    }
}
