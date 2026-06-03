using System;

namespace MediaTek86.modele
{
    /// <summary>
    /// Représente une absence d'un membre du personnel.
    /// Correspond à la table "absence" de la base de données.
    /// La clé primaire est composée de idpersonnel + datedebut.
    /// </summary>
    public class Absence
    {
        /// <summary>
        /// Identifiant du personnel concerné par l'absence
        /// </summary>
        public int Idpersonnel { get; }

        /// <summary>
        /// Date et heure de début de l'absence
        /// </summary>
        public DateTime Datedebut { get; set; }

        /// <summary>
        /// Date et heure de fin de l'absence
        /// </summary>
        public DateTime Datefin { get; set; }

        /// <summary>
        /// Identifiant du motif de l'absence
        /// </summary>
        public int Idmotif { get; set; }

        /// <summary>
        /// Libellé du motif (récupéré via jointure SQL)
        /// </summary>
        public string LibelleMotif { get; set; }

        /// <summary>
        /// Crée une instance d'Absence.
        /// </summary>
        /// <param name="idpersonnel">Identifiant du personnel</param>
        /// <param name="datedebut">Date de début</param>
        /// <param name="datefin">Date de fin</param>
        /// <param name="idmotif">Identifiant du motif</param>
        /// <param name="libelleMotif">Libellé du motif</param>
        public Absence(int idpersonnel, DateTime datedebut, DateTime datefin, int idmotif, string libelleMotif)
        {
            Idpersonnel = idpersonnel;
            Datedebut = datedebut;
            Datefin = datefin;
            Idmotif = idmotif;
            LibelleMotif = libelleMotif;
        }
    }
}
