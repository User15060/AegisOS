using AegisOS._01_App;
using AegisOS._02_Modele._03_AnalyzerToolsModele.Modele;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AegisOS._06_Services
{
    internal class FileAnalyzerService : MainAnalyzerService
    {
        private readonly string analysisType = "File Analyze";
        private readonly AppConfig.AnalyzerToolsConfig _config;

        public async Task<AnalysisResult> AnalyzeFileAsync(string fileAddress)
        {
            if (!File.Exists(fileAddress))
            {
                return new AnalysisResult
                {
                    IsSuccessful = false,
                    ErrorMessage = $"Error: File not found at path '{fileAddress}'.",
                    AnalysisTime = DateTime.Now,
                    AnalysisType = analysisType,
                    StatusCode = -1
                };
            }

            string fileHash = CalculateSHA256(fileAddress);
            var response = await GetFileAnalyzeAsync(fileHash);

            if (!response.IsSuccessful && response.StatusCode == 404)
            {
                await UploadFileAnalyzeAsync(fileHash);
                await Task.Delay(_config.RetryDelay);
                return await GetFileAnalyzeAsync(fileHash);
            }

            return response;
        }

        private async Task<AnalysisResult> GetFileAnalyzeAsync(string fileHash)
        {
            var request = new RestRequest($"files/{fileHash}", Method.Get);
            return await ExecuteRequestAsync(request, analysisType);
        }

        public async Task UploadFileAnalyzeAsync(string filePath)
        {
            var request = new RestRequest("files", Method.Post);
            request.AddFile("file", filePath);

            var response = await ExecuteRequestAsync(request, analysisType);
            if (!response.IsSuccessful)
            {
                response.ErrorMessage = $"Error: Upload failed.\nStatus Code: {response.StatusCode}\nDetails: {response.ErrorMessage}";
            }
        }

        private string CalculateSHA256(string filePath)
        {
            using var sha256 = SHA256.Create();
            using var stream = File.OpenRead(filePath);
            var hash = sha256.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}
