using AegisOS._01_App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AegisOS._02_Modele._01_NetworkToolsModele
{
    internal class VpnProcessService
    {
        private Process? _vpnProcess;

        public VpnStatus.VpnResult StartVpn(AppConfig.VpnConfig config)
        {
            string selectedConfig = config.GetPreferredConfigPath();
            if (!File.Exists(selectedConfig))
                return new VpnStatus.VpnResult(false, $"Config not found: {selectedConfig}");

            if (!File.Exists(config.OpenVpnExePath))
                return new VpnStatus.VpnResult(false, $"OpenVPN not found: {config.OpenVpnExePath}");

            try
            {
                _vpnProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = config.OpenVpnExePath,
                        Arguments = $"\"{selectedConfig}\"",
                        Verb = "runas",
                        UseShellExecute = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    }
                };

                _vpnProcess.Start();
                return new VpnStatus.VpnResult(true, "VPN started");
            }
            catch (Win32Exception ex)
            {
                return new VpnStatus.VpnResult(false, $"Start failed: {ex.Message}");
            }
        }

        public VpnStatus.VpnResult StopVpn()
        {
            try
            {
                if (_vpnProcess != null && !_vpnProcess.HasExited)
                {
                    _vpnProcess.Kill();
                    _vpnProcess = null;
                }
                else
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = "/c taskkill /f /im openvpn.exe & ipconfig /flushdns",
                        Verb = "runas",
                        UseShellExecute = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    });
                }

                return new VpnStatus.VpnResult(true, "VPN stopped");
            }
            catch (Exception ex)
            {
                return new VpnStatus.VpnResult(false, $"Stop failed: {ex.Message}");
            }
        }
    }
}

