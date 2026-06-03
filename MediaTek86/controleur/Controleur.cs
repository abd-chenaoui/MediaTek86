using System;
using System.Collections.Generic;
using MediaTek86.dal;
using MediaTek86.modele;
using MediaTek86.vue;

namespace MediaTek86.controleur
{
    /// <summary>
    /// controleur principal, fait le lien entre les vues et la DAL
    /// </summary>
    public class Controleur
    {
        private FrmConnexion frmConnexion;
        private FrmPrincipal frmPrincipal;

        public Controleur()
        {
            frmConnexion = new FrmConnexion(this);
            frmConnexion.ShowDialog();
        }

        /// <summary>
        /// verifie les identifiants et ouvre la fenetre principale si ok
        /// </summary>
        public bool VerifierIdentifiants(string login, string mdp)
        {
            if (Access.GetInstance().VerifierConnexion(login, mdp))
            {
                frmConnexion.Hide();
                frmPrincipal = new FrmPrincipal(this);
                frmPrincipal.ShowDialog();
                return true;
            }
            return false;
        }

        // ---- personnel ----

        public List<Personnel> GetLesPersonnels()
        {
            return Access.GetInstance().GetLesPersonnels();
        }

        public List<Service> GetLesServices()
        {
            return Access.GetInstance().GetLesServices();
        }

        public void AjouterPersonnel(Personnel p)
        {
            Access.GetInstance().AjouterPersonnel(p);
        }

        public void ModifierPersonnel(Personnel p)
        {
            Access.GetInstance().ModifierPersonnel(p);
        }

        public void SupprimerPersonnel(int id)
        {
            Access.GetInstance().SupprimerPersonnel(id);
        }

        // ---- absences ----

        public List<Absence> GetLesAbsences(int idPersonnel)
        {
            return Access.GetInstance().GetLesAbsences(idPersonnel);
        }

        public List<Motif> GetLesMotifs()
        {
            return Access.GetInstance().GetLesMotifs();
        }

        public void AjouterAbsence(Absence a)
        {
            Access.GetInstance().AjouterAbsence(a);
        }

        public void SupprimerAbsence(Absence a)
        {
            Access.GetInstance().SupprimerAbsence(a);
        }
    }
}
