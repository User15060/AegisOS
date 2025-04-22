using AegisOS._01_App;
using AegisOS._02_Modele._03_AnalyzerToolsModele.Modele;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AegisOS._06_Services
{
    internal class AnalyzerToolsServices
    {
        private readonly RestClient _client;
        private readonly AppConfig.AnalyzerToolsConfig _config;
        private readonly ApiKeyManager _currentApiKey;

        public AnalyzerToolsServices()
        {
            _client = new RestClient();
            _config = new AppConfig.AnalyzerToolsConfig();
            _currentApiKey = new ApiKeyManager();
        }

        public async Task<AnalysisResult> AnalysisFileAsync(string filePath)
        {
            try
            {
                string fileHash = CalculateSHA256(filePath);
                var scanReport = await GetFileAnalyzeAsync(fileHash);

                return new AnalysisResult()
                {
                    IsSuccessful = true,
                    Content = scanReport,
                    AnalysisTime = DateTime.Now,
                    AnalysisType = "File"
                };
            }
            catch (Exception ex)
            {
                return new AnalysisResult()
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.Message,
                    AnalysisTime = DateTime.Now,
                    AnalysisType = "File"
                };
            }
        }


        public async Task<string?> GetFileAnalyzeAsync(string fileHash)
        {
            var virusTotalClient = new RestClient(_config.BaseUrl);
            var fileReportRequest = new RestRequest($"files/{fileHash}", Method.Get);
            fileReportRequest.AddHeader("x-apikey", _currentApiKey.CurrentApiKey);
            fileReportRequest.AddHeader("accept", "application/json");

            try
            {
                var scanGetReport = await virusTotalClient.ExecuteAsync(fileReportRequest);

                if (scanGetReport.IsSuccessful)
                {
                    return scanGetReport.Content;
                }
                else if ((int)scanGetReport.StatusCode == 404)
                {
                    await UploadFileAnalyzeAsync(filePath);
                    await Task.Delay(_config.RetryDelay);
                }
                else if ((int)scanGetReport.StatusCode == 429)
                {
                    _currentApiKey.RotateApiKey();
                    return await GetFileAnalyzeAsync(fileHash);
                }
                else
                {
                    throw new Exception($"Error: {scanGetReport.StatusCode}\n{scanGetReport.Content}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Erreur : {ex.Message}");
                throw new Exception("🚫 Toutes les clés API ont été utilisées.");
                throw;
            }
        }        

        public async Task UploadFileAnalyzeAsync(string filePath)
        {
            var client = new RestClient(_config.BaseUrl);
            var request = new RestRequest("files", Method.Post);
            request.AddHeader("x-apikey", _currentApiKey.CurrentApiKey);
            request.AddFile("file", filePath);

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                Console.WriteLine("📁 Fichier envoyé avec succès.");
            }
            else
            {
                throw new Exception($"❌ Échec de l'envoi du fichier : {response.StatusCode} - {response.Content}");
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
