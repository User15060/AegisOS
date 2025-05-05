using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;
using System.Security.Policy;


namespace AegisOS._06_Service._02_EncryptToolsService
{
    internal class CryptoUtils
    {
        public byte[] GenerateSalt(int lengthByte)
        {
            byte[] salt = new byte[lengthByte];
            using (var randomsalt = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                randomsalt.GetBytes(salt);
            }
            return salt;
        }

        public byte[] ArgonHashing(string dataToEncrypt, byte[] salt)
        {
            using (var hasher = new Argon2id(Encoding.UTF8.GetBytes(dataToEncrypt)))
            {
                hasher.Salt = salt;
                hasher.DegreeOfParallelism = 12;
                hasher.MemorySize = 131072; //Ko
                hasher.Iterations = 10;
                return hasher.GetBytes(32);
            }
        }

        public bool VerifyArgonHashing(string dataToVerify, byte[] salt, byte[] storedKeyHash)
        {
            using (var hasher = new Argon2id(Encoding.UTF8.GetBytes(dataToVerify)))
            {
                hasher.Salt = salt;
                hasher.DegreeOfParallelism = 12;
                hasher.MemorySize = 131072; //Ko
                hasher.Iterations = 10;
                byte[] newHash = hasher.GetBytes(32);
                return newHash.SequenceEqual(storedKeyHash);
            }
        }

        public byte[] AesEncrypt(byte[] dataToEncrypt, byte[] aesKey)
        {
            byte[] iv = GenerateSalt(16);

            using var aes = Aes.Create();
            aes.Key = aesKey;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var encryptor = aes.CreateEncryptor();
            byte[] encryptedData = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);

            return iv.Concat(encryptedData).ToArray();
        }

        public byte[] DecryptAes(byte[] encryptedData, byte[] aesKey)
        {
            byte[] iv = encryptedData.Take(16).ToArray();
            byte[] cipherText = encryptedData.Skip(16).ToArray();

            using var aes = Aes.Create();
            aes.Key = aesKey;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var decryptor = aes.CreateDecryptor();
            return decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
        }

        public (byte[] PublicKey, byte[] PrivateKey) GenerateRsaKeys()
        {
            using var rsa = RSA.Create(4096);
            byte[] publicKey = rsa.ExportRSAPublicKey();
            byte[] privateKey = rsa.ExportRSAPrivateKey();
            return (publicKey, privateKey);
        }

        public byte[] EncryptPrivateKey(byte[] privateKey, byte[] aesKey)
        {
            return AesEncrypt(privateKey, aesKey);
        }

        public byte[] DecryptPrivateKey(byte[] encryptedPrivateKey, byte[] aesKey)
        {
            return DecryptAes(encryptedPrivateKey, aesKey);
        }

        public Guid Hash256(string filepath)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] fileBytes = File.ReadAllBytes(filepath); 
                byte[] hashBytes = sha256.ComputeHash(fileBytes);

                return new Guid(hashBytes.Take(16).ToArray());
            }
        }
    }
}

