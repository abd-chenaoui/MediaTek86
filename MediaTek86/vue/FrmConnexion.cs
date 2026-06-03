using System;
using System.Drawing;
using System.Windows.Forms;
using MediaTek86.controleur;

namespace MediaTek86.vue
{
    public partial class FrmConnexion : Form
    {
        private Controleur controleur;

        private Label lblTitre;
        private Label lblLogin;
        private Label lblMdp;
        private TextBox txtLogin;
        private TextBox txtMdp;
        private Button btnConnexion;

        public FrmConnexion(Controleur controleur)
        {
            this.controleur = controleur;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitre = new Label();
            this.lblLogin = new Label();
            this.lblMdp = new Label();
            this.txtLogin = new TextBox();
            this.txtMdp = new TextBox();
            this.btnConnexion = new Button();
            this.SuspendLayout();

            // titre
            this.lblTitre.Text = "Connexion - MediaTek86";
            this.lblTitre.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.lblTitre.Location = new Point(45, 20);
            this.lblTitre.AutoSize = true;

            // champ login
            this.lblLogin.Text = "Login :";
            this.lblLogin.Location = new Point(30, 65);
            this.lblLogin.AutoSize = true;
            this.txtLogin.Location = new Point(30, 85);
            this.txtLogin.Size = new Size(220, 22);

            // champ mot de passe
            this.lblMdp.Text = "Mot de passe :";
            this.lblMdp.Location = new Point(30, 120);
            this.lblMdp.AutoSize = true;
            this.txtMdp.Location = new Point(30, 140);
            this.txtMdp.Size = new Size(220, 22);
            this.txtMdp.PasswordChar = '*';

            // bouton
            this.btnConnexion.Text = "Connexion";
            this.btnConnexion.Location = new Point(30, 185);
            this.btnConnexion.Size = new Size(220, 32);
            this.btnConnexion.Click += new EventHandler(btnConnexion_Click);

            // form
            this.Text = "MediaTek86";
            this.ClientSize = new Size(285, 245);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblMdp);
            this.Controls.Add(this.txtMdp);
            this.Controls.Add(this.btnConnexion);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() == "" || txtMdp.Text.Trim() == "")
            {
                MessageBox.Show("Remplissez tous les champs.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!controleur.VerifierIdentifiants(txtLogin.Text, txtMdp.Text))
            {
                MessageBox.Show("Login ou mot de passe incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMdp.Clear();
                txtMdp.Focus();
            }
        }
    }
}
