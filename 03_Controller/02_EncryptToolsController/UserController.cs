using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AegisOS._02_Modele._02_EncryptToolsModele;
using AegisOS._06_Service._02_EncryptToolsService;
using Konscious.Security.Cryptography;

namespace AegisOS._03_Controller._02_EncryptToolsController
{
    internal class UserController
    {
        
        private readonly DatabaseManager dbManager;

        public UserController()
        {
            dbManager = new DatabaseManager();
        }

        public UserAccount AuthenticateOrRegister(string username, string password)
        {
            if (Database.UserExists(username))
            {
                var user = LoginUser(username, password);
                if (user == null)
                {
                    Console.WriteLine("Mot de passe incorrect.");
                    return null;
                }
                Console.WriteLine("Connexion réussie.");
                return user;
            }
            else
            {
                var newUser = CreateUser(username, password);
                Console.WriteLine("Utilisateur créé avec succès.");
                return newUser;
            }
        }

        public UserAccount? LoginUser(string username, string password)
        {
            var user = Database.GetUser(username); // Récupère l'utilisateur stocké

            if (user == null)
                return null;

            var crypto = new CryptoUtils();

            bool isValid = crypto.VerifyArgonHashing(password, user.PasswordSalt, user.PasswordHash);
            return isValid ? user : null;
        }

        public UserAccount CreateUser(string username, string password)
        {
            if (Database.UserExists(username))
            {
                throw new Exception("Un utilisateur avec ce nom existe déjà.");
            }

            var newUser = new UserAccount(username, password);
            Database.SaveUser(newUser); // Fonction fictive : à adapter selon ton stockage (fichier, MySQL, etc.)
            return newUser;
        }

    }
}
