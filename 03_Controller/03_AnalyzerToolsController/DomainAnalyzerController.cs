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
    internal class DomainAnalyzerController : IAnalyzer
    {
        private readonly DomainAnalyzerService _domainAnalyzerService;

        public DomainAnalyzerController()
        {
            _domainAnalyzerService = new DomainAnalyzerService();
        }

        public async Task<AnalysisResult> AnalyzeAsync(string domain)
        {
            return await _domainAnalyzerService.AnalyzeDomainAsync(domain);
        }
    }
}
