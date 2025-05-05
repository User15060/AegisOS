using AegisOS._01_App;
using AegisOS._02_Modele._03_AnalyzerToolsModele.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AegisOS._03_Controller._03_AnalyzerToolsController
{
    internal class MainAnalyzerController
    {
        private readonly FileAnalyzerController _fileAnalyzer;
        private readonly UrlAnalyzerController _urlAnalyzer;
        private readonly DomainAnalyzerController _domainAnalyzer;
        private readonly IpAnalyzerController _ipAnalyzer;

        public MainAnalyzerController()
        {
            _fileAnalyzer = new FileAnalyzerController();
            _urlAnalyzer = new UrlAnalyzerController();
            _domainAnalyzer = new DomainAnalyzerController();
            _ipAnalyzer = new IpAnalyzerController();
        }

        public async Task<AnalysisResult> AnalyzeFileAsync(string filePath)
        {
            return await _fileAnalyzer.AnalyzeAsync(filePath);
        }

        public async Task<AnalysisResult> AnalyzeUrlAsync(string url)
        {
            return await _urlAnalyzer.AnalyzeAsync(url);
        }

        public async Task<AnalysisResult> AnalyzeDomainAsync(string domain)
        {
            return await _domainAnalyzer.AnalyzeAsync(domain);
        }

        public async Task<AnalysisResult> AnalyzeIpAsync(string ip)
        {
            return await _ipAnalyzer.AnalyzeAsync(ip);
        }
    }
}
