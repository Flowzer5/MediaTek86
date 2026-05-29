using Mediatek86.dal;
using Mediatek86.modele;
using System;
using System.Collections.Generic;

namespace Mediatek86.controleur
{
    /// <summary>
    /// Contrôleur du formulaire de gestion du personnel : délègue les opérations à la couche DAL.
    /// </summary>
    public class FrmGestionController
    {
        /// <summary>
        /// Accès aux données du personnel.
        /// </summary>
        private readonly PersonnelAccess personnelAccess;

        /// <summary>
        /// Accès aux données des services.
        /// </summary>
        private readonly ServiceAccess serviceAccess;

        /// <summary>
        /// Accès aux données des absences.
        /// </summary>
        private readonly AbsenceAccess absenceAccess;

        /// <summary>
        /// Accès aux données des motifs d'absence.
        /// </summary>
        private readonly MotifAccess motifAccess;

        /// <summary>
        /// Initialise le contrôleur et instancie les accès aux données nécessaires.
        /// </summary>
        public FrmGestionController()
        {
            personnelAccess = new PersonnelAccess();
            serviceAccess   = new ServiceAccess();
            absenceAccess   = new AbsenceAccess();
            motifAccess     = new MotifAccess();
        }

        /// <summary>
        /// Retourne la liste de tous les membres du personnel.
        /// </summary>
        /// <returns>Liste des objets Personnel.</returns>
        public List<Personnel> GetLesPersonnels()
        {
            return personnelAccess.GetLesPersonnels();
        }

        /// <summary>
        /// Retourne la liste de tous les services.
        /// </summary>
        /// <returns>Liste des objets Service.</returns>
        public List<Service> GetLesServices()
        {
            return serviceAccess.GetLesServices();
        }

        /// <summary>
        /// Ajoute un nouveau membre du personnel en base de données.
        /// </summary>
        /// <param name="personnel">Objet Personnel à insérer.</param>
        public void AjouterPersonnel(Personnel personnel)
        {
            personnelAccess.AjouterPersonnel(personnel);
        }

        /// <summary>
        /// Met à jour les informations d'un membre du personnel existant.
        /// </summary>
        /// <param name="personnel">Objet Personnel avec les nouvelles valeurs.</param>
        public void ModifierPersonnel(Personnel personnel)
        {
            personnelAccess.ModifierPersonnel(personnel);
        }

        /// <summary>
        /// Supprime un membre du personnel et toutes ses absences.
        /// </summary>
        /// <param name="personnel">Objet Personnel à supprimer.</param>
        public void SupprimerPersonnel(Personnel personnel)
        {
            personnelAccess.SupprimerPersonnel(personnel);
        }

        /// <summary>
        /// Retourne les absences d'un membre du personnel, pour préparer l'ouverture de FrmAbsences.
        /// </summary>
        /// <param name="idpersonnel">Identifiant du personnel concerné.</param>
        /// <returns>Liste des objets Absence.</returns>
        public List<Absence> GetLesAbsences(int idpersonnel)
        {
            return absenceAccess.GetLesAbsences(idpersonnel);
        }

        /// <summary>
        /// Retourne la liste de tous les motifs d'absence.
        /// </summary>
        /// <returns>Liste des objets Motif.</returns>
        public List<Motif> GetLesMotifs()
        {
            return motifAccess.GetLesMotifs();
        }
    }
}
