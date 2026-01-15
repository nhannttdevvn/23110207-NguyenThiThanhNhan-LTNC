namespace PhoneStoreManagement.Winforms
{
    partial class OrderCreateForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblTotalText;

        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;

        private System.Windows.Forms.ComboBox cboEmployee;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.NumericUpDown numQty;

        private System.Windows.Forms.DataGridView dgvItems;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblOrderNo = new Label();
            lblDate = new Label();
            lblTotal = new Label();
            lblTotalText = new Label();

            lblCustomer = new Label();
            lblPhone = new Label();
            lblAddress = new Label();
            lblEmployee = new Label();
            lblProduct = new Label();
            lblQty = new Label();

            txtCustomerName = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();

            cboEmployee = new ComboBox();
            cboProduct = new ComboBox();
            numQty = new NumericUpDown();

            dgvItems = new DataGridView();

            btnAdd = new Button();
            btnRemove = new Button();
            btnCreateOrder = new Button();
            btnCancel = new Button();

            ((System.ComponentModel.ISupportInitialize)(numQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dgvItems)).BeginInit();
            SuspendLayout();

            // ===== FORM =====
            Text = "Tạo đơn hàng";
            ClientSize = new System.Drawing.Size(620, 600);
            StartPosition = FormStartPosition.CenterScreen;

            // ===== HEADER =====
            lblOrderNo.Text = "Mã đơn:";
            lblOrderNo.SetBounds(20, 15, 100, 25);

            lblDate.Text = "Ngày:";
            lblDate.SetBounds(360, 15, 100, 25);

            // ===== LAYOUT =====
            int labelW = 90;
            int inputW = 200;
            int rowH = 26;
            int gapY = 36;

            int col1X = 20;
            int col2X = 330;
            int y = 50;

            // ===== CUSTOMER =====
            lblCustomer.Text = "Khách hàng";
            lblCustomer.SetBounds(col1X, y + 5, labelW, rowH);
            txtCustomerName.SetBounds(col1X + labelW + 10, y , inputW, rowH);

            lblPhone.Text = "SĐT";
            lblPhone.SetBounds(col2X, y + 5, 50, rowH);
            txtPhone.SetBounds(col2X + 50, y, inputW, rowH);

            // ===== ADDRESS =====
            y += gapY;
            lblAddress.Text = "Địa chỉ";
            lblAddress.SetBounds(col1X, y + 5, labelW, rowH);
            txtAddress.SetBounds(col1X + labelW + 10, y, 460, rowH);

            // ===== EMPLOYEE =====
            y += gapY;
            lblEmployee.Text = "Nhân viên";
            lblEmployee.SetBounds(col1X, y + 5, labelW, rowH);
            cboEmployee.SetBounds(col1X + labelW + 10, y, inputW, rowH);
            cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList;

            // ===== PRODUCT =====
            y += gapY + 10;
            lblProduct.Text = "Sản phẩm";
            lblProduct.SetBounds(col1X, y + 5, labelW, rowH);
            cboProduct.SetBounds(col1X + labelW + 10, y, 260, rowH);
            cboProduct.DropDownStyle = ComboBoxStyle.DropDownList;

            lblQty.Text = "SL";
            lblQty.SetBounds(col2X + 20, y + 5, 40, rowH);
            numQty.SetBounds(col2X + 60, y, 80, rowH);
            numQty.Minimum = 1;
            numQty.Maximum = 1000;

            btnAdd.Text = "Thêm";
            btnAdd.SetBounds(col2X + 150, y - 1, 100, 30);
            btnAdd.Click += btnAdd_Click;

            // ===== GRID =====
            dgvItems.SetBounds(20, y + 50, 580, 230);
            dgvItems.ReadOnly = true;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ===== BOTTOM =====
            y = dgvItems.Bottom + 15;

            btnRemove.Text = "Xóa SP";
            btnRemove.SetBounds(20, y, 100, 32);
            btnRemove.Click += btnRemove_Click;

            lblTotalText.Text = "Tổng tiền:";
            lblTotalText.SetBounds(360, y + 6, 80, rowH);

            lblTotal.SetBounds(450, y + 6, 150, rowH);

            btnCreateOrder.Text = "Tạo đơn";
            btnCreateOrder.SetBounds(330, y + 45, 120, 36);
            btnCreateOrder.Click += btnCreateOrder_Click;

            btnCancel.Text = "Hủy";
            btnCancel.SetBounds(480, y + 45, 120, 36);
            btnCancel.Click += btnCancel_Click;

            // ===== ADD CONTROLS =====
            Controls.AddRange(new Control[]
            {
        lblOrderNo, lblDate,

        lblCustomer, txtCustomerName,
        lblPhone, txtPhone,
        lblAddress, txtAddress,
        lblEmployee, cboEmployee,

        lblProduct, cboProduct,
        lblQty, numQty,
        btnAdd,

        dgvItems,

        btnRemove,
        lblTotalText, lblTotal,
        btnCreateOrder, btnCancel
            });

            ((System.ComponentModel.ISupportInitialize)(numQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dgvItems)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}