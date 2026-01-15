using System;
using System.Windows.Forms;
using PhoneStoreManagement.Services.Interfaces;

namespace PhoneStoreManagement.Winforms
{
    public partial class LoginForm : Form
    {
        private readonly IAuthService _auth;

        public AdminAuthResult? LoggedUser { get; private set; }

        public LoginForm(IAuthService auth)
        {
            try
            {
                _auth = auth;
                InitializeComponent();

                // Nhấn Enter = bấm nút Login
                this.AcceptButton = btnLogin;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo form: " + ex.Message);
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Vô hiệu hóa nút để tránh click nhiều lần
                btnLogin.Enabled = false;

                var user = await _auth.LoginAdminAsync(
                    txtUsername.Text.Trim(),
                    txtPassword.Text
                );

                if (user == null)
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoggedUser = user;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + (ex.InnerException?.Message ?? ex.Message), "Lỗi Hệ Thống");
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }
    }
}