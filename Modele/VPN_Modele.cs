using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Numerics;

namespace AegisOS.Modele
{
    internal class VPN_Modele
    {
        private string baseDir;
        private string configPathUDP;
        private string configPathTCP;

        private string programFiles;
        private string pathOpenVpn;

        public bool preferencesProtocols { get; set; }

        private Process? vpnProcess;

        public VPN_Modele()
        {
            baseDir = AppDomain.CurrentDomain.BaseDirectory;
            configPathUDP = Path.Combine(baseDir, "Resources", "OpenVPN", "LosAngelesUDP.ovpn");
            configPathTCP = Path.Combine(baseDir, "Resources", "OpenVPN", "LosAngelesTCP.ovpn");

            programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            pathOpenVpn = Path.Combine(programFiles, "OpenVPN", "bin", "openvpn.exe");
        }


        public struct VpnResult
        {
            public bool IsConnected;
            public string Message;

            public VpnResult(bool isConnected, string message)
            {
                IsConnected = isConnected;
                Message = message;
            }
        }



        // OpenVPN (On)
        public VpnResult OpenVpn()
        {
            (bool success, string message) result = StartVpn();
            return new VpnResult(result.success, result.message);
        }
        // OpenVPN (Off)
        public VpnResult CloseVpn()
        {
            (bool success, string message) result = StopVpn();
            return new VpnResult(result.success, result.message);
        }
        // PingIP
        public async Task<(long, string)> ShowPing()
        {
            return await PingIP();
        }
        public async Task<(string, string)> ShowIp()
        {
            return await ShowIP();
        }



        // Protocol Preference (TCP/UDP)
        private string PreferencesProtocols()
        {  
            return preferencesProtocols ? configPathTCP : configPathUDP;
        }


        // OpenVPN (On/Off)
        private (bool,string) StartVpn()
        {
            string configPathVpn = PreferencesProtocols();

            if (!File.Exists(configPathVpn))
            {
                return(false,($"OpenVPN File or configuration not found.\n{configPathVpn}"));
            }
            
            if (!File.Exists(pathOpenVpn))
            {
                return (false,($"OpenVPN is not installed.\n{pathOpenVpn}"));
            }

            try
            {
                vpnProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = pathOpenVpn,
                        Arguments = $"\"{configPathVpn}\"",
                        Verb = "runas",
                        UseShellExecute = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    }
                };

                vpnProcess.Start();
                return (true, configPathVpn);
            }
            catch (Win32Exception ex)
            {
                return (false,($"Error launching OpenVPN.\n(Code: {ex.NativeErrorCode}): {ex})"));
            }
        }
        private (bool, string) StopVpn()
        {
            try
            {
                if (vpnProcess != null && !vpnProcess.HasExited)
                {
                    vpnProcess.Kill();
                    vpnProcess = null;
                }
                else
                {
                    var processVpnDeconnection = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Verb = "runas",
                        UseShellExecute = true,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        Arguments = "/c taskkill /f /im openvpn.exe & ipconfig /flushdns"
                    };

                    Process.Start(processVpnDeconnection);
                }

                return (true, "VPN Disconnected");
            }
            catch (Exception ex)
            {
                return (false, ($"Unexpected Error.\n{ex.Message}"));
            }
        }


        // Give the IP of the Network
        private async Task<(string, string)> ShowIP()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    return (await httpClient.GetStringAsync("https://api.ipify.org"), "IP Showed");
                }
            }
            catch (HttpRequestException ex)
            {
                return ("0.0.0.0", ($"Https request problem.\n{ex.Message}"));
            }
            catch (TaskCanceledException)
            {
                return ("0.0.0.0", "Query cancelled or timeout.");
            }
            catch (Exception ex)
            {
                return ("0.0.0.0", ($"Unexpected Error.\n{ex.Message}"));
            }
        }

        
        // Give the Ping of the Network (You -> Google | Google -> you)
        private async Task<(long, string)> PingIP()
        {
            try
            {
                Ping myPing = new Ping();
                PingReply reply = await myPing.SendPingAsync("8.8.8.8", 1000);

                return (reply.RoundtripTime, "");
            }
            catch (PingException ex)
            {
                return (-1, ($"Ping Problem.\n{ex.Message}"));
            }
            catch (Exception ex)
            {
                return (-1, ($"Unexpected Error.\n{ex.Message}"));
            }
        }
    }
}
