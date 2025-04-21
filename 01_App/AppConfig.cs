using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AegisOS._01_App
{
    internal class AppConfig
    {
        public class VpnConfig
        {
            public string ConfigPathUDP { get; }
            public string ConfigPathTCP { get; }
            public string OpenVpnExePath { get; }
            public bool UseTCP { get; set; } = false;

            public VpnConfig()
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

                ConfigPathUDP = Path.Combine(baseDir, "Resources", "OpenVPN", "LosAngelesUDP.ovpn");
                ConfigPathTCP = Path.Combine(baseDir, "Resources", "OpenVPN", "LosAngelesTCP.ovpn");
                OpenVpnExePath = Path.Combine(programFiles, "OpenVPN", "bin", "openvpn.exe");
            }

            public string GetPreferredConfigPath() => UseTCP ? ConfigPathTCP : ConfigPathUDP;
        }
    }
}
