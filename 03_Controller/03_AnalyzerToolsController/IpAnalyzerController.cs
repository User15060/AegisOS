using AegisOS._02_Modele._03_AnalyzerToolsModele.Interface;
using AegisOS._02_Modele._03_AnalyzerToolsModele.Modele;
using AegisOS._06_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AegisOS._03_Controller._03_AnalyzerToolsController
{
    internal class IpAnalyzerController : IAnalyzer
    {
        private readonly IpAnalyzerService _ipAnalyzerService;

        public IpAnalyzerController()
        {
            _ipAnalyzerService = new IpAnalyzerService();
        }

        public async Task<AnalysisResult> AnalyzeAsync(string ip)
        {
            return await _ipAnalyzerService.AnalyzeIpAsync(ip);
        }
    }
}
