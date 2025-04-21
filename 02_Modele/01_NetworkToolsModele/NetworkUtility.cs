using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AegisOS._02_Modele._01_NetworkToolsModele
{
    internal class NetworkUtility
    {
        public async Task<(long, string)> PingAsync(string host = "8.8.8.8")
        {
            try
            {
                var ping = new Ping();
                var reply = await ping.SendPingAsync(host, 1000);
                return (reply.RoundtripTime, "");
            }
            catch (Exception ex)
            {
                return (-1, ex.Message);
            }
        }

        public async Task<(string, string)> GetPublicIpAsync()
        {
            try
            {
                using var client = new HttpClient();
                return (await client.GetStringAsync("https://api.ipify.org"), "");
            }
            catch (Exception ex)
            {
                return ("0.0.0.0", ex.Message);
            }
        }
    }
}
