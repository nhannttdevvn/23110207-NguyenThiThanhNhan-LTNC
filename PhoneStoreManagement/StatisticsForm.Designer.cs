namespace PhoneStoreManagement.Winforms
{
    partial class StatisticForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvInvoices;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnExportExcel;
        private Label lblTotalRevenue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvInvoices = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnExportExcel = new Button();
            lblTotalRevenue = new Label();

            SuspendLayout();

            // dgvInvoices
            dgvInvoices.AllowUserToAddRows = false;
            dgvInvoices.AllowUserToDeleteRows = false;
            dgvInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoices.Location = new System.Drawing.Point(12, 50);
            dgvInvoices.MultiSelect = false;
            dgvInvoices.ReadOnly = true;
            dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoices.Size = new System.Drawing.Size(960, 420);
            dgvInvoices.CellDoubleClick += dgvInvoices_CellDoubleClick;

            // txtSearch
            txtSearch.Location = new System.Drawing.Point(12, 12);
            txtSearch.Size = new System.Drawing.Size(200, 23);

            // btnSearch
            btnSearch.Location = new System.Drawing.Point(220, 11);
            btnSearch.Size = new System.Drawing.Size(75, 25);
            btnSearch.Text = "Search";
            btnSearch.Click += btnSearch_Click;

            // btnExportExcel
            btnExportExcel.Location = new System.Drawing.Point(300, 11);
            btnExportExcel.Size = new System.Drawing.Size(120, 25);
            btnExportExcel.Text = "Export Excel";
            btnExportExcel.Click += btnExportExcel_Click;

            // lblTotalRevenue
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblTotalRevenue.Location = new System.Drawing.Point(12, 480);
            lblTotalRevenue.Text = "Tổng doanh thu: 0 VNĐ";

            // StatisticForm
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 520);
            Controls.Add(lblTotalRevenue);
            Controls.Add(btnExportExcel);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvInvoices);
            Text = "Statistic Management";
            Load += StatisticForm_Load;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
