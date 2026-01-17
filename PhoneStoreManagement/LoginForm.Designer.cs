namespace PhoneStoreManagement.Winforms;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;

    private Panel pnlBlueHeader;
    private Label lblWelcome;
    private Label lblUsername;
    private Label lblPassword;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private Button btnLogin;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlBlueHeader = new Panel();
        lblWelcome = new Label();
        lblUsername = new Label();
        lblPassword = new Label();
        txtUsername = new TextBox();
        txtPassword = new TextBox();
        btnLogin = new Button();

        SuspendLayout();

        // pnlBlueHeader
        pnlBlueHeader.BackColor = Color.FromArgb(52, 152, 219);
        pnlBlueHeader.Controls.Add(lblWelcome);
        pnlBlueHeader.Dock = DockStyle.Top;
        pnlBlueHeader.Height = 80;

        lblWelcome.Dock = DockStyle.Fill;
        lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblWelcome.ForeColor = Color.White;
        lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
        lblWelcome.Text = "Đăng nhập";

        // lblUsername
        lblUsername.Location = new Point(40, 110);
        lblUsername.Size = new Size(100, 20);
        lblUsername.Text = "Tài khoản:";
        lblUsername.Font = new Font("Segoe UI", 10F);

        // txtUsername
        txtUsername.Location = new Point(40, 135);
        txtUsername.Size = new Size(320, 30);
        txtUsername.Font = new Font("Segoe UI", 12F);

        // lblPassword
        lblPassword.Location = new Point(40, 185);
        lblPassword.Size = new Size(100, 20);
        lblPassword.Text = "Mật khẩu:";
        lblPassword.Font = new Font("Segoe UI", 10F);

        // txtPassword
        txtPassword.Location = new Point(40, 210);
        txtPassword.Size = new Size(320, 30);
        txtPassword.Font = new Font("Segoe UI", 12F);
        txtPassword.PasswordChar = '●';

        // btnLogin
        btnLogin.BackColor = Color.FromArgb(46, 204, 113);
        btnLogin.FlatStyle = FlatStyle.Flat;
        btnLogin.FlatAppearance.BorderSize = 0;
        btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        btnLogin.ForeColor = Color.White;
        btnLogin.Location = new Point(40, 270);
        btnLogin.Size = new Size(320, 45);
        btnLogin.Text = "Login";
        btnLogin.Cursor = Cursors.Hand;
        btnLogin.Click += btnLogin_Click;
        //in đậm
        btnLogin.Font = new Font(btnLogin.Font, FontStyle.Bold);

        // LoginForm
        BackColor = Color.White;
        ClientSize = new Size(400, 360);
        Controls.Add(pnlBlueHeader);
        Controls.Add(lblUsername);
        Controls.Add(txtUsername);
        Controls.Add(lblPassword);
        Controls.Add(txtPassword);
        Controls.Add(btnLogin);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Hệ Thống Đăng Nhập";

        ResumeLayout(false);
        PerformLayout();
    }
}