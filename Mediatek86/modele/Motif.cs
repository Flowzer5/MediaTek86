namespace Mediatek86.modele
{
    /// <summary>
    /// Classe métier représentant un motif d'absence.
    /// </summary>
    public class Motif
    {
        /// <summary>
        /// Identifiant du motif (lecture seule).
        /// </summary>
        public int Idmotif { get; }

        /// <summary>
        /// Libellé du motif (lecture seule).
        /// </summary>
        public string Libelle { get; }

        /// <summary>
        /// Initialise une instance de Motif.
        /// </summary>
        /// <param name="idmotif">Identifiant du motif.</param>
        /// <param name="libelle">Libellé du motif.</param>
        public Motif(int idmotif, string libelle)
        {
            this.Idmotif = idmotif;
            this.Libelle = libelle;
        }

        /// <summary>
        /// Retourne le libellé du motif (utilisé dans les ComboBox).
        /// </summary>
        /// <returns>Libellé du motif.</returns>
        public override string ToString()
        {
            return this.Libelle;
        }
    }
}
