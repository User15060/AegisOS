using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AegisOS._02_Modele._03_AnalyzerToolsModele.Modele
{
    internal class AnalysisResult
    {
        public bool IsSuccessful {  get; set; }
        public string Content { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime AnalysisTime { get; set; }
        public string AnalysisType { get; set; }
    }
}
