using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AegisOS._02_Modele._02_EncryptToolsModele;
using Microsoft.VisualBasic.ApplicationServices;

namespace AegisOS._06_Service._02_EncryptToolsService
{
    internal class FileManager
    {

        private readonly CryptoUtils _cryptoUtils;

        public FileManager()
        {
            _cryptoUtils = new CryptoUtils();
        }

        private bool FileExists(string filePath) => File.Exists(filePath);

        public void EncryptFile(string filePath, string outputEncryptedPath, bool keepOriginalFile, byte[] aesSalt, byte[] rsaPublicKey)
        {
            if (!FileExists(filePath))
            {
                Console.WriteLine("Erreur : fichier non trouvé.");
                return;
            }

            byte[] fileData = File.ReadAllBytes(filePath);

            byte[] aesKey = _cryptoUtils.ArgonHashing(Path.GetFileName(filePath), aesSalt);

            byte[] encryptedFileData = _cryptoUtils.AesEncrypt(fileData, aesKey);

            byte[] encryptedAesKey;
            using (var rsa = RSA.Create())
            {
                rsa.ImportRSAPublicKey(rsaPublicKey, out _);
                encryptedAesKey = rsa.Encrypt(aesKey, RSAEncryptionPadding.OaepSHA256);
            }

            using (var output = new BinaryWriter(File.Open(outputEncryptedPath, FileMode.Create)))
            {
                output.Write(encryptedAesKey.Length);
                output.Write(encryptedAesKey);
                output.Write(encryptedFileData);
            }

            if (!keepOriginalFile)
                File.Delete(filePath);

            CryptographicOperations.ZeroMemory(aesKey);
        }



        public void DecryptFile(string decryptedFilePath, string encryptedFilePath, bool keepEncrypted, byte[] aesSalt, UserAccount user)
        {
            if (!FileExists(encryptedFilePath))
            {
                Console.WriteLine("Erreur : fichier chiffré introuvable.");
                return;
            }

            using var input = new BinaryReader(File.OpenRead(encryptedFilePath));

            int encryptedAesKeyLength = input.ReadInt32();
            byte[] encryptedAesKey = input.ReadBytes(encryptedAesKeyLength);

            byte[] encryptedFileData = input.ReadBytes((int)(input.BaseStream.Length - input.BaseStream.Position));

            byte[] aesKeyForPrivateKey = _cryptoUtils.ArgonHashing(Convert.ToBase64String(user.PasswordHash), user.AesSalt);
            byte[] rsaPrivateKey = _cryptoUtils.DecryptPrivateKey(user.RsaPrivateKeyEncrypted, aesKeyForPrivateKey);

            byte[] aesKey;
            using (var rsa = RSA.Create())
            {
                rsa.ImportRSAPrivateKey(rsaPrivateKey, out _);
                aesKey = rsa.Decrypt(encryptedAesKey, RSAEncryptionPadding.OaepSHA256);
            }

            byte[] decryptedFileData = _cryptoUtils.DecryptAes(encryptedFileData, aesKey);

            File.WriteAllBytes(decryptedFilePath, decryptedFileData);

            if (!keepEncrypted)
                File.Delete(encryptedFilePath);

            var guid = _cryptoUtils.Hash256(decryptedFilePath).ToString();

            user.EncryptedFiles.Add(new FileModel(Path.GetFileName(decryptedFilePath), guid, aesSalt));

            CryptographicOperations.ZeroMemory(aesKey);
            CryptographicOperations.ZeroMemory(rsaPrivateKey);
            CryptographicOperations.ZeroMemory(aesKeyForPrivateKey);
        }
    }
}


/*
En gros, mon fileModel permet de stocker le nom, le GUID 'ID' du fichier, AesSalt,...
Il faut encrypter le fichier, une fois fais, l'enregistré dedans dans FileModel
Et faire le décryptage
GUID -> SHA256
Aes -> Encrypt les bite du dosser
Aes crypte en RSA
AesSalt, stocké dans le MySQL pour décrypter la clé


FileManager, permet de crypter/décrypter des fichier/donner le GUID
GOOD - CryptoUtils, tous les hash
FileModel -> modele de notre fichier a stocker
UserAccount -> modele de notre fichier a stocker
UserController -> Crée Compte/Login -> Stockage des données
FileController -> Décryptage, cryptage fichier
*/

