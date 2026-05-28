using Mediatek86.bddmanager;
using System;
using System.Configuration;

namespace Mediatek86.dal
{
    /// <summary>
    /// Singleton : classe intermédiaire d'accès à BddManager.
    /// Lit la chaîne de connexion dans App.config et instancie BddManager.
    /// </summary>
    public class Access
    {
        /// <summary>
        /// Nom de la clé de connexion dans App.config.
        /// </summary>
        private static readonly string connectionName = "bdmediatek86ConnectionString";

        /// <summary>
        /// Instance unique de la classe.
        /// </summary>
        private static Access instance = null;

        /// <summary>
        /// Accès à l'objet de gestion de la base de données.
        /// </summary>
        public BddManager Manager { get; }

        /// <summary>
        /// Constructeur privé : récupère la chaîne de connexion depuis App.config
        /// et instancie BddManager. Arrête le programme en cas d'échec.
        /// </summary>
        private Access()
        {
            string connectionString = null;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                Manager = BddManager.GetInstance(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Retourne l'instance unique d'Access, en la créant si nécessaire.
        /// </summary>
        /// <returns>Instance unique d'Access.</returns>
        public static Access GetInstance()
        {
            if (instance == null)
            {
                instance = new Access();
            }
            return instance;
        }
    }
}
