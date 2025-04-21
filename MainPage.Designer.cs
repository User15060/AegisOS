namespace AegisOS
{
    partial class MainPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            MainMenuP1 = new FlowLayoutPanel();
            MainMenuPannelE1 = new Panel();
            MainMenuImageSideBar = new FontAwesome.Sharp.IconPictureBox();
            PannelButton1 = new Panel();
            MainMenuButton1 = new FontAwesome.Sharp.IconButton();
            PannelButton2 = new Panel();
            MainMenuButton2 = new FontAwesome.Sharp.IconButton();
            PannelButton3 = new Panel();
            MainMenuButton3 = new FontAwesome.Sharp.IconButton();
            PannelButton4 = new Panel();
            MainMenuButton4 = new FontAwesome.Sharp.IconButton();
            PannelButton5 = new Panel();
            MainMenuButton5 = new FontAwesome.Sharp.IconButton();
            PannelButton6 = new Panel();
            MainMenuButton6 = new FontAwesome.Sharp.IconButton();
            MenuSideBarTimer = new System.Windows.Forms.Timer(components);
            MainMenuP2 = new Panel();
            MainMenu2Close = new FontAwesome.Sharp.IconPictureBox();
            MainMenu2Windows = new FontAwesome.Sharp.IconPictureBox();
            MainMenu2Minus = new FontAwesome.Sharp.IconPictureBox();
            MainMenu2ImageBar = new FontAwesome.Sharp.IconPictureBox();
            MainMenu2BarText = new Label();
            ShadowPannel = new Panel();
            DesktopPannel = new Panel();
            MainMenuP1.SuspendLayout();
            MainMenuPannelE1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainMenuImageSideBar).BeginInit();
            PannelButton1.SuspendLayout();
            PannelButton2.SuspendLayout();
            PannelButton3.SuspendLayout();
            PannelButton4.SuspendLayout();
            PannelButton5.SuspendLayout();
            PannelButton6.SuspendLayout();
            MainMenuP2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainMenu2Close).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainMenu2Windows).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainMenu2Minus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainMenu2ImageBar).BeginInit();
            SuspendLayout();
            // 
            // MainMenuP1
            // 
            MainMenuP1.BackColor = Color.FromArgb(31, 30, 68);
            MainMenuP1.Controls.Add(MainMenuPannelE1);
            MainMenuP1.Controls.Add(PannelButton1);
            MainMenuP1.Controls.Add(PannelButton2);
            MainMenuP1.Controls.Add(PannelButton3);
            MainMenuP1.Controls.Add(PannelButton4);
            MainMenuP1.Controls.Add(PannelButton5);
            MainMenuP1.Controls.Add(PannelButton6);
            MainMenuP1.Dock = DockStyle.Left;
            MainMenuP1.Location = new Point(0, 0);
            MainMenuP1.MaximumSize = new Size(330, 800);
            MainMenuP1.MinimumSize = new Size(78, 800);
            MainMenuP1.Name = "MainMenuP1";
            MainMenuP1.Size = new Size(330, 800);
            MainMenuP1.TabIndex = 0;
            // 
            // MainMenuPannelE1
            // 
            MainMenuPannelE1.Controls.Add(MainMenuImageSideBar);
            MainMenuPannelE1.Dock = DockStyle.Top;
            MainMenuPannelE1.Location = new Point(3, 3);
            MainMenuPannelE1.Name = "MainMenuPannelE1";
            MainMenuPannelE1.Size = new Size(330, 180);
            MainMenuPannelE1.TabIndex = 0;
            // 
            // MainMenuImageSideBar
            // 
            MainMenuImageSideBar.BackColor = Color.FromArgb(31, 30, 68);
            MainMenuImageSideBar.ForeColor = Color.Gainsboro;
            MainMenuImageSideBar.IconChar = FontAwesome.Sharp.IconChar.Bars;
            MainMenuImageSideBar.IconColor = Color.Gainsboro;
            MainMenuImageSideBar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            MainMenuImageSideBar.IconSize = 59;
            MainMenuImageSideBar.Location = new Point(0, 61);
            MainMenuImageSideBar.Name = "MainMenuImageSideBar";
            MainMenuImageSideBar.Padding = new Padding(13, 0, 0, 0);
            MainMenuImageSideBar.Size = new Size(80, 59);
            MainMenuImageSideBar.TabIndex = 1;
            MainMenuImageSideBar.TabStop = false;
            MainMenuImageSideBar.Click += MainMenuImageSideBar_Click;
            // 
            // PannelButton1
            // 
            PannelButton1.Controls.Add(MainMenuButton1);
            PannelButton1.Dock = DockStyle.Top;
            PannelButton1.Location = new Point(3, 189);
            PannelButton1.Name = "PannelButton1";
            PannelButton1.Size = new Size(330, 70);
            PannelButton1.TabIndex = 1;
            // 
            // MainMenuButton1
            // 
            MainMenuButton1.FlatAppearance.BorderSize = 0;
            MainMenuButton1.FlatStyle = FlatStyle.Flat;
            MainMenuButton1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuButton1.ForeColor = Color.Gainsboro;
            MainMenuButton1.IconChar = FontAwesome.Sharp.IconChar.ShieldHalved;
            MainMenuButton1.IconColor = Color.Gainsboro;
            MainMenuButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            MainMenuButton1.IconSize = 46;
            MainMenuButton1.ImageAlign = ContentAlignment.MiddleLeft;
            MainMenuButton1.Location = new Point(0, 0);
            MainMenuButton1.Name = "MainMenuButton1";
            MainMenuButton1.Padding = new Padding(13, 0, 20, 0);
            MainMenuButton1.Size = new Size(330, 70);
            MainMenuButton1.TabIndex = 1;
            MainMenuButton1.Text = " Network Tools";
            MainMenuButton1.TextAlign = ContentAlignment.MiddleLeft;
            MainMenuButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            MainMenuButton1.UseVisualStyleBackColor = true;
            MainMenuButton1.Click += MainMenuButton1_Click;
            // 
            // PannelButton2
            // 
            PannelButton2.Controls.Add(MainMenuButton2);
            PannelButton2.Dock = DockStyle.Top;
            PannelButton2.Location = new Point(3, 265);
            PannelButton2.Name = "PannelButton2";
            PannelButton2.Size = new Size(330, 70);
            PannelButton2.TabIndex = 2;
            // 
            // MainMenuButton2
            // 
            MainMenuButton2.FlatAppearance.BorderSize = 0;
            MainMenuButton2.FlatStyle = FlatStyle.Flat;
            MainMenuButton2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuButton2.ForeColor = Color.Gainsboro;
            MainMenuButton2.IconChar = FontAwesome.Sharp.IconChar.UserLock;
            MainMenuButton2.IconColor = Color.Gainsboro;
            MainMenuButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            MainMenuButton2.IconSize = 46;
            MainMenuButton2.ImageAlign = ContentAlignment.MiddleLeft;
            MainMenuButton2.Location = new Point(0, 0);
            MainMenuButton2.Name = "MainMenuButton2";
            MainMenuButton2.Padding = new Padding(13, 0, 20, 0);
            MainMenuButton2.Size = new Size(330, 70);
            MainMenuButton2.TabIndex = 2;
            MainMenuButton2.Text = " Encyrpt Tools";
            MainMenuButton2.TextAlign = ContentAlignment.MiddleLeft;
            MainMenuButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            MainMenuButton2.UseVisualStyleBackColor = true;
            MainMenuButton2.Click += MainMenuButton2_Click;
            // 
            // PannelButton3
            // 
            PannelButton3.Controls.Add(MainMenuButton3);
            PannelButton3.Dock = DockStyle.Top;
            PannelButton3.Location = new Point(3, 341);
            PannelButton3.Name = "PannelButton3";
            PannelButton3.Size = new Size(330, 70);
            PannelButton3.TabIndex = 3;
            // 
            // MainMenuButton3
            // 
            MainMenuButton3.FlatAppearance.BorderSize = 0;
            MainMenuButton3.FlatStyle = FlatStyle.Flat;
            MainMenuButton3.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuButton3.ForeColor = Color.Gainsboro;
            MainMenuButton3.IconChar = FontAwesome.Sharp.IconChar.FileCircleCheck;
            MainMenuButton3.IconColor = Color.Gainsboro;
            MainMenuButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            MainMenuButton3.IconSize = 46;
            MainMenuButton3.ImageAlign = ContentAlignment.MiddleLeft;
            MainMenuButton3.Location = new Point(0, 0);
            MainMenuButton3.Name = "MainMenuButton3";
            MainMenuButton3.Padding = new Padding(13, 0, 20, 0);
            MainMenuButton3.Size = new Size(330, 70);
            MainMenuButton3.TabIndex = 3;
            MainMenuButton3.Text = "Analyzer Tools";
            MainMenuButton3.TextAlign = ContentAlignment.MiddleLeft;
            MainMenuButton3.TextImageRelation = TextImageRelation.ImageBeforeText;
            MainMenuButton3.UseVisualStyleBackColor = true;
            MainMenuButton3.Click += MainMenuButton3_Click;
            // 
            // PannelButton4
            // 
            PannelButton4.Controls.Add(MainMenuButton4);
            PannelButton4.Dock = DockStyle.Top;
            PannelButton4.Location = new Point(3, 417);
            PannelButton4.Name = "PannelButton4";
            PannelButton4.Size = new Size(330, 70);
            PannelButton4.TabIndex = 4;
            // 
            // MainMenuButton4
            // 
            MainMenuButton4.FlatAppearance.BorderSize = 0;
            MainMenuButton4.FlatStyle = FlatStyle.Flat;
            MainMenuButton4.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuButton4.ForeColor = Color.Gainsboro;
            MainMenuButton4.IconChar = FontAwesome.Sharp.IconChar.Microchip;
            MainMenuButton4.IconColor = Color.Gainsboro;
            MainMenuButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            MainMenuButton4.IconSize = 46;
            MainMenuButton4.ImageAlign = ContentAlignment.MiddleLeft;
            MainMenuButton4.Location = new Point(0, 0);
            MainMenuButton4.Name = "MainMenuButton4";
            MainMenuButton4.Padding = new Padding(13, 0, 20, 0);
            MainMenuButton4.Size = new Size(330, 70);
            MainMenuButton4.TabIndex = 4;
            MainMenuButton4.Text = " System Check";
            MainMenuButton4.TextAlign = ContentAlignment.MiddleLeft;
            MainMenuButton4.TextImageRelation = TextImageRelation.ImageBeforeText;
            MainMenuButton4.UseVisualStyleBackColor = true;
            MainMenuButton4.Click += MainMenuButton4_Click;
            // 
            // PannelButton5
            // 
            PannelButton5.Controls.Add(MainMenuButton5);
            PannelButton5.Dock = DockStyle.Top;
            PannelButton5.Location = new Point(3, 493);
            PannelButton5.Name = "PannelButton5";
            PannelButton5.Size = new Size(330, 70);
            PannelButton5.TabIndex = 5;
            // 
            // MainMenuButton5
            // 
            MainMenuButton5.FlatAppearance.BorderSize = 0;
            MainMenuButton5.FlatStyle = FlatStyle.Flat;
            MainMenuButton5.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuButton5.ForeColor = Color.Gainsboro;
            MainMenuButton5.IconChar = FontAwesome.Sharp.IconChar.EnvelopeCircleCheck;
            MainMenuButton5.IconColor = Color.Gainsboro;
            MainMenuButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            MainMenuButton5.IconSize = 46;
            MainMenuButton5.ImageAlign = ContentAlignment.MiddleLeft;
            MainMenuButton5.Location = new Point(0, 0);
            MainMenuButton5.Name = "MainMenuButton5";
            MainMenuButton5.Padding = new Padding(13, 0, 20, 0);
            MainMenuButton5.Size = new Size(330, 70);
            MainMenuButton5.TabIndex = 5;
            MainMenuButton5.Text = " Email Verifier";
            MainMenuButton5.TextAlign = ContentAlignment.MiddleLeft;
            MainMenuButton5.TextImageRelation = TextImageRelation.ImageBeforeText;
            MainMenuButton5.UseVisualStyleBackColor = true;
            MainMenuButton5.Click += MainMenuButton5_Click;
            // 
            // PannelButton6
            // 
            PannelButton6.Controls.Add(MainMenuButton6);
            PannelButton6.Dock = DockStyle.Top;
            PannelButton6.Location = new Point(3, 569);
            PannelButton6.Name = "PannelButton6";
            PannelButton6.Size = new Size(330, 70);
            PannelButton6.TabIndex = 6;
            // 
            // MainMenuButton6
            // 
            MainMenuButton6.FlatAppearance.BorderSize = 0;
            MainMenuButton6.FlatStyle = FlatStyle.Flat;
            MainMenuButton6.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuButton6.ForeColor = Color.Gainsboro;
            MainMenuButton6.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            MainMenuButton6.IconColor = Color.Gainsboro;
            MainMenuButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            MainMenuButton6.IconSize = 46;
            MainMenuButton6.ImageAlign = ContentAlignment.MiddleLeft;
            MainMenuButton6.Location = new Point(0, 0);
            MainMenuButton6.Name = "MainMenuButton6";
            MainMenuButton6.Padding = new Padding(13, 0, 20, 0);
            MainMenuButton6.Size = new Size(330, 70);
            MainMenuButton6.TabIndex = 6;
            MainMenuButton6.Text = " Reports";
            MainMenuButton6.TextAlign = ContentAlignment.MiddleLeft;
            MainMenuButton6.TextImageRelation = TextImageRelation.ImageBeforeText;
            MainMenuButton6.UseVisualStyleBackColor = true;
            MainMenuButton6.Click += MainMenuButton6_Click;
            // 
            // MenuSideBarTimer
            // 
            MenuSideBarTimer.Interval = 10;
            MenuSideBarTimer.Tick += MenuSideBarTimer_Tick;
            // 
            // MainMenuP2
            // 
            MainMenuP2.BackColor = Color.FromArgb(26, 25, 62);
            MainMenuP2.Controls.Add(MainMenu2Close);
            MainMenuP2.Controls.Add(MainMenu2Windows);
            MainMenuP2.Controls.Add(MainMenu2Minus);
            MainMenuP2.Controls.Add(MainMenu2ImageBar);
            MainMenuP2.Controls.Add(MainMenu2BarText);
            MainMenuP2.Dock = DockStyle.Top;
            MainMenuP2.Location = new Point(330, 0);
            MainMenuP2.Name = "MainMenuP2";
            MainMenuP2.Size = new Size(1170, 64);
            MainMenuP2.TabIndex = 1;
            MainMenuP2.MouseDown += MainMenuP2_MouseDown;
            // 
            // MainMenu2Close
            // 
            MainMenu2Close.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MainMenu2Close.BackColor = Color.FromArgb(26, 25, 62);
            MainMenu2Close.ForeColor = Color.Gainsboro;
            MainMenu2Close.IconChar = FontAwesome.Sharp.IconChar.Close;
            MainMenu2Close.IconColor = Color.Gainsboro;
            MainMenu2Close.IconFont = FontAwesome.Sharp.IconFont.Auto;
            MainMenu2Close.IconSize = 25;
            MainMenu2Close.Location = new Point(1139, 7);
            MainMenu2Close.Name = "MainMenu2Close";
            MainMenu2Close.Size = new Size(25, 25);
            MainMenu2Close.SizeMode = PictureBoxSizeMode.CenterImage;
            MainMenu2Close.TabIndex = 4;
            MainMenu2Close.TabStop = false;
            MainMenu2Close.Click += MainMenu2Close_Click;
            // 
            // MainMenu2Windows
            // 
            MainMenu2Windows.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MainMenu2Windows.BackColor = Color.FromArgb(26, 25, 62);
            MainMenu2Windows.ForeColor = Color.Gainsboro;
            MainMenu2Windows.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            MainMenu2Windows.IconColor = Color.Gainsboro;
            MainMenu2Windows.IconFont = FontAwesome.Sharp.IconFont.Auto;
            MainMenu2Windows.IconSize = 25;
            MainMenu2Windows.Location = new Point(1108, 7);
            MainMenu2Windows.Name = "MainMenu2Windows";
            MainMenu2Windows.Size = new Size(25, 25);
            MainMenu2Windows.SizeMode = PictureBoxSizeMode.CenterImage;
            MainMenu2Windows.TabIndex = 3;
            MainMenu2Windows.TabStop = false;
            MainMenu2Windows.Click += MainMenu2Windows_Click;
            // 
            // MainMenu2Minus
            // 
            MainMenu2Minus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MainMenu2Minus.BackColor = Color.FromArgb(26, 25, 62);
            MainMenu2Minus.ForeColor = Color.Gainsboro;
            MainMenu2Minus.IconChar = FontAwesome.Sharp.IconChar.Subtract;
            MainMenu2Minus.IconColor = Color.Gainsboro;
            MainMenu2Minus.IconFont = FontAwesome.Sharp.IconFont.Auto;
            MainMenu2Minus.IconSize = 25;
            MainMenu2Minus.Location = new Point(1077, 7);
            MainMenu2Minus.Name = "MainMenu2Minus";
            MainMenu2Minus.Size = new Size(25, 25);
            MainMenu2Minus.SizeMode = PictureBoxSizeMode.CenterImage;
            MainMenu2Minus.TabIndex = 2;
            MainMenu2Minus.TabStop = false;
            MainMenu2Minus.Click += MainMenu2Minus_Click;
            // 
            // MainMenu2ImageBar
            // 
            MainMenu2ImageBar.BackColor = Color.FromArgb(26, 25, 62);
            MainMenu2ImageBar.ForeColor = Color.MediumPurple;
            MainMenu2ImageBar.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            MainMenu2ImageBar.IconColor = Color.MediumPurple;
            MainMenu2ImageBar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            MainMenu2ImageBar.IconSize = 48;
            MainMenu2ImageBar.Location = new Point(15, 12);
            MainMenu2ImageBar.Name = "MainMenu2ImageBar";
            MainMenu2ImageBar.Size = new Size(48, 48);
            MainMenu2ImageBar.SizeMode = PictureBoxSizeMode.CenterImage;
            MainMenu2ImageBar.TabIndex = 1;
            MainMenu2ImageBar.TabStop = false;
            // 
            // MainMenu2BarText
            // 
            MainMenu2BarText.AutoSize = true;
            MainMenu2BarText.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenu2BarText.ForeColor = Color.Gainsboro;
            MainMenu2BarText.Location = new Point(67, 27);
            MainMenu2BarText.Name = "MainMenu2BarText";
            MainMenu2BarText.Size = new Size(63, 21);
            MainMenu2BarText.TabIndex = 0;
            MainMenu2BarText.Text = "Home";
            // 
            // ShadowPannel
            // 
            ShadowPannel.BackColor = Color.FromArgb(26, 24, 58);
            ShadowPannel.Dock = DockStyle.Top;
            ShadowPannel.Location = new Point(330, 64);
            ShadowPannel.Name = "ShadowPannel";
            ShadowPannel.Size = new Size(1170, 9);
            ShadowPannel.TabIndex = 2;
            // 
            // DesktopPannel
            // 
            DesktopPannel.BackColor = Color.FromArgb(34, 33, 74);
            DesktopPannel.Dock = DockStyle.Fill;
            DesktopPannel.Location = new Point(330, 73);
            DesktopPannel.Name = "DesktopPannel";
            DesktopPannel.Size = new Size(1170, 727);
            DesktopPannel.TabIndex = 3;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 800);
            Controls.Add(DesktopPannel);
            Controls.Add(ShadowPannel);
            Controls.Add(MainMenuP2);
            Controls.Add(MainMenuP1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainPage";
            Text = "Form1";
            MainMenuP1.ResumeLayout(false);
            MainMenuPannelE1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainMenuImageSideBar).EndInit();
            PannelButton1.ResumeLayout(false);
            PannelButton2.ResumeLayout(false);
            PannelButton3.ResumeLayout(false);
            PannelButton4.ResumeLayout(false);
            PannelButton5.ResumeLayout(false);
            PannelButton6.ResumeLayout(false);
            MainMenuP2.ResumeLayout(false);
            MainMenuP2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MainMenu2Close).EndInit();
            ((System.ComponentModel.ISupportInitialize)MainMenu2Windows).EndInit();
            ((System.ComponentModel.ISupportInitialize)MainMenu2Minus).EndInit();
            ((System.ComponentModel.ISupportInitialize)MainMenu2ImageBar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel MainMenuP1;
        private Panel MainMenuPannelE1;
        private Panel PannelButton1;
        private Panel PannelButton2;
        private Panel PannelButton3;
        private Panel PannelButton4;
        private Panel PannelButton5;
        private Panel PannelButton6;
        private FontAwesome.Sharp.IconButton MainMenuButton1;
        private FontAwesome.Sharp.IconButton MainMenuButton2;
        private FontAwesome.Sharp.IconButton MainMenuButton3;
        private FontAwesome.Sharp.IconButton MainMenuButton4;
        private FontAwesome.Sharp.IconButton MainMenuButton5;
        private FontAwesome.Sharp.IconButton MainMenuButton6;
        private System.Windows.Forms.Timer MenuSideBarTimer;
        private FontAwesome.Sharp.IconPictureBox MainMenuImageSideBar;
        private Panel MainMenuP2;
        private FontAwesome.Sharp.IconPictureBox MainMenu2ImageBar;
        private Label MainMenu2BarText;
        private Panel ShadowPannel;
        private Panel DesktopPannel;
        private FontAwesome.Sharp.IconPictureBox MainMenu2Close;
        private FontAwesome.Sharp.IconPictureBox MainMenu2Windows;
        private FontAwesome.Sharp.IconPictureBox MainMenu2Minus;
    }
}
