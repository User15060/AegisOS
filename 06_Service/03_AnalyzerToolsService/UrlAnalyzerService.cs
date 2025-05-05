using AegisOS._01_App;
using AegisOS._02_Modele._03_AnalyzerToolsModele.Modele;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AegisOS._06_Services
{
    internal class UrlAnalyzerService : MainAnalyzerService
    {
        private readonly string analysisType = "Url Analyze";
        private readonly AppConfig.AnalyzerToolsConfig _config;

        public async Task<AnalysisResult> AnalyzeUrlAsync(string urlAddress)
        {
            string urlHash = CalculateBase64(urlAddress);
            var response = await GetUrlAnalyzeAsync(urlHash);

            if (!response.IsSuccessful && response.StatusCode == 404)
            {
                await UploadUrlAnalyzeAsync(urlHash);
                await Task.Delay(_config.RetryDelay);
                return await GetUrlAnalyzeAsync(urlHash);
            }

            return response;
        }

        private async Task<AnalysisResult?> GetUrlAnalyzeAsync(string urlHash)
        {
            var request = new RestRequest($"urls/{urlHash}", Method.Get);
            return await ExecuteRequestAsync(request, analysisType);
        }
        
        private async Task UploadUrlAnalyzeAsync(string urlPath)
        {
            var request = new RestRequest("urls", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"url={urlPath}", ParameterType.RequestBody);

            var response = await ExecuteRequestAsync(request, analysisType);
            if (!response.IsSuccessful)
            {
                response.ErrorMessage = $"Error: Upload failed.\nStatus Code: {response.StatusCode}\nDetails: {response.ErrorMessage}";
            }
        }

        private string CalculateBase64(string urlAddress)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(urlAddress);
            return System.Convert.ToBase64String(plainTextBytes).TrimEnd('=');
        }
    }
}
