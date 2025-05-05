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


        public class EncryptToolsConfig
        {
            public string[] CreateDataBaseScript { get; }

            public string ConnectionDataBase { get; }

            public EncryptToolsConfig()
            {
                CreateDataBaseScript = new[] 
                    {@"
                    CREATE TABLE IF NOT EXISTS Users (
                    Id INT PRIMARY KEY AUTO_INCREMENT,
                    Username VARCHAR(50) NOT NULL UNIQUE,
                    PasswordHash VARBINARY(32) NOT NULL,
                    PasswordSalt VARBINARY(32) NOT NULL,
                    CreatedAt DATETIME NOT NULL,
                    FailedAttempts INT DEFAULT 0,
                    IsLocked BOOLEAN DEFAULT FALSE
                    );",
                    @"
                    CREATE TABLE IF NOT EXISTS Files (
                    Id INT PRIMARY KEY AUTO_INCREMENT,
                    UserId INT NOT NULL,
                    FileName VARCHAR(255) NOT NULL,
                    FilePath VARCHAR(255) NOT NULL,
                    OriginalPath VARCHAR(255) NOT NULL,
                    IsDirectory BOOLEAN DEFAULT FALSE,
                    EncryptionDate DATETIME NOT NULL,
                    FOREIGN KEY (UserId) REFERENCES Users(Id)
                    );"};

                ConnectionDataBase = "Server=localhost;Database=cryptage_fichier;Uid=root;Pwd=;";
            }
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
