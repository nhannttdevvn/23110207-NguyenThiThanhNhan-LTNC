namespace PhoneStoreManagement.Winforms;

partial class MenuForm
{
    private System.ComponentModel.IContainer components = null;

    private Panel pnlHeader;
    private Label lblTitle;
    private Panel pnlSidebar;
    private Panel pnlContent;
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
        pnlHeader = new Panel();
        lblTitle = new Label();
        pnlSidebar = new Panel();
        pnlContent = new Panel();
        btnProduct = new Button();
        btnSupplier = new Button();
        btnEmployee = new Button();
        btnWarehouse = new Button();
        btnOrder = new Button();
        btnStat = new Button();
        btnWarranty = new Button();

        pnlHeader.SuspendLayout();
        pnlSidebar.SuspendLayout();
        SuspendLayout();

        // pnlHeader
        pnlHeader.BackColor = Color.FromArgb(41, 128, 185);
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Height = 70;

        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(20, 15);
        lblTitle.Text = "HỆ THỐNG QUẢN LÝ CỬA HÀNG";

        // pnlSidebar
        pnlSidebar.BackColor = Color.FromArgb(52, 73, 94);
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Width = 250;
        pnlSidebar.Padding = new Padding(10, 20, 10, 0);

        // Sidebar Buttons Configuration
        ConfigureMenuButton(btnProduct, "Sản phẩm", 0);
        ConfigureMenuButton(btnSupplier, "Nhà cung cấp", 1);
        ConfigureMenuButton(btnEmployee, "Nhân viên", 2);
        ConfigureMenuButton(btnWarehouse, "Kho hàng", 3);
        ConfigureMenuButton(btnOrder, "Đơn hàng", 4);
        ConfigureMenuButton(btnStat, "Thống kê", 5);
        ConfigureMenuButton(btnWarranty, "Bảo hành", 6);

        btnProduct.Click += btnProduct_Click;
        btnSupplier.Click += btnSupplier_Click;
        btnEmployee.Click += btnEmployee_Click;
        btnWarehouse.Click += btnWarehouse_Click;
        btnOrder.Click += btnOrder_Click;
        btnStat.Click += btnStat_Click;
        btnWarranty.Click += btnWarranty_Click;

        // pnlContent
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.BackColor = Color.WhiteSmoke;

        // MenuForm
        ClientSize = new Size(1200, 750);
        Controls.Add(pnlContent);
        Controls.Add(pnlSidebar);
        Controls.Add(pnlHeader);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Phone Store Management System";

        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        pnlSidebar.ResumeLayout(false);
        ResumeLayout(false);
    }

    private void ConfigureMenuButton(Button btn, string text, int index)
    {
        btn.Text = text;
        btn.Dock = DockStyle.Top;
        btn.Height = 50;
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.ForeColor = Color.White;
        btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btn.TextAlign = ContentAlignment.MiddleLeft;
        btn.Padding = new Padding(20, 0, 0, 0);
        btn.Margin = new Padding(0, 0, 0, 5);
        btn.BackColor = Color.Transparent;
        btn.Cursor = Cursors.Hand;
        pnlSidebar.Controls.Add(btn);
        btn.BringToFront();
    }
}