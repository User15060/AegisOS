using AegisOS._02_Modele._03_AnalyzerToolsModele.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AegisOS._01_App
{
    internal class AppConfig
    {
        public class NetworkToolsConfig
        {
            public string ConfigPathUDP { get; }
            public string ConfigPathTCP { get; }
            public string OpenVpnExePath { get; }
            public bool UseTCP { get; set; } = false;

            public NetworkToolsConfig()
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

                ConfigPathUDP = Path.Combine(baseDir, "Resources", "OpenVPN", "LosAngelesUDP.ovpn");
                ConfigPathTCP = Path.Combine(baseDir, "Resources", "OpenVPN", "LosAngelesTCP.ovpn");
                OpenVpnExePath = Path.Combine(programFiles, "OpenVPN", "bin", "openvpn.exe");
            }

            public string GetPreferredConfigPath() => UseTCP ? ConfigPathTCP : ConfigPathUDP;
        }


        public class AnalyzerToolsConfig
        {
            public string BaseUrl { get; set; }
            public int RetryDelay { get; set; }
            public int MaxRetries { get; set; }
            public readonly ApiKeyManager _apiKeys;

            public AnalyzerToolsConfig()
            {
                BaseUrl = "https://www.virustotal.com/api/v3";
                RetryDelay = 15000;
                MaxRetries = 3;
                _apiKeys = new ApiKeyManager();
            }
            public void AddApiKey(string apiKey) => _apiKeys.AddApiKey(apiKey);
            public void RemoveApiKey(string apiKey) => _apiKeys.RemoveApiKey(apiKey);
            public string GetCurrentApiKey() => _apiKeys.CurrentApiKey;
            public void RotateApiKey() => _apiKeys.RotateApiKey();
        }
    }
}
