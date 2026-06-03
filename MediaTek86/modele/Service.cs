using System;

namespace MediaTek86.modele
{
    /// <summary>
    /// Représente un service de la médiathèque (ex : administratif, prêt...).
    /// Correspond à la table "service" de la base de données.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Identifiant unique du service (auto-incrémenté en BDD)
        /// </summary>
        public int Idservice { get; }

        /// <summary>
        /// Nom du service
        /// </summary>
        public string Nom { get; }

        /// <summary>
        /// Crée une instance de Service.
        /// </summary>
        /// <param name="idservice">Identifiant unique</param>
        /// <param name="nom">Nom du service</param>
        public Service(int idservice, string nom)
        {
            Idservice = idservice;
            Nom = nom;
        }

        /// <summary>
        /// Retourne le nom du service pour l'affichage dans les ComboBox.
        /// </summary>
        /// <returns>Nom du service</returns>
        public override string ToString()
        {
            return Nom;
        }
    }
}
