using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MediaTek86.controleur;
using MediaTek86.modele;

namespace MediaTek86.vue
{
    public partial class FrmPrincipal : Form
    {
        private Controleur controleur;

        private DataGridView dgvPersonnel;
        private Button btnAjouter;
        private Button btnModifier;
        private Button btnSupprimer;
        private Button btnAbsences;
        private Label lblTitre;

        public FrmPrincipal(Controleur controleur)
        {
            this.controleur = controleur;
            InitializeComponent();
            ChargerPersonnels();
        }

        // charge la liste du personnel dans le tableau
        private void ChargerPersonnels()
        {
            List<Personnel> liste = controleur.GetLesPersonnels();
            dgvPersonnel.DataSource = liste;

            if (dgvPersonnel.Columns["Idpersonnel"] != null) dgvPersonnel.Columns["Idpersonnel"].Visible = false;
            if (dgvPersonnel.Columns["Idservice"] != null) dgvPersonnel.Columns["Idservice"].Visible = false;
            if (dgvPersonnel.Columns["NomService"] != null) dgvPersonnel.Columns["NomService"].HeaderText = "Service";
            if (dgvPersonnel.Columns["Nom"] != null) dgvPersonnel.Columns["Nom"].HeaderText = "Nom";
            if (dgvPersonnel.Columns["Prenom"] != null) dgvPersonnel.Columns["Prenom"].HeaderText = "Prénom";
            if (dgvPersonnel.Columns["Tel"] != null) dgvPersonnel.Columns["Tel"].HeaderText = "Téléphone";
            if (dgvPersonnel.Columns["Mail"] != null) dgvPersonnel.Columns["Mail"].HeaderText = "Mail";

            dgvPersonnel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void ActualiserListe()
        {
            ChargerPersonnels();
        }

        private void InitializeComponent()
        {
            this.dgvPersonnel = new DataGridView();
            this.btnAjouter = new Button();
            this.btnModifier = new Button();
            this.btnSupprimer = new Button();
            this.btnAbsences = new Button();
            this.lblTitre = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).BeginInit();
            this.SuspendLayout();

            this.lblTitre.Text = "Liste du personnel";
            this.lblTitre.Font = new Font("Arial", 13F, FontStyle.Bold);
            this.lblTitre.Location = new Point(12, 15);
            this.lblTitre.AutoSize = true;

            this.dgvPersonnel.Location = new Point(12, 50);
            this.dgvPersonnel.Size = new Size(760, 300);
            this.dgvPersonnel.ReadOnly = true;
            this.dgvPersonnel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonnel.MultiSelect = false;
            this.dgvPersonnel.AllowUserToAddRows = false;

            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Location = new Point(12, 365);
            this.btnAjouter.Size = new Size(110, 32);
            this.btnAjouter.Click += new EventHandler(btnAjouter_Click);

            this.btnModifier.Text = "Modifier";
            this.btnModifier.Location = new Point(132, 365);
            this.btnModifier.Size = new Size(110, 32);
            this.btnModifier.Click += new EventHandler(btnModifier_Click);

            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Location = new Point(252, 365);
            this.btnSupprimer.Size = new Size(110, 32);
            this.btnSupprimer.Click += new EventHandler(btnSupprimer_Click);

            this.btnAbsences.Text = "Voir les absences";
            this.btnAbsences.Location = new Point(620, 365);
            this.btnAbsences.Size = new Size(152, 32);
            this.btnAbsences.Click += new EventHandler(btnAbsences_Click);

            this.Text = "MediaTek86 - Gestion du personnel";
            this.ClientSize = new Size(784, 415);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.dgvPersonnel);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnAbsences);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FrmSaisiePersonnel frm = new FrmSaisiePersonnel(controleur, this);
            frm.ShowDialog();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvPersonnel.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sélectionnez un personnel.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Personnel p = (Personnel)dgvPersonnel.SelectedRows[0].DataBoundItem;
            FrmSaisiePersonnel frm = new FrmSaisiePersonnel(controleur, this, p);
            frm.ShowDialog();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvPersonnel.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sélectionnez un personnel.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Personnel p = (Personnel)dgvPersonnel.SelectedRows[0].DataBoundItem;
            DialogResult rep = MessageBox.Show("Supprimer " + p.Prenom + " " + p.Nom + " et toutes ses absences ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rep == DialogResult.Yes)
            {
                controleur.SupprimerPersonnel(p.Idpersonnel);
                ActualiserListe();
            }
        }

        private void btnAbsences_Click(object sender, EventArgs e)
        {
            if (dgvPersonnel.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sélectionnez un personnel.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Personnel p = (Personnel)dgvPersonnel.SelectedRows[0].DataBoundItem;
            FrmListeAbsences frm = new FrmListeAbsences(controleur, p);
            frm.ShowDialog();
        }
    }
}
