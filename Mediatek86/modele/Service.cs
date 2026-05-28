namespace Mediatek86.modele
{
    /// <summary>
    /// Classe métier représentant un service de la médiathèque.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Identifiant du service (lecture seule).
        /// </summary>
        public int Idservice { get; }

        /// <summary>
        /// Nom du service (lecture seule).
        /// </summary>
        public string Nom { get; }

        /// <summary>
        /// Initialise une instance de Service.
        /// </summary>
        /// <param name="idservice">Identifiant du service.</param>
        /// <param name="nom">Nom du service.</param>
        public Service(int idservice, string nom)
        {
            this.Idservice = idservice;
            this.Nom = nom;
        }

        /// <summary>
        /// Retourne le nom du service (utilisé dans les ComboBox).
        /// </summary>
        /// <returns>Nom du service.</returns>
        public override string ToString()
        {
            return this.Nom;
        }
    }
}
