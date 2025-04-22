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

namespace AegisOS._03_Controller._03_AnalyzerToolsController
{
    internal class FileAnalyzerController : IAnalyzer
    {
        private readonly IAnalyzer _analyzer;


        private async Task<AnalysisResult> AnalyzeAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new AnalysisResult()
                {
                    IsSuccessful = false,
                    ErrorMessage = "File not found",
                    AnalysisTime = DateTime.Now,
                    AnalysisType = "File Analyze",
                };
            }

            try
            {
 
                return new AnalysisResult()
                {
                    IsSuccessful = true,
                    Content = result.Content,
                    AnalysisTime = result.AnalysisTime,
                    AnalysisType = result.AnalysisType,
                };
            }
            catch (Exception ex)
            {
                return new AnalysisResult()
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.Message,
                    AnalysisTime = DateTime.Now,
                    AnalysisType = "File Analyze",
                };
            }
        }        
    }
}
