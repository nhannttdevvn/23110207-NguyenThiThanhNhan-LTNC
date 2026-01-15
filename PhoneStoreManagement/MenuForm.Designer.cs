namespace PhoneStoreManagement.Winforms;

partial class MenuForm
{
    private System.ComponentModel.IContainer components = null;

    private Button btnProduct;
    private Button btnSupplier;
    private Button btnEmployee;
    private Button btnWarehouse;
    private Button btnOrder;
    private Button btnStat;
    private Button btnWarranty;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        btnProduct = new Button();
        btnSupplier = new Button();
        btnEmployee = new Button();
        btnWarehouse = new Button();
        btnOrder = new Button();
        btnStat = new Button();
        btnWarranty = new Button();

        btnProduct.Text = "Products";
        btnSupplier.Text = "Suppliers";
        btnEmployee.Text = "Employees";
        btnWarehouse.Text = "Warehouse";
        btnOrder.Text = "Orders";
        btnStat.Text = "Statistics";
        btnWarranty.Text = "Warranty";

        btnProduct.SetBounds(30, 20, 200, 35);
        btnSupplier.SetBounds(30, 60, 200, 35);
        btnEmployee.SetBounds(30, 100, 200, 35);
        btnWarehouse.SetBounds(30, 140, 200, 35);
        btnOrder.SetBounds(30, 180, 200, 35);
        btnStat.SetBounds(30, 220, 200, 35);
        btnWarranty.SetBounds(30, 260, 200, 35);

        btnProduct.Click += btnProduct_Click;
        btnSupplier.Click += btnSupplier_Click;
        btnEmployee.Click += btnEmployee_Click;
        btnWarehouse.Click += btnWarehouse_Click;
        btnOrder.Click += btnOrder_Click;
        btnStat.Click += btnStat_Click;
        btnWarranty.Click += btnWarranty_Click;

        Controls.AddRange(new Control[]
        {
            btnProduct, btnSupplier, btnEmployee,
            btnWarehouse, btnOrder,  btnStat, btnWarranty
        });

        Text = "Phone Store Management";
        ClientSize = new System.Drawing.Size(300, 300);
        StartPosition = FormStartPosition.CenterScreen;
    }
}
