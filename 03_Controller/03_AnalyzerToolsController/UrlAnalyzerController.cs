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
    internal class UrlAnalyzerController : IAnalyzer
    {
        private readonly UrlAnalyzerService _urlAnalyzerService;

        public UrlAnalyzerController()
        {
            _urlAnalyzerService = new UrlAnalyzerService();
        }

        public async Task<AnalysisResult> AnalyzeAsync(string url)
        {
            return await _urlAnalyzerService.AnalyzeUrlAsync(url);
        }
    }
}
