using System;

namespace MediaTek86.modele
{
    /// <summary>
    /// Représente un membre du personnel de la médiathèque.
    /// Correspond à la table "personnel" de la base de données.
    /// </summary>
    public class Personnel
    {
        /// <summary>
        /// Identifiant unique du personnel (auto-incrémenté en BDD)
        /// </summary>
        public int Idpersonnel { get; }

        /// <summary>
        /// Nom de famille du membre du personnel
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom du membre du personnel
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Numéro de téléphone
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Adresse e-mail professionnelle
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Identifiant du service auquel appartient le personnel
        /// </summary>
        public int Idservice { get; set; }

        /// <summary>
        /// Nom du service (récupéré via jointure SQL)
        /// </summary>
        public string NomService { get; set; }

        /// <summary>
        /// Crée une instance de Personnel avec toutes ses informations.
        /// </summary>
        /// <param name="idpersonnel">Identifiant unique</param>
        /// <param name="nom">Nom de famille</param>
        /// <param name="prenom">Prénom</param>
        /// <param name="tel">Numéro de téléphone</param>
        /// <param name="mail">Adresse e-mail</param>
        /// <param name="idservice">Identifiant du service</param>
        /// <param name="nomService">Nom du service</param>
        public Personnel(int idpersonnel, string nom, string prenom, string tel, string mail, int idservice, string nomService)
        {
            Idpersonnel = idpersonnel;
            Nom = nom;
            Prenom = prenom;
            Tel = tel;
            Mail = mail;
            Idservice = idservice;
            NomService = nomService;
        }

        /// <summary>
        /// Retourne le nom complet du personnel pour l'affichage dans les listes.
        /// </summary>
        /// <returns>Prénom et nom séparés par un espace</returns>
        public override string ToString()
        {
            return Prenom + " " + Nom;
        }
    }
}
