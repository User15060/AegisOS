using AegisOS._02_Modele._03_AnalyzerToolsModele.Modele;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AegisOS._06_Services
{
    internal class DomainAnalyzerService : MainAnalyzerService
    {
        private readonly string analysisType = "Domain Analyze";

        public async Task<AnalysisResult> AnalyzeDomainAsync(string domainAddress)
        {
            var request = new RestRequest($"domains/{domainAddress}", Method.Get);
            return await ExecuteRequestAsync(request, analysisType);
        }
    }
}
