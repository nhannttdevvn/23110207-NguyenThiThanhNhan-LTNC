namespace PhoneStoreManagement.Winforms
{
    partial class OrderCreateForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.GroupBox grpProduct;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlGridContainer;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.grpCustomer = new System.Windows.Forms.GroupBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.grpProduct = new System.Windows.Forms.GroupBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.pnlGridContainer = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblTotalText = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.grpCustomer.SuspendLayout();
            this.grpProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ===== pnlHeader =====
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblOrderNo);
            this.pnlHeader.Controls.Add(this.lblDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 100;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Text = "TẠO ĐƠN HÀNG MỚI";

            this.lblOrderNo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblOrderNo.ForeColor = System.Drawing.Color.White;
            this.lblOrderNo.Location = new System.Drawing.Point(22, 65);
            this.lblOrderNo.Size = new System.Drawing.Size(200, 25);
            this.lblOrderNo.Text = "Mã đơn: [Tự động]";

            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(250, 65);
            this.lblDate.Size = new System.Drawing.Size(300, 25);
            this.lblDate.Text = "Ngày: " + System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // ===== grpCustomer (Căn chỉnh lại khoảng cách X để không đè nhãn) =====
            this.grpCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCustomer.Height = 160;
            this.grpCustomer.Text = "Thông tin khách hàng & Nhân viên";
            this.grpCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCustomer.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);

            int row1Y = 40;
            int row2Y = 100;

            // SĐT
            this.lblPhone.Text = "SĐT:";
            this.lblPhone.Location = new System.Drawing.Point(25, row1Y + 3);
            this.lblPhone.AutoSize = true;
            this.txtPhone.Location = new System.Drawing.Point(75, row1Y);
            this.txtPhone.Size = new System.Drawing.Size(150, 25);
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

            // Tên khách hàng
            this.lblCustomer.Text = "Khách hàng:";
            this.lblCustomer.Location = new System.Drawing.Point(250, row1Y + 3);
            this.lblCustomer.AutoSize = true;
            this.txtCustomerName.Location = new System.Drawing.Point(345, row1Y);
            this.txtCustomerName.Size = new System.Drawing.Size(200, 25);
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

            // Nhân viên
            this.lblEmployee.Text = "Nhân viên:";
            this.lblEmployee.Location = new System.Drawing.Point(575, row1Y + 3);
            this.lblEmployee.AutoSize = true;
            this.cboEmployee.Location = new System.Drawing.Point(660, row1Y);
            this.cboEmployee.Size = new System.Drawing.Size(200, 25);
            this.cboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployee.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

            // Địa chỉ
            this.lblAddress.Text = "Địa chỉ:";
            this.lblAddress.Location = new System.Drawing.Point(25, row2Y + 3);
            this.lblAddress.AutoSize = true;
            this.txtAddress.Location = new System.Drawing.Point(75, row2Y);
            this.txtAddress.Size = new System.Drawing.Size(785, 25);
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

            this.grpCustomer.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblPhone, this.txtPhone, this.lblCustomer, this.txtCustomerName,
                this.lblEmployee, this.cboEmployee, this.lblAddress, this.txtAddress
            });

            // ===== grpProduct =====
            this.grpProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpProduct.Height = 110;
            this.grpProduct.Text = "Chi tiết mặt hàng";
            this.grpProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            int pY = 45;
            this.lblProduct.Text = "Sản phẩm:";
            this.lblProduct.Location = new System.Drawing.Point(25, pY + 3);
            this.lblProduct.AutoSize = true;
            this.cboProduct.Location = new System.Drawing.Point(105, pY);
            this.cboProduct.Size = new System.Drawing.Size(350, 25);
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

            this.lblQty.Text = "Số lượng:";
            this.lblQty.Location = new System.Drawing.Point(480, pY + 3);
            this.lblQty.AutoSize = true;
            this.numQty.Location = new System.Drawing.Point(555, pY);
            this.numQty.Size = new System.Drawing.Size(70, 25);
            this.numQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numQty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

            this.btnAdd.Text = "Thêm";
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Location = new System.Drawing.Point(650, pY - 5);
            this.btnAdd.Size = new System.Drawing.Size(100, 35);
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.btnRemove.Text = "Xóa";
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.Location = new System.Drawing.Point(760, pY - 5);
            this.btnRemove.Size = new System.Drawing.Size(100, 35);
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.grpProduct.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblProduct, this.cboProduct, this.lblQty, this.numQty, this.btnAdd, this.btnRemove
            });

            // ===== dgvItems (Thiết kế hiện đại) =====
            this.pnlGridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridContainer.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlGridContainer.BackColor = System.Drawing.Color.White;

            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItems.EnableHeadersVisualStyles = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowTemplate.Height = 35;
            this.dgvItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));

            // Header xanh đậm
            this.dgvItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvItems.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvItems.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvItems.ColumnHeadersHeight = 40;

            // Select xanh nhạt
            this.dgvItems.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.dgvItems.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            this.pnlGridContainer.Controls.Add(this.dgvItems);

            // ===== pnlFooter =====
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 90;
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));

            this.lblTotalText.Text = "Tổng thanh toán:";
            this.lblTotalText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalText.Location = new System.Drawing.Point(25, 32);
            this.lblTotalText.AutoSize = true;

            this.lblTotal.Text = "0 VNĐ";
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTotal.Location = new System.Drawing.Point(210, 26);
            this.lblTotal.Size = new System.Drawing.Size(350, 40);

            this.btnCreateOrder.Text = "Xác nhận tạo đơn";
            this.btnCreateOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnCreateOrder.ForeColor = System.Drawing.Color.White;
            this.btnCreateOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateOrder.FlatAppearance.BorderSize = 0;
            this.btnCreateOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreateOrder.Location = new System.Drawing.Point(770, 22);
            this.btnCreateOrder.Size = new System.Drawing.Size(200, 48);

            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(650, 22);
            this.btnCancel.Size = new System.Drawing.Size(110, 48);

            this.pnlFooter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTotalText, this.lblTotal, this.btnCreateOrder, this.btnCancel
            });

            // ===== Form Main Config =====
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.Controls.Add(this.pnlGridContainer);
            this.Controls.Add(this.grpProduct);
            this.Controls.Add(this.grpCustomer);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "OrderCreateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Bán hàng - Phone Store Management";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpCustomer.ResumeLayout(false);
            this.grpCustomer.PerformLayout();
            this.grpProduct.ResumeLayout(false);
            this.grpProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}