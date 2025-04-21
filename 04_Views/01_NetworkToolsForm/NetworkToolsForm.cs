using AegisOS._02_Modele._01_NetworkToolsModele;
using AegisOS._03_Controleur.NetworkToolsController;
using LiveCharts.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using SpeedTestSharp;
using SpeedTestSharp.Client;
using SpeedTestSharp.Enums;
using System.Runtime.CompilerServices;


namespace AegisOS.Forms
{
    public partial class NetworkToolsForm : Form
    {
        private bool sideBarExpand;
        private VpnStatus.VpnResult vpnResult;
        private readonly NetworkToolsController _vpnController;


        private string contryIP;
        private string contryVPN;

        private string ipHome;
        private string ipRegion;

        private GeoMap _currentGeoMap;
        private Dictionary<string, double> _currentValues = new Dictionary<string, double>();



        public NetworkToolsForm()
        {
            InitializeComponent();
            _vpnController = new NetworkToolsController();
            ConfigurationIpHome();
            PingConnection.Start();
        }


        private async void PingConnection_Tick(object sender, EventArgs e)
        {
            var (connectionPing, message) = await _vpnController.GetPingStatus();

            if (connectionPing > -1)
            {
                MbpsCalculator.Value = (int)connectionPing;
                MbpsValueText.Text = connectionPing.ToString();
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }


        private async void ConfigurationIpHome()
        {
            var (connectionIp, message) = await _vpnController.GetIpStatus();

            ipHome = connectionIp;
            VPNIPHome.Text = ipHome;
            VPNImage1.ForeColor = System.Drawing.Color.FromArgb(0, 184, 148);
        }


        private void VPNButtonContry_Click(object sender, EventArgs e)
        {
            MenuContry.Start();
        }

        private void MenuContry_Tick(object sender, EventArgs e)
        {
            if (sideBarExpand)
            {
                PannelContry.Width -= 10;
                if (PannelContry.Width <= PannelContry.MinimumSize.Width)
                {
                    sideBarExpand = false;
                    MenuContry.Stop();
                }
            }
            else
            {
                PannelContry.Width += 10;
                if (PannelContry.Width >= PannelContry.MaximumSize.Width)
                {
                    sideBarExpand = true;
                    MenuContry.Stop();
                }
            }

        }

        private void VPNButtonDEFrankfurt_Click(object sender, EventArgs e)
        {
            SetMapData("BE", "DE");
        }

        private void VPNButtonFRParis_Click(object sender, EventArgs e)
        {
            SetMapData("BE", "FR");
        }

        private void VPNButtonUSLosAngeles_Click(object sender, EventArgs e)
        {
            SetMapData("BE", "US");
        }

        private void VPNButtonSGSingapur_Click(object sender, EventArgs e)
        {
            SetMapData("BE", "SG");
        }

        private void VPNButtonTHBangkok_Click(object sender, EventArgs e)
        {
            SetMapData("BE", "TH");
        }

        private void VPNButtonJPTokyo_Click(object sender, EventArgs e)
        {
            SetMapData("BE", "JP");
        }

        private void VPNButtonNGAbuja_Click(object sender, EventArgs e)
        {
            SetMapData("BE", "NG");
        }

        private void VPNButtonCATorento_Click(object sender, EventArgs e)
        {
            SetMapData("BE", "CA");
        }


        private void SetMapData(string contryIP, string contryVPN)
        {
            this.contryIP = contryIP;
            this.contryVPN = contryVPN;

            PannelContryMap.Invalidate();
        }

        private void PannelContryMap_Paint(object sender, PaintEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(contryIP) || string.IsNullOrWhiteSpace(contryVPN))
            {
                return;
            }

            GeoMap geoMap = new GeoMap();
            Random random = new Random();

            Dictionary<string, double> values = new Dictionary<string, double>();
            values[contryIP] = random.Next(0, 100);
            values[contryVPN] = random.Next(0, 100);

            geoMap.DefaultLandFill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 34, 33, 74)); // Couleur unie
            geoMap.DefaultLandFill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 34, 33, 74));

            //GradientStopCollection collection = new GradientStopCollection();
            //collection.Add(new GradientStop() { Color = System.Windows.Media.Color.FromArgb(64,64,64,0), Offset=0});
            //collection.Add(new GradientStop() { Color = System.Windows.Media.Color.FromArgb(255, 255, 255, 0), Offset = 0.5 });
            //collection.Add(new GradientStop() { Color = System.Windows.Media.Color.FromArgb(128, 128, 128, 0), Offset = 1 });
            //geoMap.GradientStopCollection = collection;

            //geoMap.LandStroke = new SolidColorBrush(Colors.Red);

            geoMap.HeatMap = values;
            geoMap.Source = @"D:\Projet\AegisOS\AegisOS Main\AegisOS\AegisOS\Resources\WorldXML\world.xml";

            PannelContryMap.Controls.Clear();
            contryIP = null;
            contryVPN = null;
            PannelContryMap.Controls.Add(geoMap);

            geoMap.Dock = DockStyle.Fill;
        }


        private async void VPNButtonDisconnect_Click(object sender, EventArgs e)
        {
            if (!vpnResult.IsSuccess)
            {
                vpnResult = _vpnController.ConnectVpn();
                await UpdateVPNUIDesign();
            }
            else
            {
                vpnResult = _vpnController.DisconnectVpn();
                await UpdateVPNUIDesign();
            }
        }

        
        private async Task UpdateVPNUIDesign()
        {
            bool connected = vpnResult.IsSuccess;

            VPNButtonDisconnect.Text = connected ? "DISCONNECT" : "CONNECT";
            VPNButtonDisconnect.FillColor = connected ? System.Drawing.Color.FromArgb(255, 76, 97) : System.Drawing.Color.FromArgb(0, 184, 148);
            VPNButtonDisconnect.FillColor2 = connected ? System.Drawing.Color.FromArgb(215, 38, 56) : System.Drawing.Color.FromArgb(0, 153, 112);

            if (connected)
            {
                await Task.Delay(5000);
                var (connectionIp, message) = await _vpnController.GetIpStatus();

                ipRegion = connectionIp;
                VPNIPRegion.Text = ipRegion;
                VPNImage2.ForeColor = System.Drawing.Color.FromArgb(0, 184, 148);

                SecurityText1.Text = "Secured";
                SecurityText1.Location = new Point(90, 229);
                SecurityText1.ForeColor = System.Drawing.Color.FromArgb(0, 255, 171);

                SecurityText2.Text = "Your Identity is protected";
                SecurityText2.Location = new Point(26, 266);
            }
            else
            {
                VPNIPRegion.Text = "Select Region";
                VPNImage2.ForeColor = System.Drawing.Color.FromArgb(164, 143, 227);

                SecurityText1.Text = "Not Secured";
                SecurityText1.Location = new Point(60, 229);
                SecurityText1.ForeColor = System.Drawing.Color.FromArgb(255, 76, 97);

                SecurityText2.Text = "Your Identity is not protected";
                SecurityText2.Location = new Point(10, 266);
            }
        }
        

        private void VPNPreferences(bool protocol)
        {
            VPNPreferencesTCPButtonSwitch.Checked = protocol;
            VPNPreferencesUDPButtonSwitch.Checked = !protocol;
        }

        private void VPNPreferencesTCPButtonSwitch_Click(object sender, EventArgs e)
        {
            _vpnController.SetProtocol(true);
            VPNPreferences(true);
        }

        private void VPNPreferencesUDPButtonSwitch_Click(object sender, EventArgs e)
        {
            _vpnController.SetProtocol(true);
            VPNPreferences(true);
        }
    }
}


/*

Gestion ERREUR A FAIRE
MAP a regarder
Amélioration du code, legereté,...
Regarder les variables
Structure Code
POO/...
UI a regarder
Region (Text a implementer)
Regarder quand VPN Connecté a UDP -> Bug PING et IP
Fermer VPN quand on ferme l'application

Finir ça pour ce week-end

*/