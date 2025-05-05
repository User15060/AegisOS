namespace AegisOS.Forms
{
    partial class LoginUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            PannelLogin = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            TextBoxPassword = new Guna.UI2.WinForms.Guna2TextBox();
            Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            IconPassword = new FontAwesome.Sharp.IconPictureBox();
            ForgetPasswordText = new Label();
            RememberMeText = new Label();
            RadioButton = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            LoginButton = new Guna.UI2.WinForms.Guna2GradientButton();
            TextBoxUsername = new Guna.UI2.WinForms.Guna2TextBox();
            Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            IconUsername = new FontAwesome.Sharp.IconPictureBox();
            WelcomeText = new Label();
            Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            PannelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IconPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconUsername).BeginInit();
            SuspendLayout();
            // 
            // PannelLogin
            // 
            PannelLogin.BackColor = Color.Transparent;
            PannelLogin.BorderColor = Color.Transparent;
            PannelLogin.BorderRadius = 50;
            PannelLogin.Controls.Add(TextBoxPassword);
            PannelLogin.Controls.Add(Separator3);
            PannelLogin.Controls.Add(IconPassword);
            PannelLogin.Controls.Add(ForgetPasswordText);
            PannelLogin.Controls.Add(RememberMeText);
            PannelLogin.Controls.Add(RadioButton);
            PannelLogin.Controls.Add(LoginButton);
            PannelLogin.Controls.Add(TextBoxUsername);
            PannelLogin.Controls.Add(Separator2);
            PannelLogin.Controls.Add(IconUsername);
            PannelLogin.Controls.Add(WelcomeText);
            PannelLogin.Controls.Add(Separator1);
            PannelLogin.CustomizableEdges = customizableEdges8;
            PannelLogin.FillColor = Color.Transparent;
            PannelLogin.FillColor2 = Color.FromArgb(0, 176, 176);
            PannelLogin.FillColor3 = Color.FromArgb(0, 176, 176);
            PannelLogin.FillColor4 = Color.Gray;
            PannelLogin.ForeColor = Color.Gainsboro;
            PannelLogin.Location = new Point(364, 34);
            PannelLogin.Name = "PannelLogin";
            PannelLogin.ShadowDecoration.CustomizableEdges = customizableEdges9;
            PannelLogin.Size = new Size(447, 656);
            PannelLogin.TabIndex = 3;
            // 
            // TextBoxPassword
            // 
            TextBoxPassword.BorderColor = Color.Gainsboro;
            TextBoxPassword.BorderRadius = 10;
            TextBoxPassword.BorderThickness = 0;
            TextBoxPassword.CustomizableEdges = customizableEdges1;
            TextBoxPassword.DefaultText = "Enter your Password";
            TextBoxPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            TextBoxPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            TextBoxPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            TextBoxPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            TextBoxPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            TextBoxPassword.Font = new Font("Segoe UI", 9F);
            TextBoxPassword.ForeColor = Color.Gray;
            TextBoxPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            TextBoxPassword.Location = new Point(98, 286);
            TextBoxPassword.Margin = new Padding(4, 5, 4, 5);
            TextBoxPassword.Name = "TextBoxPassword";
            TextBoxPassword.PlaceholderText = "";
            TextBoxPassword.SelectedText = "";
            TextBoxPassword.ShadowDecoration.CustomizableEdges = customizableEdges2;
            TextBoxPassword.Size = new Size(315, 55);
            TextBoxPassword.TabIndex = 14;
            // 
            // Separator3
            // 
            Separator3.FillThickness = 2;
            Separator3.Location = new Point(36, 349);
            Separator3.Name = "Separator3";
            Separator3.Size = new Size(300, 15);
            Separator3.TabIndex = 13;
            // 
            // IconPassword
            // 
            IconPassword.BackColor = Color.Transparent;
            IconPassword.ForeColor = SystemColors.ActiveCaption;
            IconPassword.IconChar = FontAwesome.Sharp.IconChar.Lock;
            IconPassword.IconColor = SystemColors.ActiveCaption;
            IconPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconPassword.IconSize = 55;
            IconPassword.Location = new Point(36, 286);
            IconPassword.Name = "IconPassword";
            IconPassword.Size = new Size(55, 55);
            IconPassword.TabIndex = 12;
            IconPassword.TabStop = false;
            // 
            // ForgetPasswordText
            // 
            ForgetPasswordText.AutoSize = true;
            ForgetPasswordText.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            ForgetPasswordText.ForeColor = Color.Gainsboro;
            ForgetPasswordText.Location = new Point(253, 550);
            ForgetPasswordText.Name = "ForgetPasswordText";
            ForgetPasswordText.Size = new Size(153, 25);
            ForgetPasswordText.TabIndex = 11;
            ForgetPasswordText.Text = "Forget Password ?";
            // 
            // RememberMeText
            // 
            RememberMeText.AutoSize = true;
            RememberMeText.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            RememberMeText.ForeColor = Color.Gainsboro;
            RememberMeText.Location = new Point(70, 550);
            RememberMeText.Name = "RememberMeText";
            RememberMeText.Size = new Size(124, 25);
            RememberMeText.TabIndex = 10;
            RememberMeText.Text = "Remember Me";
            // 
            // RadioButton
            // 
            RadioButton.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            RadioButton.CheckedState.BorderThickness = 0;
            RadioButton.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            RadioButton.CheckedState.InnerColor = Color.White;
            RadioButton.Location = new Point(43, 553);
            RadioButton.Name = "RadioButton";
            RadioButton.ShadowDecoration.CustomizableEdges = customizableEdges3;
            RadioButton.Size = new Size(21, 21);
            RadioButton.TabIndex = 9;
            RadioButton.Text = "guna2CustomRadioButton2";
            RadioButton.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            RadioButton.UncheckedState.BorderThickness = 2;
            RadioButton.UncheckedState.FillColor = Color.Transparent;
            RadioButton.UncheckedState.InnerColor = Color.Transparent;
            // 
            // LoginButton
            // 
            LoginButton.BorderRadius = 12;
            LoginButton.CustomizableEdges = customizableEdges4;
            LoginButton.DisabledState.BorderColor = Color.DarkGray;
            LoginButton.DisabledState.CustomBorderColor = Color.DarkGray;
            LoginButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            LoginButton.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            LoginButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            LoginButton.FillColor = Color.FromArgb(0, 184, 148);
            LoginButton.FillColor2 = Color.FromArgb(164, 143, 227);
            LoginButton.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginButton.ForeColor = Color.Gainsboro;
            LoginButton.Location = new Point(78, 427);
            LoginButton.Name = "LoginButton";
            LoginButton.ShadowDecoration.CustomizableEdges = customizableEdges5;
            LoginButton.Size = new Size(297, 68);
            LoginButton.TabIndex = 8;
            LoginButton.Text = "LOGIN";
            // 
            // TextBoxUsername
            // 
            TextBoxUsername.BackColor = Color.Transparent;
            TextBoxUsername.BorderColor = Color.Transparent;
            TextBoxUsername.BorderRadius = 10;
            TextBoxUsername.BorderThickness = 0;
            TextBoxUsername.CustomizableEdges = customizableEdges6;
            TextBoxUsername.DefaultText = "Enter your Username";
            TextBoxUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            TextBoxUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            TextBoxUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            TextBoxUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            TextBoxUsername.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            TextBoxUsername.Font = new Font("Segoe UI", 9F);
            TextBoxUsername.ForeColor = Color.Gray;
            TextBoxUsername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            TextBoxUsername.Location = new Point(98, 150);
            TextBoxUsername.Margin = new Padding(4, 5, 4, 5);
            TextBoxUsername.Name = "TextBoxUsername";
            TextBoxUsername.PlaceholderText = "";
            TextBoxUsername.SelectedText = "";
            TextBoxUsername.ShadowDecoration.CustomizableEdges = customizableEdges7;
            TextBoxUsername.Size = new Size(315, 55);
            TextBoxUsername.TabIndex = 6;
            // 
            // Separator2
            // 
            Separator2.FillThickness = 2;
            Separator2.Location = new Point(36, 213);
            Separator2.Name = "Separator2";
            Separator2.Size = new Size(300, 15);
            Separator2.TabIndex = 4;
            // 
            // IconUsername
            // 
            IconUsername.BackColor = Color.Transparent;
            IconUsername.ForeColor = SystemColors.ActiveCaption;
            IconUsername.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            IconUsername.IconColor = SystemColors.ActiveCaption;
            IconUsername.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconUsername.IconSize = 55;
            IconUsername.Location = new Point(36, 150);
            IconUsername.Name = "IconUsername";
            IconUsername.Size = new Size(55, 55);
            IconUsername.SizeMode = PictureBoxSizeMode.CenterImage;
            IconUsername.TabIndex = 2;
            IconUsername.TabStop = false;
            // 
            // WelcomeText
            // 
            WelcomeText.AutoSize = true;
            WelcomeText.Font = new Font("Century Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WelcomeText.ForeColor = Color.Gainsboro;
            WelcomeText.Location = new Point(106, 37);
            WelcomeText.Name = "WelcomeText";
            WelcomeText.Size = new Size(240, 39);
            WelcomeText.TabIndex = 1;
            WelcomeText.Text = "Welcome User";
            // 
            // Separator1
            // 
            Separator1.Location = new Point(78, 75);
            Separator1.Name = "Separator1";
            Separator1.Size = new Size(297, 15);
            Separator1.TabIndex = 0;
            // 
            // LoginUser
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(1170, 727);
            Controls.Add(PannelLogin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginUser";
            Opacity = 0.5D;
            Text = "LoginUser";
            PannelLogin.ResumeLayout(false);
            PannelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IconPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconUsername).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2CustomGradientPanel PannelLogin;
        private Guna.UI2.WinForms.Guna2TextBox TextBoxPassword;
        private Guna.UI2.WinForms.Guna2Separator Separator3;
        private FontAwesome.Sharp.IconPictureBox IconPassword;
        private Label ForgetPasswordText;
        private Label RememberMeText;
        private Guna.UI2.WinForms.Guna2CustomRadioButton RadioButton;
        private Guna.UI2.WinForms.Guna2GradientButton LoginButton;
        private Guna.UI2.WinForms.Guna2TextBox TextBoxUsername;
        private Guna.UI2.WinForms.Guna2Separator Separator2;
        private FontAwesome.Sharp.IconPictureBox IconUsername;
        private Label WelcomeText;
        private Guna.UI2.WinForms.Guna2Separator Separator1;
    }
}