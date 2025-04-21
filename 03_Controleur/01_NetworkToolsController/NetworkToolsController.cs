using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AegisOS._01_App;
using AegisOS._02_Modele._01_NetworkToolsModele;

namespace AegisOS._03_Controleur.NetworkToolsController
{
    internal class NetworkToolsController
    {
        private readonly AppConfig.VpnConfig _config;
        private readonly VpnProcessService _vpnProcessService;
        private readonly NetworkUtility _networkUtility;

        public NetworkToolsController()
        {
            _config = new AppConfig.VpnConfig();
            _vpnProcessService = new VpnProcessService();
            _networkUtility = new NetworkUtility();
        }

        public void SetProtocol(bool useTCP) => _config.UseTCP = useTCP;
        
        public VpnStatus.VpnResult ConnectVpn() => _vpnProcessService.StartVpn(_config);
        
        public VpnStatus.VpnResult DisconnectVpn() => _vpnProcessService.StopVpn();

        public async Task<(string, string)> GetIpStatus() => await _networkUtility.GetPublicIpAsync();
        public async Task<(long, string)> GetPingStatus() => await _networkUtility.PingAsync();


    }
}