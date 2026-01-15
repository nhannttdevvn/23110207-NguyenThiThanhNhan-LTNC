using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;
using System.Text.RegularExpressions;

namespace PhoneStoreManagement.Winforms;

public partial class EmployeeForm : Form
{
    private readonly IEmployeeService _svc;
    private AppUser? _selected;

    public EmployeeForm(IEmployeeService svc)
    {
        _svc = svc;
        InitializeComponent();
        LoadData();
    }

    // ================= LOAD =================
    private async void LoadData()
    {
        ConfigGrid();
        dgvEmployees.DataSource = await _svc.SearchAsync("");
        ClearInput();
    }

    private void ConfigGrid()
    {
        dgvEmployees.AutoGenerateColumns = false;
        dgvEmployees.Columns.Clear();

        dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "EmployeeCode",
            HeaderText = "Mã NV"
        });
        dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "FullName",
            HeaderText = "Họ tên",
            Width = 160
        });
        dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Phone",
            HeaderText = "SĐT"
        });
        dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Email",
            HeaderText = "Email",
            Width = 180
        });
        dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "HomeTown",
            HeaderText = "Quê quán"
        });
    }

    private void ClearInput()
    {
        txtEmployeeCode.Clear();
        txtFullName.Clear();
        txtPhone.Clear();
        txtEmail.Clear();
        txtHomeTown.Clear();
        txtUsername.Clear();
        _selected = null;
    }

    // ================= VALIDATE =================
    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtFullName.Text))
        {
            MessageBox.Show("Họ tên không được để trống");
            return false;
        }

        if (!Regex.IsMatch(txtPhone.Text.Trim(), @"^0\d{9}$"))
        {
            MessageBox.Show("Số điện thoại không hợp lệ");
            return false;
        }

        if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            MessageBox.Show("Email không hợp lệ");
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtUsername.Text))
        {
            MessageBox.Show("Tài khoản không được để trống");
            return false;
        }

        // check trùng lặp email nhân viên
        if (_svc.IsEmailExists(txtEmail.Text, _selected?.EmployeeCode))
        {
            MessageBox.Show("Email đã tồn tại");
            return false;
        }

        if (_svc.IsPhoneExists(txtPhone.Text, _selected?.EmployeeCode))
        {
            MessageBox.Show("Số điện thoại đã tồn tại");
            return false;
        }
     

        return true;
    }

    // ================= ADD =================
    private async void btnAdd_Click(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        try
        {
            var u = new AppUser
            {
                EmployeeCode = Guid.NewGuid().ToString("N")[..8].ToUpper(),
                FullName = txtFullName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                HomeTown = txtHomeTown.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                AppRoleId = 2
            };

            await _svc.CreateAsync(u, "123456");
            LoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Lỗi");
        }
    }

    // ================= UPDATE =================
    private async void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_selected == null) return;
        if (!ValidateInput()) return;

        try
        {
            _selected.FullName = txtFullName.Text.Trim();
            _selected.Phone = txtPhone.Text.Trim();
            _selected.Email = txtEmail.Text.Trim();
            _selected.HomeTown = txtHomeTown.Text.Trim();
            _selected.Username = txtUsername.Text.Trim();

            await _svc.UpdateAsync(_selected);
            LoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Lỗi");
        }
    }

    // ================= DELETE =================
    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (_selected == null) return;

        if (MessageBox.Show("Xóa nhân viên?", "Xác nhận",
            MessageBoxButtons.YesNo) != DialogResult.Yes)
            return;

        try
        {
            await _svc.DeleteAsync(_selected.AppUserId);
            LoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Lỗi");
        }
    }

    // ================= SEARCH =================
    private async void btnSearch_Click(object sender, EventArgs e)
    {
        dgvEmployees.DataSource = await _svc.SearchAsync(txtSearch.Text.Trim());
    }

    private async void txtSearch_TextChanged(object sender, EventArgs e)
    {
        dgvEmployees.DataSource = await _svc.SearchAsync(txtSearch.Text.Trim());
    }

    // ================= GRID CLICK =================
    private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        _selected = dgvEmployees.Rows[e.RowIndex].DataBoundItem as AppUser;
        if (_selected == null) return;

        txtEmployeeCode.Text = _selected.EmployeeCode;
        txtFullName.Text = _selected.FullName;
        txtPhone.Text = _selected.Phone;
        txtEmail.Text = _selected.Email;
        txtHomeTown.Text = _selected.HomeTown;
        txtUsername.Text = _selected.Username;
    }
}
