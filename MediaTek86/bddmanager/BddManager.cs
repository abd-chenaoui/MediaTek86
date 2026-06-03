using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MediaTek86.bddmanager
{
    /// <summary>
    /// Gestion de la connexion à la base de données MySQL.
    /// Implémente le patron de conception Singleton.
    /// Ne doit pas être utilisée directement : passer par la classe Access.
    /// </summary>
    public class BddManager
    {
        /// <summary>
        /// Instance unique de BddManager (patron Singleton)
        /// </summary>
        private static BddManager instance = null;

        /// <summary>
        /// Objet de connexion MySQL
        /// </summary>
        private readonly MySqlConnection connexion;

        /// <summary>
        /// Verrou pour la gestion du multithread
        /// </summary>
        private static readonly object verrou = new object();

        /// <summary>
        /// Constructeur privé : ouvre la connexion à la base de données
        /// </summary>
        /// <param name="chaineConnexion">Chaîne de connexion MySQL</param>
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
        /// Retourne l'instance unique de BddManager, en la créant si nécessaire.
        /// </summary>
        /// <param name="chaineConnexion">Chaîne de connexion MySQL</param>
        /// <returns>L'instance unique de BddManager</returns>
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
        /// Exécute une requête SELECT et retourne les résultats sous forme de liste.
        /// </summary>
        /// <param name="requete">Requête SQL SELECT</param>
        /// <param name="parametres">Paramètres de la requête (optionnel)</param>
        /// <returns>Liste de tableaux d'objets représentant les lignes résultantes</returns>
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
                MessageBox.Show("Erreur lors de l'exécution de la requête SELECT :\n" + ex.Message,
                    "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return resultats;
        }

        /// <summary>
        /// Exécute une requête de modification (INSERT, UPDATE, DELETE).
        /// </summary>
        /// <param name="requete">Requête SQL de modification</param>
        /// <param name="parametres">Paramètres de la requête (optionnel)</param>
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
                MessageBox.Show("Erreur lors de l'exécution de la requête :\n" + ex.Message,
                    "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
