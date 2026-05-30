using Mediatek86.controleur;
using Mediatek86.modele;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mediatek86.vue
{
    /// <summary>
    /// Formulaire de gestion des absences d'un membre du personnel.
    /// </summary>
    public partial class FrmAbsences : Form
    {
        /// <summary>
        /// Contrôleur associé au formulaire.
        /// </summary>
        private readonly FrmAbsencesController controller = new FrmAbsencesController();

        /// <summary>
        /// Membre du personnel dont on gère les absences.
        /// </summary>
        private readonly Personnel personnel;

        /// <summary>
        /// Liste en mémoire des absences du personnel.
        /// </summary>
        private List<Absence> lesAbsences;

        /// <summary>
        /// Liste en mémoire des motifs d'absence.
        /// </summary>
        private List<Motif> lesMotifs;

        /// <summary>
        /// Source de données liée au DataGridView.
        /// </summary>
        private readonly BindingSource bindingSourceAbsence = new BindingSource();

        /// <summary>
        /// États possibles du formulaire.
        /// </summary>
        private enum Etat { Consultation, Ajout, Modification }

        /// <summary>
        /// État courant du formulaire.
        /// </summary>
        private Etat etatActuel = Etat.Consultation;

        /// <summary>
        /// Absence sélectionnée au moment du clic sur Modifier.
        /// </summary>
        private Absence absenceEnCours = null;

        /// <summary>
        /// Date de début originale de l'absence en cours de modification (clé primaire composite).
        /// </summary>
        private DateTime ancienneDateDebut;

        /// <summary>
        /// Initialise le formulaire pour le personnel donné, configure la grille et câble les événements.
        /// </summary>
        /// <param name="personnel">Membre du personnel dont on gère les absences.</param>
        public FrmAbsences(Personnel personnel)
        {
            InitializeComponent();
            this.personnel = personnel;
            InitialiserColonnesGrille();
            this.Load               += new EventHandler(FrmAbsences_Load);
            this.btnAjouter.Click   += new EventHandler(BtnAjouter_Click);
            this.btnModifier.Click  += new EventHandler(BtnModifier_Click);
            this.btnSupprimer.Click += new EventHandler(BtnSupprimer_Click);
            this.btnEnregistrer.Click += new EventHandler(BtnEnregistrer_Click);
            this.btnAnnuler.Click   += new EventHandler(BtnAnnuler_Click);
            this.btnFermer.Click    += new EventHandler(BtnFermer_Click);
        }

        /// <summary>
        /// Configure les colonnes du DataGridView avec AutoGenerateColumns désactivé.
        /// Les dates sont formatées en dd/MM/yyyy. La colonne Motif utilise Motif.ToString() (= libellé).
        /// </summary>
        private void InitialiserColonnesGrille()
        {
            dgvAbsences.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colDateDebut = new DataGridViewTextBoxColumn
            {
                Name = "colDateDebut",
                HeaderText = "Date début",
                DataPropertyName = "DateDebut"
            };
            colDateDebut.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvAbsences.Columns.Add(colDateDebut);

            DataGridViewTextBoxColumn colDateFin = new DataGridViewTextBoxColumn
            {
                Name = "colDateFin",
                HeaderText = "Date fin",
                DataPropertyName = "DateFin"
            };
            colDateFin.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvAbsences.Columns.Add(colDateFin);

            dgvAbsences.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMotif",
                HeaderText = "Motif",
                DataPropertyName = "Motif"
            });
        }

        // ─── Chargement ──────────────────────────────────────────────────────────

        /// <summary>
        /// Initialise le titre, remplit les listes et place le formulaire en mode consultation.
        /// </summary>
        /// <param name="sender">Source de l'événement.</param>
        /// <param name="e">Données de l'événement.</param>
        private void FrmAbsences_Load(object sender, EventArgs e)
        {
            this.Text          = "Gestion des absences - " + personnel.ToString();
            lblPersonnel.Text  = personnel.ToString();
            RemplirComboMotifs();
            RafraichirLesAbsences();
            ChangerEtat(Etat.Consultation);
        }

        // ─── Méthodes utilitaires ────────────────────────────────────────────────

        /// <summary>
        /// Remplit la ComboBox des motifs depuis la base de données.
        /// </summary>
        private void RemplirComboMotifs()
        {
            lesMotifs = controller.GetLesMotifs();
            cboMotif.DataSource    = lesMotifs;
            cboMotif.DisplayMember = "Libelle";
            cboMotif.ValueMember   = "Idmotif";
        }

        /// <summary>
        /// Recharge et affiche les absences du personnel dans le DataGridView.
        /// </summary>
        private void RafraichirLesAbsences()
        {
            lesAbsences = controller.GetLesAbsences(personnel.Idpersonnel);
            bindingSourceAbsence.DataSource = lesAbsences;
            dgvAbsences.DataSource = bindingSourceAbsence;
        }

        /// <summary>
        /// Applique un état au formulaire : active ou désactive les zones de saisie et les boutons.
        /// </summary>
        /// <param name="nouvelEtat">Nouvel état à appliquer.</param>
        private void ChangerEtat(Etat nouvelEtat)
        {
            etatActuel = nouvelEtat;
            bool enSaisie = (nouvelEtat == Etat.Ajout || nouvelEtat == Etat.Modification);

            grpAbsence.Enabled      = enSaisie;
            btnEnregistrer.Enabled  = enSaisie;
            btnAnnuler.Enabled      = enSaisie;

            dgvAbsences.Enabled     = !enSaisie;
            btnAjouter.Enabled      = !enSaisie;
            btnModifier.Enabled     = !enSaisie;
            btnSupprimer.Enabled    = !enSaisie;
        }

        /// <summary>
        /// Remplit les zones de saisie avec les données de l'absence donnée.
        /// </summary>
        /// <param name="absence">Absence dont les données sont affichées.</param>
        private void RemplirZonesSaisie(Absence absence)
        {
            dtpDateDebut.Value       = absence.DateDebut;
            dtpDateFin.Value         = absence.DateFin;
            cboMotif.SelectedValue   = absence.Motif.Idmotif;
        }

        /// <summary>
        /// Vide les zones de saisie et réinitialise les DateTimePickers à la date du jour.
        /// </summary>
        private void ViderZonesSaisie()
        {
            dtpDateDebut.Value       = DateTime.Today;
            dtpDateFin.Value         = DateTime.Today;
            cboMotif.SelectedIndex   = -1;
        }

        /// <summary>
        /// Construit un objet Absence à partir des saisies actuelles du formulaire.
        /// </summary>
        /// <returns>Objet Absence construit depuis les zones de saisie.</returns>
        private Absence AbsenceDepuisZonesSaisie()
        {
            Motif motif = cboMotif.SelectedItem as Motif;
            return new Absence(personnel.Idpersonnel, dtpDateDebut.Value.Date, dtpDateFin.Value.Date, motif);
        }

        /// <summary>
        /// Vérifie si l'intervalle [debut, fin] chevauche une absence existante.
        /// En mode modification, l'absence dont la date de début est ancienneDateDebutAExclure est ignorée.
        /// </summary>
        /// <param name="debut">Date de début à vérifier.</param>
        /// <param name="fin">Date de fin à vérifier.</param>
        /// <param name="ancienneDateDebutAExclure">Date de début de l'absence en cours d'édition (null en mode ajout).</param>
        /// <returns>true si un chevauchement est détecté, false sinon.</returns>
        private bool EstChevauchante(DateTime debut, DateTime fin, DateTime? ancienneDateDebutAExclure = null)
        {
            foreach (Absence absence in lesAbsences)
            {
                if (ancienneDateDebutAExclure.HasValue &&
                    absence.DateDebut.Date == ancienneDateDebutAExclure.Value.Date)
                {
                    continue;
                }
                if (debut.Date <= absence.DateFin.Date && fin.Date >= absence.DateDebut.Date)
                {
                    return true;
                }
            }
            return false;
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
        /// Bascule en mode Modification : prérempli les zones avec l'absence sélectionnée.
        /// Mémorise l'ancienne date de début pour la mise à jour de la clé primaire composite.
        /// </summary>
        /// <param name="sender">Source de l'événement.</param>
        /// <param name="e">Données de l'événement.</param>
        private void BtnModifier_Click(object sender, EventArgs e)
        {
            absenceEnCours = bindingSourceAbsence.Current as Absence;
            if (absenceEnCours == null)
            {
                MessageBox.Show("Sélectionnez une absence.", "Information");
                return;
            }
            ancienneDateDebut = absenceEnCours.DateDebut;
            RemplirZonesSaisie(absenceEnCours);
            ChangerEtat(Etat.Modification);
        }

        /// <summary>
        /// Supprime l'absence sélectionnée après confirmation de l'utilisateur.
        /// </summary>
        /// <param name="sender">Source de l'événement.</param>
        /// <param name="e">Données de l'événement.</param>
        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            Absence absence = bindingSourceAbsence.Current as Absence;
            if (absence == null)
            {
                MessageBox.Show("Sélectionnez une absence.", "Information");
                return;
            }
            if (MessageBox.Show("Confirmer la suppression de l'absence du " +
                    absence.DateDebut.ToString("dd/MM/yyyy") + " ?",
                    "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                controller.SupprimerAbsence(absence);
                RafraichirLesAbsences();
            }
        }

        /// <summary>
        /// Valide et enregistre l'ajout ou la modification de l'absence.
        /// Contrôle la cohérence des dates et l'absence de chevauchement.
        /// </summary>
        /// <param name="sender">Source de l'événement.</param>
        /// <param name="e">Données de l'événement.</param>
        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (cboMotif.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un motif.", "Information");
                return;
            }
            if (dtpDateFin.Value.Date < dtpDateDebut.Value.Date)
            {
                MessageBox.Show("La date de fin doit être supérieure ou égale à la date de début.", "Information");
                return;
            }
            if (etatActuel == Etat.Ajout)
            {
                if (EstChevauchante(dtpDateDebut.Value, dtpDateFin.Value))
                {
                    MessageBox.Show("Une absence est déjà programmée dans ce créneau.", "Information");
                    return;
                }
                controller.AjouterAbsence(AbsenceDepuisZonesSaisie());
            }
            else if (etatActuel == Etat.Modification)
            {
                if (EstChevauchante(dtpDateDebut.Value, dtpDateFin.Value, ancienneDateDebut))
                {
                    MessageBox.Show("Une absence est déjà programmée dans ce créneau.", "Information");
                    return;
                }
                controller.ModifierAbsence(AbsenceDepuisZonesSaisie(), ancienneDateDebut);
            }
            RafraichirLesAbsences();
            ChangerEtat(Etat.Consultation);
        }

        /// <summary>
        /// Annule l'opération en cours et retourne en mode consultation.
        /// </summary>
        /// <param name="sender">Source de l'événement.</param>
        /// <param name="e">Données de l'événement.</param>
        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            ChangerEtat(Etat.Consultation);
        }

        /// <summary>
        /// Ferme le formulaire de gestion des absences.
        /// </summary>
        /// <param name="sender">Source de l'événement.</param>
        /// <param name="e">Données de l'événement.</param>
        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
