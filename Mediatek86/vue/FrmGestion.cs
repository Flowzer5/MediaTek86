using Mediatek86.controleur;
using Mediatek86.modele;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mediatek86.vue
{
    /// <summary>
    /// Formulaire principal de gestion du personnel : affichage, ajout, modification et suppression.
    /// </summary>
    public partial class FrmGestion : Form
    {
        /// <summary>
        /// Contrôleur associé au formulaire.
        /// </summary>
        private readonly FrmGestionController controller = new FrmGestionController();

        /// <summary>
        /// Liste en mémoire des membres du personnel.
        /// </summary>
        private List<Personnel> lesPersonnels;

        /// <summary>
        /// Liste en mémoire des services.
        /// </summary>
        private List<Service> lesServices;

        /// <summary>
        /// Source de données liée au DataGridView.
        /// </summary>
        private readonly BindingSource bindingSourcePersonnel = new BindingSource();

        /// <summary>
        /// États possibles du formulaire.
        /// </summary>
        private enum Etat { Consultation, Ajout, Modification }

        /// <summary>
        /// État courant du formulaire.
        /// </summary>
        private Etat etatActuel = Etat.Consultation;

        /// <summary>
        /// Personnel sélectionné au moment du clic sur Modifier.
        /// </summary>
        private Personnel personnelEnCours = null;

        /// <summary>
        /// Initialise le formulaire, configure les colonnes de la grille et câble les événements.
        /// </summary>
        public FrmGestion()
        {
            InitializeComponent();
            InitialiserColonnesGrille();
            this.Load                       += new EventHandler(FrmGestion_Load);
            this.btnAjouter.Click           += new EventHandler(BtnAjouter_Click);
            this.btnModifier.Click          += new EventHandler(BtnModifier_Click);
            this.btnSupprimer.Click         += new EventHandler(BtnSupprimer_Click);
            this.btnEnregistrer.Click       += new EventHandler(BtnEnregistrer_Click);
            this.btnAnnulerPersonnel.Click  += new EventHandler(BtnAnnulerPersonnel_Click);
            this.btnGererAbsences.Click     += new EventHandler(BtnGererAbsences_Click);
        }

        /// <summary>
        /// Configure les colonnes du DataGridView avec AutoGenerateColumns désactivé.
        /// La colonne Service affiche Service.ToString() (= le nom du service).
        /// </summary>
        private void InitialiserColonnesGrille()
        {
            dgvPersonnel.AutoGenerateColumns = false;
            dgvPersonnel.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNom",     HeaderText = "Nom",       DataPropertyName = "Nom" });
            dgvPersonnel.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPrenom",  HeaderText = "Prénom",    DataPropertyName = "Prenom" });
            dgvPersonnel.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTel",     HeaderText = "Téléphone", DataPropertyName = "Tel" });
            dgvPersonnel.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMail",    HeaderText = "Mail",      DataPropertyName = "Mail" });
            dgvPersonnel.Columns.Add(new DataGridViewTextBoxColumn { Name = "colService", HeaderText = "Service",   DataPropertyName = "Service" });
        }

        // ─── Chargement ──────────────────────────────────────────────────────────

        /// <summary>
        /// Charge les services et les personnels, puis place le formulaire en mode consultation.
        /// </summary>
        /// <param name="sender">Source de l'événement.</param>
        /// <param name="e">Données de l'événement.</param>
        private void FrmGestion_Load(object sender, EventArgs e)
        {
            RemplirComboServices();
            RafraichirLesPersonnels();
            ChangerEtat(Etat.Consultation);
        }

        // ─── Méthodes utilitaires ────────────────────────────────────────────────

        /// <summary>
        /// Remplit la ComboBox des services depuis la base de données.
        /// </summary>
        private void RemplirComboServices()
        {
            lesServices = controller.GetLesServices();
            cboService.DataSource    = lesServices;
            cboService.DisplayMember = "Nom";
            cboService.ValueMember   = "Idservice";
        }

        /// <summary>
        /// Recharge et affiche la liste des personnels dans le DataGridView.
        /// </summary>
        private void RafraichirLesPersonnels()
        {
            lesPersonnels = controller.GetLesPersonnels();
            bindingSourcePersonnel.DataSource = lesPersonnels;
            dgvPersonnel.DataSource = bindingSourcePersonnel;
        }

        /// <summary>
        /// Applique un état au formulaire : active ou désactive les zones de saisie et les boutons.
        /// </summary>
        /// <param name="nouvelEtat">Nouvel état à appliquer.</param>
        private void ChangerEtat(Etat nouvelEtat)
        {
            etatActuel = nouvelEtat;
            bool enSaisie = (nouvelEtat == Etat.Ajout || nouvelEtat == Etat.Modification);

            // Zones de saisie et boutons d'action sur le formulaire
            grpPersonnel.Enabled        = enSaisie;
            btnEnregistrer.Enabled      = enSaisie;
            btnAnnulerPersonnel.Enabled = enSaisie;

            // Grille et boutons de liste
            dgvPersonnel.Enabled        = !enSaisie;
            btnAjouter.Enabled          = !enSaisie;
            btnModifier.Enabled         = !enSaisie;
            btnSupprimer.Enabled        = !enSaisie;
            btnGererAbsences.Enabled    = !enSaisie;
        }

        /// <summary>
        /// Remplit les zones de saisie avec les données du personnel donné.
        /// </summary>
        /// <param name="personnel">Personnel dont les données sont affichées.</param>
        private void RemplirZonesSaisie(Personnel personnel)
        {
            txtNom.Text              = personnel.Nom;
            txtPrenom.Text           = personnel.Prenom;
            txtTel.Text              = personnel.Tel;
            txtMail.Text             = personnel.Mail;
            cboService.SelectedValue = personnel.Service.Idservice;
        }

        /// <summary>
        /// Vide toutes les zones de saisie du formulaire.
        /// </summary>
        private void ViderZonesSaisie()
        {
            txtNom.Text              = string.Empty;
            txtPrenom.Text           = string.Empty;
            txtTel.Text              = string.Empty;
            txtMail.Text             = string.Empty;
            cboService.SelectedIndex = -1;
        }

        /// <summary>
        /// Construit un objet Personnel à partir des saisies actuelles du formulaire.
        /// </summary>
        /// <param name="idpersonnel">Identifiant du personnel : 0 pour un ajout, valeur existante pour une modification.</param>
        /// <returns>Objet Personnel construit depuis les zones de saisie.</returns>
        private Personnel PersonnelDepuisZonesSaisie(int idpersonnel = 0)
        {
            Service service = cboService.SelectedItem as Service;
            return new Personnel(idpersonnel, txtNom.Text, txtPrenom.Text, txtTel.Text, txtMail.Text, service);
        }

        // ─── Handlers de boutons ─────────────────────────────────────────────────

        /// <summary>
        /// Bascule en mode Ajout : vide les zones de saisie et active le formulaire.
        /// </summary>
        /// <param name="sender">Source de l'événement.</param>
        /// <param name="e">Données de l'événement.</param>
        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            ViderZonesSaisie();
            ChangerEtat(Etat.Ajout);
        }

        /// <summary>
        /// Bascule en mode Modification : prérempli les zones avec le personnel sélectionné.
        /// </summary>
        /// <param name="sender">Source de l'événement.</param>
        /// <param name="e">Données de l'événement.</param>
        private void BtnModifier_Click(object sender, EventArgs e)
        {
            personnelEnCours = bindingSourcePersonnel.Current as Personnel;
            if (personnelEnCours == null)
            {
                MessageBox.Show("Sélectionnez un personnel.", "Information");
                return;
            }
            RemplirZonesSaisie(personnelEnCours);
            ChangerEtat(Etat.Modification);
        }

        /// <summary>
        /// Supprime le personnel sélectionné après confirmation de l'utilisateur.
        /// </summary>
        /// <param name="sender">Source de l'événement.</param>
        /// <param name="e">Données de l'événement.</param>
        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            Personnel personnel = bindingSourcePersonnel.Current as Personnel;
            if (personnel == null)
            {
                MessageBox.Show("Sélectionnez un personnel.", "Information");
                return;
            }
            if (MessageBox.Show("Confirmer la suppression de " + personnel + " ?",
                    "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                controller.SupprimerPersonnel(personnel);
                RafraichirLesPersonnels();
            }
        }

        /// <summary>
        /// Valide et enregistre l'ajout ou la modification du personnel.
        /// </summary>
        /// <param name="sender">Source de l'événement.</param>
        /// <param name="e">Données de l'événement.</param>
        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNom.Text) || string.IsNullOrEmpty(txtPrenom.Text) || cboService.SelectedItem == null)
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Information");
                return;
            }
            if (etatActuel == Etat.Ajout)
            {
                controller.AjouterPersonnel(PersonnelDepuisZonesSaisie());
            }
            else if (etatActuel == Etat.Modification)
            {
                controller.ModifierPersonnel(PersonnelDepuisZonesSaisie(personnelEnCours.Idpersonnel));
            }
            RafraichirLesPersonnels();
            ChangerEtat(Etat.Consultation);
        }

        /// <summary>
        /// Annule l'opération en cours et retourne en mode consultation.
        /// </summary>
        /// <param name="sender">Source de l'événement.</param>
        /// <param name="e">Données de l'événement.</param>
        private void BtnAnnulerPersonnel_Click(object sender, EventArgs e)
        {
            ChangerEtat(Etat.Consultation);
        }

        /// <summary>
        /// Ouvre le formulaire de gestion des absences pour le personnel sélectionné.
        /// (Placeholder : FrmAbsences sera mis à jour avec paramètre Personnel à l'étape suivante.)
        /// </summary>
        /// <param name="sender">Source de l'événement.</param>
        /// <param name="e">Données de l'événement.</param>
        private void BtnGererAbsences_Click(object sender, EventArgs e)
        {
            Personnel personnel = bindingSourcePersonnel.Current as Personnel;
            if (personnel == null)
            {
                MessageBox.Show("Sélectionnez un personnel.", "Information");
                return;
            }
            MessageBox.Show("Personnel sélectionné : " + personnel, "Information");
            new FrmAbsences().ShowDialog();
            RafraichirLesPersonnels();
        }
    }
}
