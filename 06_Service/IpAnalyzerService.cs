using AegisOS._02_Modele._03_AnalyzerToolsModele.Modele;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AegisOS._06_Services
{
    internal class IpAnalyzerService : MainAnalyzerService
    {
        private readonly string analysisType = "Ip Analyze";

        public async Task<AnalysisResult> AnalyzeIpAsync(string ipAddress) 
        {
            var request = new RestRequest($"ip_addresses/{ipAddress}", Method.Get);
            return await ExecuteRequestAsync(request, analysisType);
        }
    }
}
