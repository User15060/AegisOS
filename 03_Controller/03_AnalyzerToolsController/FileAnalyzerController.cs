using System;
using RestSharp;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AegisOS._02_Modele._03_AnalyzerToolsModele.Interface;
using AegisOS._02_Modele._03_AnalyzerToolsModele.Modele;
using System.Windows.Navigation;
using AegisOS._06_Services;

namespace AegisOS._03_Controller._03_AnalyzerToolsController
{
    internal class FileAnalyzerController : IAnalyzer
    {
        private readonly FileAnalyzerService _fileAnalyzerService;

        public FileAnalyzerController()
        {
            _fileAnalyzerService = new FileAnalyzerService();
        }

        public async Task<AnalysisResult> AnalyzeAsync(string filePath)
        {
            return await _fileAnalyzerService.AnalyzeFileAsync(filePath);
        }
    }
}
