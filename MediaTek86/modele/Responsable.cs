using System;

namespace MediaTek86.modele
{
    /// <summary>
    /// Représente le responsable administratif autorisé à se connecter à l'application.
    /// Correspond à la table "responsable" de la base de données.
    /// </summary>
    public class Responsable
    {
        /// <summary>
        /// Identifiant de connexion du responsable
        /// </summary>
        public string Login { get; }

        /// <summary>
        /// Mot de passe haché (SHA2-256) du responsable
        /// </summary>
        public string Pwd { get; }

        /// <summary>
        /// Crée une instance de Responsable.
        /// </summary>
        /// <param name="login">Identifiant de connexion</param>
        /// <param name="pwd">Mot de passe haché</param>
        public Responsable(string login, string pwd)
        {
            Login = login;
            Pwd = pwd;
        }
    }
}
