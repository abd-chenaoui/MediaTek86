using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MediaTek86.controleur;
using MediaTek86.modele;

namespace MediaTek86.vue
{
    public partial class FrmListeAbsences : Form
    {
        private Controleur controleur;
        private Personnel personnel;

        private Label lblTitre;
        private DataGridView dgvAbsences;
        private Button btnAjouter;
        private Button btnSupprimer;

        public FrmListeAbsences(Controleur controleur, Personnel personnel)
        {
            this.controleur = controleur;
            this.personnel = personnel;
            InitializeComponent();
            lblTitre.Text = "Absences de " + personnel.Prenom + " " + personnel.Nom;
            ChargerAbsences();
        }

        public void ChargerAbsences()
        {
            List<Absence> liste = controleur.GetLesAbsences(personnel.Idpersonnel);
            dgvAbsences.DataSource = liste;

            if (dgvAbsences.Columns["Idpersonnel"] != null) dgvAbsences.Columns["Idpersonnel"].Visible = false;
            if (dgvAbsences.Columns["Idmotif"] != null) dgvAbsences.Columns["Idmotif"].Visible = false;
            if (dgvAbsences.Columns["Datedebut"] != null) dgvAbsences.Columns["Datedebut"].HeaderText = "Date début";
            if (dgvAbsences.Columns["Datefin"] != null) dgvAbsences.Columns["Datefin"].HeaderText = "Date fin";
            if (dgvAbsences.Columns["LibelleMotif"] != null) dgvAbsences.Columns["LibelleMotif"].HeaderText = "Motif";

            dgvAbsences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void InitializeComponent()
        {
            this.lblTitre = new Label();
            this.dgvAbsences = new DataGridView();
            this.btnAjouter = new Button();
            this.btnSupprimer = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsences)).BeginInit();
            this.SuspendLayout();

            this.lblTitre.Text = "Absences";
            this.lblTitre.Font = new Font("Arial", 11F, FontStyle.Bold);
            this.lblTitre.Location = new Point(12, 15);
            this.lblTitre.AutoSize = true;

            this.dgvAbsences.Location = new Point(12, 50);
            this.dgvAbsences.Size = new Size(560, 210);
            this.dgvAbsences.ReadOnly = true;
            this.dgvAbsences.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAbsences.MultiSelect = false;
            this.dgvAbsences.AllowUserToAddRows = false;

            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Location = new Point(12, 275);
            this.btnAjouter.Size = new Size(110, 32);
            this.btnAjouter.Click += new EventHandler(btnAjouter_Click);

            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Location = new Point(132, 275);
            this.btnSupprimer.Size = new Size(110, 32);
            this.btnSupprimer.Click += new EventHandler(btnSupprimer_Click);

            this.Text = "Absences du personnel";
            this.ClientSize = new Size(586, 325);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.dgvAbsences);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.btnSupprimer);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsences)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FrmSaisieAbsence frm = new FrmSaisieAbsence(controleur, this, personnel);
            frm.ShowDialog();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvAbsences.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sélectionnez une absence.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Absence a = (Absence)dgvAbsences.SelectedRows[0].DataBoundItem;
            DialogResult rep = MessageBox.Show("Supprimer cette absence ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rep == DialogResult.Yes)
            {
                controleur.SupprimerAbsence(a);
                ChargerAbsences();
            }
        }
    }
}
