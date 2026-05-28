namespace Mediatek86.modele
{
    /// <summary>
    /// Classe métier représentant un membre du personnel de la médiathèque.
    /// </summary>
    public class Personnel
    {
        /// <summary>
        /// Identifiant du membre du personnel (lecture seule).
        /// </summary>
        public int Idpersonnel { get; }

        /// <summary>
        /// Nom du membre du personnel.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom du membre du personnel.
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Numéro de téléphone.
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Adresse e-mail.
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Service auquel appartient le membre du personnel.
        /// </summary>
        public Service Service { get; set; }

        /// <summary>
        /// Initialise une instance de Personnel.
        /// </summary>
        /// <param name="idpersonnel">Identifiant du personnel.</param>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prénom.</param>
        /// <param name="tel">Numéro de téléphone.</param>
        /// <param name="mail">Adresse e-mail.</param>
        /// <param name="service">Service associé.</param>
        public Personnel(int idpersonnel, string nom, string prenom, string tel, string mail, Service service)
        {
            this.Idpersonnel = idpersonnel;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Tel = tel;
            this.Mail = mail;
            this.Service = service;
        }

        /// <summary>
        /// Retourne le nom et le prénom du membre du personnel.
        /// </summary>
        /// <returns>Nom et prénom concaténés.</returns>
        public override string ToString()
        {
            return this.Nom + " " + this.Prenom;
        }
    }
}
