using System;
using System.Collections.Generic;

namespace Mediatek86.dal
{
    /// <summary>
    /// Classe d'accès aux données pour l'authentification du responsable.
    /// </summary>
    public class ResponsableAccess
    {
        /// <summary>
        /// Instance unique de l'accès aux données.
        /// </summary>
        private readonly Access access = null;

        /// <summary>
        /// Initialise l'accès aux données via le singleton Access.
        /// </summary>
        public ResponsableAccess()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Vérifie si le login et le mot de passe correspondent à un responsable enregistré.
        /// Le hachage SHA2-256 est effectué côté SQL.
        /// </summary>
        /// <param name="login">Login du responsable.</param>
        /// <param name="pwd">Mot de passe en clair (haché par la requête SQL).</param>
        /// <returns>true si les identifiants sont valides, false sinon.</returns>
        public bool ControleAuthentification(string login, string pwd)
        {
            if (access.Manager != null)
            {
                string req = "select * from responsable where login=@login and pwd=SHA2(@pwd, 256);";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@login", login },
                    { "@pwd", pwd }
                };
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req, parameters);
                    if (records != null)
                    {
                        return records.Count > 0;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return false;
        }
    }
}
