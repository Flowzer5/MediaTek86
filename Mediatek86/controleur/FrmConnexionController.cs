using Mediatek86.dal;

namespace Mediatek86.controleur
{
    /// <summary>
    /// Contrôleur du formulaire de connexion : délègue l'authentification à la couche DAL.
    /// </summary>
    public class FrmConnexionController
    {
        /// <summary>
        /// Objet d'accès aux opérations sur le responsable.
        /// </summary>
        private readonly ResponsableAccess responsableAccess;

        /// <summary>
        /// Initialise le contrôleur et instancie l'accès aux données.
        /// </summary>
        public FrmConnexionController()
        {
            responsableAccess = new ResponsableAccess();
        }

        /// <summary>
        /// Vérifie les identifiants du responsable auprès de la base de données.
        /// </summary>
        /// <param name="login">Login saisi dans le formulaire.</param>
        /// <param name="pwd">Mot de passe saisi dans le formulaire.</param>
        /// <returns>true si l'authentification réussit, false sinon.</returns>
        public bool ControleAuthentification(string login, string pwd)
        {
            return responsableAccess.ControleAuthentification(login, pwd);
        }
    }
}
