using System;
using System.Windows.Forms;
using Mediatek86.controleur;

namespace Mediatek86.vue
{
    /// <summary>
    /// Formulaire de connexion : authentification du responsable par login et mot de passe.
    /// </summary>
    public partial class FrmConnexion : Form
    {
        /// <summary>
        /// Contrôleur associé au formulaire de connexion.
        /// </summary>
        private FrmConnexionController controller;

        /// <summary>
        /// Initialise le formulaire, le contrôleur et câble les événements des boutons.
        /// </summary>
        public FrmConnexion()
        {
            InitializeComponent();
            controller = new FrmConnexionController();
            this.btnConnecter.Click += new EventHandler(this.BtnConnecter_Click);
            this.btnAnnuler.Click += new EventHandler(this.BtnAnnuler_Click);
        }

        /// <summary>
        /// Récupère les saisies, contrôle les champs et lance l'authentification.
        /// Ouvre FrmGestion si les identifiants sont valides.
        /// </summary>
        /// <param name="sender">Source de l'événement.</param>
        /// <param name="e">Données de l'événement.</param>
        private void BtnConnecter_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string pwd = txtPwd.Text;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Information");
                return;
            }
            if (controller.ControleAuthentification(login, pwd))
            {
                this.Hide();
                new FrmGestion().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect.", "Alerte");
            }
        }

        /// <summary>
        /// Ferme l'application lorsque le bouton Annuler est cliqué.
        /// </summary>
        /// <param name="sender">Source de l'événement.</param>
        /// <param name="e">Données de l'événement.</param>
        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
