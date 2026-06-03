using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MediaTek86.controleur;
using MediaTek86.modele;

namespace MediaTek86.vue
{
    public partial class FrmSaisieAbsence : Form
    {
        private Controleur controleur;
        private FrmListeAbsences frmParent;
        private Personnel personnel;

        private Label lblDebut, lblFin, lblMotif;
        private DateTimePicker dtpDebut, dtpFin;
        private ComboBox cbxMotif;
        private Button btnValider, btnAnnuler;

        public FrmSaisieAbsence(Controleur controleur, FrmListeAbsences parent, Personnel personnel)
        {
            this.controleur = controleur;
            this.frmParent = parent;
            this.personnel = personnel;
            InitializeComponent();
            ChargerMotifs();
        }

        private void ChargerMotifs()
        {
            List<Motif> motifs = controleur.GetLesMotifs();
            cbxMotif.DataSource = motifs;
        }

        private void InitializeComponent()
        {
            this.lblDebut = new Label();
            this.lblFin = new Label();
            this.lblMotif = new Label();
            this.dtpDebut = new DateTimePicker();
            this.dtpFin = new DateTimePicker();
            this.cbxMotif = new ComboBox();
            this.btnValider = new Button();
            this.btnAnnuler = new Button();
            this.SuspendLayout();

            this.lblDebut.Text = "Date début :"; this.lblDebut.Location = new Point(20, 25); this.lblDebut.AutoSize = true;
            this.dtpDebut.Location = new Point(130, 22); this.dtpDebut.Size = new Size(160, 22);
            this.dtpDebut.Format = DateTimePickerFormat.Short;

            this.lblFin.Text = "Date fin :"; this.lblFin.Location = new Point(20, 65); this.lblFin.AutoSize = true;
            this.dtpFin.Location = new Point(130, 62); this.dtpFin.Size = new Size(160, 22);
            this.dtpFin.Format = DateTimePickerFormat.Short;

            this.lblMotif.Text = "Motif :"; this.lblMotif.Location = new Point(20, 105); this.lblMotif.AutoSize = true;
            this.cbxMotif.Location = new Point(130, 102); this.cbxMotif.Size = new Size(160, 22);
            this.cbxMotif.DropDownStyle = ComboBoxStyle.DropDownList;

            this.btnValider.Text = "Enregistrer";
            this.btnValider.Location = new Point(70, 155);
            this.btnValider.Size = new Size(100, 30);
            this.btnValider.Click += new EventHandler(btnValider_Click);

            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.Location = new Point(180, 155);
            this.btnAnnuler.Size = new Size(100, 30);
            this.btnAnnuler.Click += new EventHandler(btnAnnuler_Click);

            this.Text = "Ajouter une absence";
            this.ClientSize = new Size(330, 215);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Controls.Add(lblDebut); this.Controls.Add(dtpDebut);
            this.Controls.Add(lblFin); this.Controls.Add(dtpFin);
            this.Controls.Add(lblMotif); this.Controls.Add(cbxMotif);
            this.Controls.Add(btnValider); this.Controls.Add(btnAnnuler);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            DateTime debut = dtpDebut.Value.Date;
            DateTime fin = dtpFin.Value.Date;

            if (cbxMotif.SelectedItem == null)
            {
                MessageBox.Show("Choisissez un motif.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fin < debut)
            {
                MessageBox.Show("La date de fin doit être après la date de début.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Motif motif = (Motif)cbxMotif.SelectedItem;
            Absence nouvelleAbsence = new Absence(personnel.Idpersonnel, debut, fin, motif.Idmotif, motif.Libelle);
            controleur.AjouterAbsence(nouvelleAbsence);

            frmParent.ChargerAbsences();
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
