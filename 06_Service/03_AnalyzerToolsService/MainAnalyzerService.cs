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
    internal class MainAnalyzerService
    {
        private readonly RestClient _client;
        private readonly AppConfig.AnalyzerToolsConfig _config;
        private readonly ApiKeyManager _apiKeyManager;

        public MainAnalyzerService()
        {
            _client = new RestClient();
            _config = new AppConfig.AnalyzerToolsConfig();
            _apiKeyManager = new ApiKeyManager();
        }

        public async Task<AnalysisResult> ExecuteRequestAsync(RestRequest request, string analysisType)
        {
            request.AddHeader("x-apikey", _apiKeyManager.CurrentApiKey);
            request.AddHeader("accept", "application/json");

            var response = await _client.ExecuteAsync(request);
            await Task.Delay(_config.RetryDelay);

            if (response.IsSuccessful)
            {
                return new AnalysisResult
                {
                    IsSuccessful = true,
                    Content = response.Content,
                    AnalysisTime = DateTime.Now,
                    AnalysisType = analysisType,
                    StatusCode = (int)response.StatusCode
                };
            }
            else if ((int)response.StatusCode == 429)
            {
                _apiKeyManager.RotateApiKey();
                return await ExecuteRequestAsync(request, analysisType);
            }
            else
            {
                return new AnalysisResult
                {
                    IsSuccessful = false,
                    ErrorMessage = $"Error: {response.StatusCode}\n{response.Content}",
                    AnalysisTime = DateTime.Now,
                    AnalysisType = analysisType,
                    StatusCode = (int)response.StatusCode
                };
            }
        }   
    }
}