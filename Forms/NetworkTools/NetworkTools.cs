using AegisOS.Modele;
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
    public partial class NetworkTools : Form
    {
        private bool sideBarExpand;
        private VPN_Modele.VpnResult vpnResult;

        private string contryIP;
        private string contryVPN;

        private string ipHome;
        private string ipRegion;
        private (string myIp, string message) ipConnection;
        private (long connection, string message) pingConnection;

        private GeoMap _currentGeoMap;
        private Dictionary<string, double> _currentValues = new Dictionary<string, double>();

        private VPN_Modele vpnService = new VPN_Modele();


        public NetworkTools()
        {
            InitializeComponent();

            ConfigurationIpHome();

            PingConnection.Start();
        }


        private async void PingConnection_Tick(object sender, EventArgs e)
        {
            pingConnection = await vpnService.ShowPing();

            if (pingConnection.connection > -1)
            {
                MbpsCalculator.Value = (int)pingConnection.connection;
                MbpsValueText.Text = pingConnection.connection.ToString();
            }
            else
            {
                MessageBox.Show(pingConnection.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }


        private async void ConfigurationIpHome()
        {
            ipConnection = await vpnService.ShowIp();

            ipHome = ipConnection.myIp;
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
            if (!vpnResult.IsConnected)
            {
                vpnResult = vpnService.OpenVpn();

                if (vpnResult.IsConnected)
                {
                    vpnResult.IsConnected = true;
                    await UpdateVPNUIDesign();
                    MessageBox.Show(vpnResult.Message);
                }
                else
                {
                    MessageBox.Show(vpnResult.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                vpnResult = vpnService.CloseVpn();

                if (vpnResult.IsConnected)
                {
                    vpnResult.IsConnected = false;
                    await UpdateVPNUIDesign();
                    MessageBox.Show(vpnResult.Message);
                }
                else
                {
                    MessageBox.Show(vpnResult.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private async Task UpdateVPNUIDesign()
        {
            bool connected = vpnResult.IsConnected;

            VPNButtonDisconnect.Text = connected ? "DISCONNECT" : "CONNECT";
            VPNButtonDisconnect.FillColor = connected ? System.Drawing.Color.FromArgb(255, 76, 97) : System.Drawing.Color.FromArgb(0, 184, 148);
            VPNButtonDisconnect.FillColor2 = connected ? System.Drawing.Color.FromArgb(215, 38, 56) : System.Drawing.Color.FromArgb(0, 153, 112);

            if (connected)
            {
                await Task.Delay(5000);
                ipConnection = await vpnService.ShowIp();

                ipRegion = ipConnection.myIp;
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
            VPNPreferences(true);
            vpnService.preferencesProtocols = true;
        }

        private void VPNPreferencesUDPButtonSwitch_Click(object sender, EventArgs e)
        {
            VPNPreferences(false);
            vpnService.preferencesProtocols = false;
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