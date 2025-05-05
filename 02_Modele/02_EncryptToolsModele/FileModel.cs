using AegisOS._06_Service._02_EncryptToolsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace AegisOS._02_Modele._02_EncryptToolsModele
{
    internal class FileModel
    {
        public required string FileName { get; init; }
        public required string GUID { get; init; }
        public required byte[] AesSalt { get; init; }
        public required DateTime EncryptionDate { get; init; }

        public FileModel(string fileName, string guid, byte[] aesSalt)
        {
            this.FileName = fileName;
            this.GUID = guid;
            this.AesSalt = aesSalt;
            this.EncryptionDate = DateTime.Now;
        }
    }
}
