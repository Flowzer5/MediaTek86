using System;

namespace Mediatek86.modele
{
    /// <summary>
    /// Classe métier représentant une absence d'un membre du personnel.
    /// </summary>
    public class Absence
    {
        /// <summary>
        /// Identifiant du personnel concerné (lecture seule).
        /// </summary>
        public int Idpersonnel { get; }

        /// <summary>
        /// Date de début de l'absence.
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin de l'absence.
        /// </summary>
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Motif de l'absence.
        /// </summary>
        public Motif Motif { get; set; }

        /// <summary>
        /// Initialise une instance d'Absence.
        /// </summary>
        /// <param name="idpersonnel">Identifiant du personnel concerné.</param>
        /// <param name="dateDebut">Date de début de l'absence.</param>
        /// <param name="dateFin">Date de fin de l'absence.</param>
        /// <param name="motif">Motif de l'absence.</param>
        public Absence(int idpersonnel, DateTime dateDebut, DateTime dateFin, Motif motif)
        {
            this.Idpersonnel = idpersonnel;
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.Motif = motif;
        }
    }
}
