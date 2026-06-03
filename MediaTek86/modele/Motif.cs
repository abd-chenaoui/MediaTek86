using System;

namespace MediaTek86.modele
{
    /// <summary>
    /// Représente un motif d'absence (ex : maladie, vacances...).
    /// Correspond à la table "motif" de la base de données.
    /// </summary>
    public class Motif
    {
        /// <summary>
        /// Identifiant unique du motif (auto-incrémenté en BDD)
        /// </summary>
        public int Idmotif { get; }

        /// <summary>
        /// Description du motif d'absence
        /// </summary>
        public string Libelle { get; }

        /// <summary>
        /// Crée une instance de Motif.
        /// </summary>
        /// <param name="idmotif">Identifiant unique</param>
        /// <param name="libelle">Description du motif</param>
        public Motif(int idmotif, string libelle)
        {
            Idmotif = idmotif;
            Libelle = libelle;
        }

        /// <summary>
        /// Retourne le libellé pour l'affichage dans les ComboBox.
        /// </summary>
        /// <returns>Description du motif</returns>
        public override string ToString()
        {
            return Libelle;
        }
    }
}
