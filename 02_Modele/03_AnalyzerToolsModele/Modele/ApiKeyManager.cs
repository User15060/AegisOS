using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AegisOS._02_Modele._03_AnalyzerToolsModele.Modele
{
    internal class ApiKeyManager
    {

        private readonly List<string> _apiKeys;
        private int _currentKeyIndex;

        public ApiKeyManager()
        {
            _apiKeys = new List<string>();
            _currentKeyIndex = 0;
        }

        public string CurrentApiKey => _apiKeys[_currentKeyIndex];

        public void RotateApiKey()
        {
            _currentKeyIndex = (_currentKeyIndex + 1) % _apiKeys.Count;
        }

        public void AddApiKey(string apiKey)
        {
            if (!string.IsNullOrWhiteSpace(apiKey) || !_apiKeys.Contains(apiKey))
            {
                _apiKeys.Add(apiKey);
            }
        }

        public void RemoveApiKey(string apiKey)
        {
            if (_apiKeys.Count > 0)
            {
                _apiKeys.Remove(apiKey);
            }
        }

        public IReadOnlyList<string> GetAllApiKeys() => _apiKeys.AsReadOnly();
    }
}
