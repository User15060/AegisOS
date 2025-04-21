using AegisOS.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;

namespace AegisOS
{
    public partial class MainPage : Form
    {
        private IconButton currentButton;
        private Panel leftBorderButton;
        private Form currentChildForm;
        bool sideBarExpand;

        public MainPage()
        {
            InitializeComponent();

            leftBorderButton = new Panel();
            leftBorderButton.Size = new Size(7, 70);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        private void ActivateButton(object senderBtn, Color color, Panel PannelButton)
        {
            if (senderBtn != null)
            {
                DisableButton();

                currentButton = (IconButton)senderBtn;
                currentButton.BackColor = Color.FromArgb(37, 36, 81);
                currentButton.ForeColor = color;
                currentButton.IconColor = color;

                PannelButton.Controls.Add(leftBorderButton);

                leftBorderButton.BackColor = color;
                leftBorderButton.Location = new Point(0, currentButton.Location.Y);
                leftBorderButton.Visible = true;
                leftBorderButton.BringToFront();

                MainMenu2ImageBar.IconChar = currentButton.IconChar;
                MainMenu2ImageBar.ForeColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(31, 30, 68);
                currentButton.ForeColor = Color.Gainsboro;
                currentButton.IconColor = Color.Gainsboro;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            DesktopPannel.Controls.Add(childForm);
            DesktopPannel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            MainMenu2BarText.Text = childForm.Text;
        }


        private void MainMenuButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1, PannelButton1);
            OpenChildForm(new NetworkToolsForm());
        }

        private void MainMenuButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2, PannelButton2);
            OpenChildForm(new EncryptTools());
        }

        private void MainMenuButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3, PannelButton3);
            OpenChildForm(new FileAnalyzer());
        }

        private void MainMenuButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4, PannelButton4);
            OpenChildForm(new SystemCheck());
        }

        private void MainMenuButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5, PannelButton5);
            OpenChildForm(new EmailVerifier());
        }

        private void MainMenuButton6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6, PannelButton6);
            OpenChildForm(new Reports());
        }

        private void MenuSideBarTimer_Tick(object sender, EventArgs e)
        {
            if (sideBarExpand)
            {
                MainMenuP1.Width -= 10;
                if (MainMenuP1.Width <= MainMenuP1.MinimumSize.Width)
                {
                    sideBarExpand = false;
                    MenuSideBarTimer.Stop();
                }
            }
            else
            {
                MainMenuP1.Width += 10;
                if (MainMenuP1.Width >= MainMenuP1.MaximumSize.Width)
                {
                    sideBarExpand = true;
                    MenuSideBarTimer.Stop();
                }
            }

        }

        private void MainMenuImageSideBar_Click(object sender, EventArgs e)
        {
            MenuSideBarTimer.Start();
        }



        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void MainMenuP2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void MainMenu2Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainMenu2Windows_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            { 
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void MainMenu2Minus_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}

