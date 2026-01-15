namespace PhoneStoreManagement.Winforms
{
    partial class InvoiceDetailForm
    {
        private Label lblInvoiceId, lblCustomer, lblPhone, lblAddress, lblDate, lblEmployee, lblTotal;
        private DataGridView dgvItems;

        private void InitializeComponent()
        {
            lblInvoiceId = new Label();
            lblCustomer = new Label();
            lblPhone = new Label();
            lblAddress = new Label();
            lblDate = new Label();
            lblEmployee = new Label();
            lblTotal = new Label();
            dgvItems = new DataGridView();

            Text = "Chi tiết hóa đơn";
            ClientSize = new System.Drawing.Size(700, 500);
            StartPosition = FormStartPosition.CenterScreen;

            lblInvoiceId.SetBounds(20, 20, 300, 25);
            lblCustomer.SetBounds(20, 50, 300, 25);
            lblPhone.SetBounds(20, 80, 300, 25);
            lblAddress.SetBounds(20, 110, 500, 25);
            lblDate.SetBounds(360, 20, 300, 25);
            lblEmployee.SetBounds(360, 50, 300, 25);
            lblTotal.SetBounds(360, 80, 300, 25);

            dgvItems.SetBounds(20, 150, 650, 300);
            dgvItems.ReadOnly = true;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Controls.AddRange(new Control[]
            {
            lblInvoiceId, lblCustomer, lblPhone, lblAddress,
            lblDate, lblEmployee, lblTotal, dgvItems
            });

            Load += InvoiceDetailForm_Load;
        }
    }

}