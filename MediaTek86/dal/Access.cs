using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.bddmanager;
using MediaTek86.modele;

namespace MediaTek86.dal
{
    /// <summary>
    /// Couche d'accès aux données (DAL).
    /// Fait le lien entre le contrôleur et la base de données via BddManager.
    /// Implémente le patron Singleton.
    /// </summary>
    public class Access
    {
        /// <summary>
        /// Chaîne de connexion à la base de données MySQL.
        /// Adapter le login/password selon la configuration locale.
        /// </summary>
        private static readonly string chaineConnexion = "server=localhost;user id=adminmediatek;password=mediatek86;database=mediatek86;SslMode=none;";

        /// <summary>
        /// Instance unique de la classe Access
        /// </summary>
        private static Access instance = null;

        /// <summary>
        /// Référence vers le gestionnaire de base de données
        /// </summary>
        private readonly BddManager bdd;

        /// <summary>
        /// Constructeur privé : initialise la connexion via BddManager
        /// </summary>
        private Access()
        {
            try
            {
                bdd = BddManager.GetInstance(chaineConnexion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'initialisation de l'accès BDD :\n" + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Retourne l'instance unique de la classe Access
        /// </summary>
        /// <returns>L'instance unique de Access</returns>
        public static Access GetInstance()
        {
            if (instance == null)
            {
                instance = new Access();
            }
            return instance;
        }

        // ===================== AUTHENTIFICATION =====================

        /// <summary>
        /// Vérifie les identifiants du responsable dans la base de données.
        /// Le mot de passe est comparé après hachage SHA2-256.
        /// </summary>
        /// <param name="login">Identifiant de connexion</param>
        /// <param name="motDePasse">Mot de passe en clair</param>
        /// <returns>Vrai si l'authentification réussit, faux sinon</returns>
        public bool VerifierConnexion(string login, string motDePasse)
        {
            string requete = "SELECT login FROM responsable WHERE login=@login AND pwd=SHA2(@pwd, 256);";
            Dictionary<string, object> parametres = new Dictionary<string, object>
            {
                { "@login", login },
                { "@pwd", motDePasse }
            };
            List<object[]> resultats = bdd.ExecuterSelect(requete, parametres);
            return resultats.Count > 0;
        }

        // ===================== PERSONNEL =====================

        /// <summary>
        /// Récupère la liste complète du personnel avec le nom de leur service.
        /// </summary>
        /// <returns>Liste des objets Personnel</returns>
        public List<Personnel> GetLesPersonnels()
        {
            List<Personnel> liste = new List<Personnel>();
            string requete = "SELECT p.idpersonnel, p.nom, p.prenom, p.tel, p.mail, p.idservice, s.nom AS nomservice ";
            requete += "FROM personnel p JOIN service s ON p.idservice = s.idservice ORDER BY p.nom, p.prenom;";

            List<object[]> resultats = bdd.ExecuterSelect(requete);
            foreach (object[] ligne in resultats)
            {
                Personnel p = new Personnel(
                    Convert.ToInt32(ligne[0]),
                    ligne[1].ToString(),
                    ligne[2].ToString(),
                    ligne[3].ToString(),
                    ligne[4].ToString(),
                    Convert.ToInt32(ligne[5]),
                    ligne[6].ToString()
                );
                liste.Add(p);
            }
            return liste;
        }

        /// <summary>
        /// Ajoute un nouveau membre du personnel dans la base de données.
        /// </summary>
        /// <param name="personnel">Objet Personnel à insérer</param>
        public void AjouterPersonnel(Personnel personnel)
        {
            string requete = "INSERT INTO personnel (nom, prenom, tel, mail, idservice) VALUES (@nom, @prenom, @tel, @mail, @idservice);";
            Dictionary<string, object> parametres = new Dictionary<string, object>
            {
                { "@nom", personnel.Nom },
                { "@prenom", personnel.Prenom },
                { "@tel", personnel.Tel },
                { "@mail", personnel.Mail },
                { "@idservice", personnel.Idservice }
            };
            bdd.ExecuterUpdate(requete, parametres);
        }

        /// <summary>
        /// Modifie les informations d'un membre du personnel existant.
        /// </summary>
        /// <param name="personnel">Objet Personnel avec les nouvelles valeurs</param>
        public void ModifierPersonnel(Personnel personnel)
        {
            string requete = "UPDATE personnel SET nom=@nom, prenom=@prenom, tel=@tel, mail=@mail, idservice=@idservice WHERE idpersonnel=@id;";
            Dictionary<string, object> parametres = new Dictionary<string, object>
            {
                { "@nom", personnel.Nom },
                { "@prenom", personnel.Prenom },
                { "@tel", personnel.Tel },
                { "@mail", personnel.Mail },
                { "@idservice", personnel.Idservice },
                { "@id", personnel.Idpersonnel }
            };
            bdd.ExecuterUpdate(requete, parametres);
        }

        /// <summary>
        /// Supprime un membre du personnel et toutes ses absences associées.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel à supprimer</param>
        public void SupprimerPersonnel(int idPersonnel)
        {
            string reqAbsences = "DELETE FROM absence WHERE idpersonnel=@id;";
            Dictionary<string, object> param = new Dictionary<string, object> { { "@id", idPersonnel } };
            bdd.ExecuterUpdate(reqAbsences, param);

            string requete = "DELETE FROM personnel WHERE idpersonnel=@id;";
            bdd.ExecuterUpdate(requete, param);
        }

        // ===================== SERVICES =====================

        /// <summary>
        /// Récupère la liste de tous les services, triés par nom.
        /// </summary>
        /// <returns>Liste des objets Service</returns>
        public List<Service> GetLesServices()
        {
            List<Service> liste = new List<Service>();
            string requete = "SELECT idservice, nom FROM service ORDER BY nom;";

            List<object[]> resultats = bdd.ExecuterSelect(requete);
            foreach (object[] ligne in resultats)
            {
                liste.Add(new Service(Convert.ToInt32(ligne[0]), ligne[1].ToString()));
            }
            return liste;
        }

        // ===================== ABSENCES =====================

        /// <summary>
        /// Récupère les absences d'un membre du personnel, triées par date décroissante.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel</param>
        /// <returns>Liste des objets Absence</returns>
        public List<Absence> GetLesAbsences(int idPersonnel)
        {
            List<Absence> liste = new List<Absence>();
            string requete = "SELECT a.idpersonnel, a.datedebut, a.datefin, a.idmotif, m.libelle ";
            requete += "FROM absence a JOIN motif m ON a.idmotif = m.idmotif ";
            requete += "WHERE a.idpersonnel=@id ORDER BY a.datedebut DESC;";

            Dictionary<string, object> parametres = new Dictionary<string, object> { { "@id", idPersonnel } };
            List<object[]> resultats = bdd.ExecuterSelect(requete, parametres);

            foreach (object[] ligne in resultats)
            {
                Absence a = new Absence(
                    Convert.ToInt32(ligne[0]),
                    Convert.ToDateTime(ligne[1]),
                    Convert.ToDateTime(ligne[2]),
                    Convert.ToInt32(ligne[3]),
                    ligne[4].ToString()
                );
                liste.Add(a);
            }
            return liste;
        }

        /// <summary>
        /// Ajoute une absence dans la base de données.
        /// </summary>
        /// <param name="absence">Objet Absence à insérer</param>
        public void AjouterAbsence(Absence absence)
        {
            string requete = "INSERT INTO absence (idpersonnel, datedebut, datefin, idmotif) VALUES (@idp, @debut, @fin, @idm);";
            Dictionary<string, object> parametres = new Dictionary<string, object>
            {
                { "@idp", absence.Idpersonnel },
                { "@debut", absence.Datedebut.ToString("yyyy-MM-dd HH:mm:ss") },
                { "@fin", absence.Datefin.ToString("yyyy-MM-dd HH:mm:ss") },
                { "@idm", absence.Idmotif }
            };
            bdd.ExecuterUpdate(requete, parametres);
        }

        /// <summary>
        /// Supprime une absence identifiée par l'id personnel et la date de début.
        /// </summary>
        /// <param name="absence">Objet Absence à supprimer</param>
        public void SupprimerAbsence(Absence absence)
        {
            string requete = "DELETE FROM absence WHERE idpersonnel=@idp AND datedebut=@debut;";
            Dictionary<string, object> parametres = new Dictionary<string, object>
            {
                { "@idp", absence.Idpersonnel },
                { "@debut", absence.Datedebut.ToString("yyyy-MM-dd HH:mm:ss") }
            };
            bdd.ExecuterUpdate(requete, parametres);
        }

        // ===================== MOTIFS =====================

        /// <summary>
        /// Récupère la liste de tous les motifs d'absence, triés par libellé.
        /// </summary>
        /// <returns>Liste des objets Motif</returns>
        public List<Motif> GetLesMotifs()
        {
            List<Motif> liste = new List<Motif>();
            string requete = "SELECT idmotif, libelle FROM motif ORDER BY libelle;";

            List<object[]> resultats = bdd.ExecuterSelect(requete);
            foreach (object[] ligne in resultats)
            {
                liste.Add(new Motif(Convert.ToInt32(ligne[0]), ligne[1].ToString()));
            }
            return liste;
        }
    }
}
