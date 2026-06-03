using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MediaTek86.controleur;
using MediaTek86.modele;

namespace MediaTek86.vue
{
    public partial class FrmSaisiePersonnel : Form
    {
        private Controleur controleur;
        private FrmPrincipal frmParent;
        private Personnel personnelAModifier = null;

        private Label lblNom, lblPrenom, lblTel, lblMail, lblService;
        private TextBox txtNom, txtPrenom, txtTel, txtMail;
        private ComboBox cbxService;
        private Button btnValider, btnAnnuler;

        // constructeur pour ajout
        public FrmSaisiePersonnel(Controleur controleur, FrmPrincipal parent)
        {
            this.controleur = controleur;
            this.frmParent = parent;
            InitializeComponent();
            ChargerServices();
        }

        // constructeur pour modification
        public FrmSaisiePersonnel(Controleur controleur, FrmPrincipal parent, Personnel p)
        {
            this.controleur = controleur;
            this.frmParent = parent;
            this.personnelAModifier = p;
            InitializeComponent();
            ChargerServices();
            RemplirChamps();
        }

        private void ChargerServices()
        {
            List<Service> services = controleur.GetLesServices();
            cbxService.DataSource = services;
        }

        private void RemplirChamps()
        {
            txtNom.Text = personnelAModifier.Nom;
            txtPrenom.Text = personnelAModifier.Prenom;
            txtTel.Text = personnelAModifier.Tel;
            txtMail.Text = personnelAModifier.Mail;
            foreach (Service s in cbxService.Items)
            {
                if (s.Idservice == personnelAModifier.Idservice)
                {
                    cbxService.SelectedItem = s;
                    break;
                }
            }
            this.Text = "Modifier un personnel";
            btnValider.Text = "Modifier";
        }

        private void InitializeComponent()
        {
            this.lblNom = new Label();
            this.lblPrenom = new Label();
            this.lblTel = new Label();
            this.lblMail = new Label();
            this.lblService = new Label();
            this.txtNom = new TextBox();
            this.txtPrenom = new TextBox();
            this.txtTel = new TextBox();
            this.txtMail = new TextBox();
            this.cbxService = new ComboBox();
            this.btnValider = new Button();
            this.btnAnnuler = new Button();
            this.SuspendLayout();

            this.lblNom.Text = "Nom :"; this.lblNom.Location = new Point(20, 25); this.lblNom.AutoSize = true;
            this.txtNom.Location = new Point(120, 22); this.txtNom.Size = new Size(210, 22);

            this.lblPrenom.Text = "Prénom :"; this.lblPrenom.Location = new Point(20, 65); this.lblPrenom.AutoSize = true;
            this.txtPrenom.Location = new Point(120, 62); this.txtPrenom.Size = new Size(210, 22);

            this.lblTel.Text = "Téléphone :"; this.lblTel.Location = new Point(20, 105); this.lblTel.AutoSize = true;
            this.txtTel.Location = new Point(120, 102); this.txtTel.Size = new Size(210, 22);

            this.lblMail.Text = "Mail :"; this.lblMail.Location = new Point(20, 145); this.lblMail.AutoSize = true;
            this.txtMail.Location = new Point(120, 142); this.txtMail.Size = new Size(210, 22);

            this.lblService.Text = "Service :"; this.lblService.Location = new Point(20, 185); this.lblService.AutoSize = true;
            this.cbxService.Location = new Point(120, 182); this.cbxService.Size = new Size(210, 22);
            this.cbxService.DropDownStyle = ComboBoxStyle.DropDownList;

            this.btnValider.Text = "Ajouter";
            this.btnValider.Location = new Point(120, 230);
            this.btnValider.Size = new Size(100, 30);
            this.btnValider.Click += new EventHandler(btnValider_Click);

            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.Location = new Point(230, 230);
            this.btnAnnuler.Size = new Size(100, 30);
            this.btnAnnuler.Click += new EventHandler(btnAnnuler_Click);

            this.Text = "Ajouter un personnel";
            this.ClientSize = new Size(370, 285);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Controls.Add(lblNom); this.Controls.Add(txtNom);
            this.Controls.Add(lblPrenom); this.Controls.Add(txtPrenom);
            this.Controls.Add(lblTel); this.Controls.Add(txtTel);
            this.Controls.Add(lblMail); this.Controls.Add(txtMail);
            this.Controls.Add(lblService); this.Controls.Add(cbxService);
            this.Controls.Add(btnValider); this.Controls.Add(btnAnnuler);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (txtNom.Text.Trim() == "" || txtPrenom.Text.Trim() == "" || txtTel.Text.Trim() == "" || txtMail.Text.Trim() == "" || cbxService.SelectedItem == null)
            {
                MessageBox.Show("Tous les champs sont obligatoires.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Service serviceSelectionne = (Service)cbxService.SelectedItem;

            if (personnelAModifier == null)
            {
                Personnel nouveau = new Personnel(0, txtNom.Text, txtPrenom.Text, txtTel.Text, txtMail.Text, serviceSelectionne.Idservice, serviceSelectionne.Nom);
                controleur.AjouterPersonnel(nouveau);
            }
            else
            {
                DialogResult rep = MessageBox.Show("Confirmer la modification ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rep == DialogResult.No) return;
                Personnel modif = new Personnel(personnelAModifier.Idpersonnel, txtNom.Text, txtPrenom.Text, txtTel.Text, txtMail.Text, serviceSelectionne.Idservice, serviceSelectionne.Nom);
                controleur.ModifierPersonnel(modif);
            }

            frmParent.ActualiserListe();
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
