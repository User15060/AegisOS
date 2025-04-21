using System;
using RestSharp;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AegisOS._02_Modele._03_AnalyzerToolsModele.Interface;

namespace AegisOS._03_Controller._03_AnalyzerToolsController
{
    internal class FileAnalyzerController : IAnalyzer
    {
        public static async Task AskFilePath()
        {
            Console.Write("Chemin du fichier à analyser : ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("❌ Fichier introuvable.");
                return;
            }

            try
            {
                Console.WriteLine("⏳ Analyse en cours...");
                var result = await AnalyzeFileAsync(filePath);

                if (result != null)
                {
                    Console.WriteLine("\n=== ✅ Rapport VirusTotal ===");
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("❗ Rapport non récupéré.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erreur lors de l'analyse : {ex.Message}");
            }

            Console.WriteLine("✅ Terminé.");
        }




        public static async Task<string?> AnalyzeFileAsync(string filePath)
        {
            string fileHash = CalculateSHA256(filePath);

            for (int attempt = 0; attempt < _apiKeys.Count; attempt++)
            {
                var client = new RestClient("https://www.virustotal.com/api/v3");
                var request = new RestRequest($"files/{fileHash}", Method.Get);
                request.AddHeader("x-apikey", CurrentApiKey);
                request.AddHeader("accept", "application/json");

                try
                {
                    var response = await client.ExecuteAsync(request);
                    if (response.IsSuccessful)
                    {
                        Console.WriteLine("✅ Rapport récupéré !");
                        return response.Content;
                    }
                    else if ((int)response.StatusCode == 404)
                    {
                        Console.WriteLine("📤 Fichier non présent, envoi à VirusTotal...");
                        await UploadFileAsync(filePath);
                        await Task.Delay(15000); // Attendre l’analyse
                                                 // Relancer la récupération du rapport
                        continue;
                    }
                    else if ((int)response.StatusCode == 429)
                    {
                        Console.WriteLine("⏳ Limite atteinte. Rotation de clé...");
                        RotateApiKey();
                    }
                    else
                    {
                        Console.WriteLine($"❌ Erreur API : {response.StatusCode} - {response.Content}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠️ Erreur : {ex.Message}");
                    throw;
                }
            }

            throw new Exception("🚫 Toutes les clés API ont été utilisées.");
        }
        public static async Task UploadFileAsync(string filePath)
        {
            var client = new RestClient("https://www.virustotal.com/api/v3");
            var request = new RestRequest("files", Method.Post);
            request.AddHeader("x-apikey", CurrentApiKey);
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
        public static string CalculateSHA256(string filePath)
        {
            using var sha256 = SHA256.Create();
            using var stream = File.OpenRead(filePath);
            var hash = sha256.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}
