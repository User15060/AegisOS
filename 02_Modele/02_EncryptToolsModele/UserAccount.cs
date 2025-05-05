using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AegisOS._06_Service._02_EncryptToolsService;
using AegisOS._06_Services;

namespace AegisOS._02_Modele._02_EncryptToolsModele
{
    internal class UserAccount
    {
        private readonly CryptoUtils _cryptoUtils;

        public required string Username { get; init; }
        public required string Password { get; init; }

        public required byte[] PasswordHash { get; init; }
        public required byte[] PasswordSalt { get; init; }

        public required byte[] AesSalt { get; init; }

        public required byte[] RsaPublicKey { get; init; }
        public required byte[] RsaPrivateKeyEncrypted { get; init; }

        public DateTime CreatedAt { get; init; }

        public List<FileModel> EncryptedFiles { get; init; }

        public UserAccount(string username, string password)
        {
            _cryptoUtils = new CryptoUtils();

            this.Username = username;
            this.Password = password;

            PasswordSalt = _cryptoUtils.GenerateSalt(32);
            PasswordHash = _cryptoUtils.ArgonHashing(Password, PasswordSalt);

            AesSalt = _cryptoUtils.GenerateSalt(32);
            var AesKey = _cryptoUtils.ArgonHashing(Convert.ToBase64String(PasswordHash), AesSalt);

            (RsaPublicKey, var rsaPrivateKey) = _cryptoUtils.GenerateRsaKeys();
            RsaPrivateKeyEncrypted = _cryptoUtils.EncryptPrivateKey(rsaPrivateKey, AesKey);

            CryptographicOperations.ZeroMemory(AesKey);
            CryptographicOperations.ZeroMemory(rsaPrivateKey);

            CreatedAt = DateTime.Now;

            EncryptedFiles = new List<FileModel>();
        }
    }
}
