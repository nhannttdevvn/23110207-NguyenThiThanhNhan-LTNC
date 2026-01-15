using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement.Winforms
{
    public partial class SupplierForm : Form
    {
        private readonly ISupplierService _svc;
        private CancellationTokenSource _cts = new();

        public SupplierForm(ISupplierService svc)
        {
            _svc = svc;
            InitializeComponent();
        }

        private async void SupplierForm_Load(object sender, System.EventArgs e)
        {
            dgvSuppliers.AutoGenerateColumns = false;
            dgvSuppliers.Columns.Clear();

            dgvSuppliers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SupplierId", HeaderText = "Mã NCC" });
            dgvSuppliers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SupplierName", HeaderText = "Tên NCC" });
            dgvSuppliers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Phone", HeaderText = "Hotline" });
            dgvSuppliers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email" });

            await LoadDataAsync();
        }

        private void dgvSuppliers_SelectionChanged(object sender, System.EventArgs e)
        {
            if (dgvSuppliers.CurrentRow?.DataBoundItem is not Supplier s) return;

            txtCode.Text = s.SupplierId.ToString();
            txtName.Text = s.SupplierName;
            txtHotline.Text = s.Phone;
            txtEmail.Text = s.Email;
        }

        private async Task LoadDataAsync(string keyword = "")
        {
            dgvSuppliers.DataSource = await _svc.SearchAsync(keyword, _cts.Token);
        }

        private async Task<bool> ValidateSupplierAsync(int? ignoreId = null)
        {
            var name = txtName.Text.Trim();
            var phone = txtHotline.Text.Trim();
            var email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống");
                return false;
            }

            if (phone.StartsWith("+84"))
                phone = phone.Replace("+84", "0");

            txtHotline.Text = phone;

            if (!Regex.IsMatch(phone, @"^0\d{9,10}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                return false;
            }

            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[A-Za-z]{2,}$"))
            {
                MessageBox.Show("Email không hợp lệ");
                return false;
            }

            if (await _svc.ExistsPhoneAsync(phone, ignoreId))
            {
                MessageBox.Show("Số điện thoại đã tồn tại");
                return false;
            }

            if (await _svc.ExistsEmailAsync(email, ignoreId))
            {
                MessageBox.Show("Email đã tồn tại");
                return false;
            }

            return true;
        }

        private async void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (!await ValidateSupplierAsync()) return;

            var s = new Supplier
            {
                SupplierName = txtName.Text.Trim(),
                Phone = txtHotline.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            await _svc.CreateAsync(s);
            await LoadDataAsync();
        }

        private async void btnUpdate_Click(object sender, System.EventArgs e)
        {
            if (dgvSuppliers.CurrentRow?.DataBoundItem is not Supplier s) return;
            if (!await ValidateSupplierAsync(s.SupplierId)) return;

            s.SupplierName = txtName.Text.Trim();
            s.Phone = txtHotline.Text.Trim();
            s.Email = txtEmail.Text.Trim();

            await _svc.UpdateAsync(s);
            await LoadDataAsync();
        }

        private async void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (dgvSuppliers.CurrentRow?.DataBoundItem is not Supplier s) return;

            if (MessageBox.Show("Xóa nhà cung cấp này?", "Confirm",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                await _svc.DeleteAsync(s.SupplierId);
                await LoadDataAsync();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Không thể xóa vì còn sản phẩm liên quan");
            }
        }

        private async void btnSearch_Click(object sender, System.EventArgs e)
        {
            _cts.Cancel();
            _cts = new CancellationTokenSource();
            await LoadDataAsync(txtSearch.Text.Trim());
        }
    }
}
