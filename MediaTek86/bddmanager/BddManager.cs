using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MediaTek86.bddmanager
{
    /// <summary>
    /// classe qui gere la connexion a la base de données
    /// c'est un singleton donc une seule instance possible
    /// on passe par Access pour l'utiliser
    /// </summary>
    public class BddManager
    {
        /// <summary>
        /// l'instance unique
        /// </summary>
        private static BddManager instance = null;

        /// <summary>
        /// la connexion mysql
        /// </summary>
        private readonly MySqlConnection connexion;

        /// <summary>
        /// pour eviter les problemes si plusieurs threads en meme temps
        /// </summary>
        private static readonly object verrou = new object();

        /// <summary>
        /// constructeur prive qui ouvre la connexion
        /// </summary>
        /// <param name="chaineConnexion">la chaine de connexion a la bdd</param>
        private BddManager(string chaineConnexion)
        {
            try
            {
                connexion = new MySqlConnection(chaineConnexion);
                connexion.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données :\n" + ex.Message,
                    "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// retourne l'instance unique, la cree si elle existe pas encore
        /// </summary>
        /// <param name="chaineConnexion">la chaine de connexion</param>
        /// <returns>l'instance de BddManager</returns>
        public static BddManager GetInstance(string chaineConnexion)
        {
            if (instance == null)
            {
                lock (verrou)
                {
                    if (instance == null)
                    {
                        instance = new BddManager(chaineConnexion);
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// execute un SELECT et retourne les resultats
        /// </summary>
        /// <param name="requete">la requete sql</param>
        /// <param name="parametres">les parametres si besoin</param>
        /// <returns>liste de tableaux avec les resultats</returns>
        public List<object[]> ExecuterSelect(string requete, Dictionary<string, object> parametres = null)
        {
            List<object[]> resultats = new List<object[]>();
            MySqlCommand commande = new MySqlCommand(requete, connexion);

            if (parametres != null)
            {
                foreach (KeyValuePair<string, object> param in parametres)
                {
                    commande.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                }
            }

            try
            {
                commande.Prepare();
                MySqlDataReader lecteur = commande.ExecuteReader();
                int nbColonnes = lecteur.FieldCount;

                while (lecteur.Read())
                {
                    object[] ligne = new object[nbColonnes];
                    lecteur.GetValues(ligne);
                    resultats.Add(ligne);
                }

                lecteur.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur dans le select : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return resultats;
        }

        /// <summary>
        /// execute un INSERT UPDATE ou DELETE
        /// </summary>
        /// <param name="requete">la requete sql</param>
        /// <param name="parametres">les parametres si besoin</param>
        public void ExecuterUpdate(string requete, Dictionary<string, object> parametres = null)
        {
            MySqlCommand commande = new MySqlCommand(requete, connexion);

            if (parametres != null)
            {
                foreach (KeyValuePair<string, object> param in parametres)
                {
                    commande.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                }
            }

            try
            {
                commande.Prepare();
                commande.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur dans la requete : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
