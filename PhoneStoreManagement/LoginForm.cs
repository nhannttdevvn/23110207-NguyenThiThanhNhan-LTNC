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
            _auth = auth;
            InitializeComponent();

            // Nhấn Enter = bấm nút Login
            this.AcceptButton = btnLogin;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var user = await _auth.LoginAdminAsync(
                txtUsername.Text.Trim(),
                txtPassword.Text
            );

            if (user == null)
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                return;
            }

            LoggedUser = user;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
