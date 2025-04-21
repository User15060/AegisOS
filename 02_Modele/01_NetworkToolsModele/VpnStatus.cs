using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AegisOS._02_Modele._01_NetworkToolsModele
{
    internal class VpnStatus
    {
        public struct VpnResult
        {
            public bool IsSuccess { get; }
            public string Message { get; }

            public VpnResult(bool isSuccess, string message)
            {
                IsSuccess = isSuccess;
                Message = message;
            }
        }
    }
}
