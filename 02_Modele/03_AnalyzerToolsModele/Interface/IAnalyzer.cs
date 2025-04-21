using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AegisOS._02_Modele._03_AnalyzerToolsModele.Interface
{
    internal interface IAnalyzer
    {
        public interface IAnalyzer
        {
            Task<AnalysisResult> AnalyzeAsync(string input);
            Task<bool> UploadAsync(string input);
        }
    }
}
