namespace PhoneStoreManagement.Winforms;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;

    private TextBox txtUsername;
    private TextBox txtPassword;
    private Button btnLogin;
    private Label lblUsername;
    private Label lblPassword;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        txtUsername = new TextBox();
        txtPassword = new TextBox();
        btnLogin = new Button();
        lblUsername = new Label();
        lblPassword = new Label();

        SuspendLayout();

        // lblUsername
        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(30, 28);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(75, 20);
        lblUsername.Text = "Username";

        // txtUsername
        txtUsername.Location = new Point(120, 25);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(150, 27);
        txtUsername.TabIndex = 0;

        // lblPassword
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(30, 68);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(70, 20);
        lblPassword.Text = "Password";

        // txtPassword
        txtPassword.Location = new Point(120, 65);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(150, 27);
        txtPassword.PasswordChar = '*';
        txtPassword.TabIndex = 1;

        // btnLogin
        btnLogin.Location = new Point(120, 105);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(150, 30);
        btnLogin.TabIndex = 2;
        btnLogin.Text = "Login";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;

        // LoginForm
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(320, 160);
        Controls.Add(lblUsername);
        Controls.Add(txtUsername);
        Controls.Add(lblPassword);
        Controls.Add(txtPassword);
        Controls.Add(btnLogin);
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Login";

        ResumeLayout(false);
        PerformLayout();
    }
}
