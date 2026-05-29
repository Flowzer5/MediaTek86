using Mediatek86.dal;
using Mediatek86.modele;
using System;
using System.Collections.Generic;

namespace Mediatek86.controleur
{
    /// <summary>
    /// Contrôleur du formulaire de gestion des absences : délègue les opérations à la couche DAL.
    /// </summary>
    public class FrmAbsencesController
    {
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
        public FrmAbsencesController()
        {
            absenceAccess = new AbsenceAccess();
            motifAccess   = new MotifAccess();
        }

        /// <summary>
        /// Retourne les absences d'un membre du personnel, triées par date décroissante.
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

        /// <summary>
        /// Ajoute une nouvelle absence en base de données.
        /// </summary>
        /// <param name="absence">Objet Absence à insérer.</param>
        public void AjouterAbsence(Absence absence)
        {
            absenceAccess.AjouterAbsence(absence);
        }

        /// <summary>
        /// Met à jour une absence existante en utilisant l'ancienne date de début comme clé.
        /// </summary>
        /// <param name="absence">Objet Absence avec les nouvelles valeurs.</param>
        /// <param name="ancienneDateDebut">Date de début originale servant de clé de recherche.</param>
        public void ModifierAbsence(Absence absence, DateTime ancienneDateDebut)
        {
            absenceAccess.ModifierAbsence(absence, ancienneDateDebut);
        }

        /// <summary>
        /// Supprime une absence de la base de données.
        /// </summary>
        /// <param name="absence">Objet Absence à supprimer.</param>
        public void SupprimerAbsence(Absence absence)
        {
            absenceAccess.SupprimerAbsence(absence);
        }
    }
}
