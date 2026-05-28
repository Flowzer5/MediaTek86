using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Mediatek86.bddmanager
{
    /// <summary>
    /// Singleton : connexion à la base de données et exécution des requêtes.
    /// </summary>
    public class BddManager
    {
        /// <summary>
        /// Instance unique de la classe.
        /// </summary>
        private static BddManager instance = null;

        /// <summary>
        /// Objet de connexion à la base de données.
        /// </summary>
        private readonly MySqlConnection connection;

        /// <summary>
        /// Constructeur privé : crée et ouvre la connexion MySQL.
        /// </summary>
        /// <param name="stringConnect">Chaîne de connexion à la base de données.</param>
        private BddManager(string stringConnect)
        {
            connection = new MySqlConnection(stringConnect);
            connection.Open();
        }

        /// <summary>
        /// Retourne l'instance unique de BddManager, en la créant si nécessaire.
        /// </summary>
        /// <param name="stringConnect">Chaîne de connexion à la base de données.</param>
        /// <returns>Instance unique de BddManager.</returns>
        public static BddManager GetInstance(string stringConnect)
        {
            if (instance == null)
            {
                instance = new BddManager(stringConnect);
            }
            return instance;
        }

        /// <summary>
        /// Exécute une requête LCT (begin transaction, commit, rollback).
        /// </summary>
        /// <param name="stringQuery">Requête LCT à exécuter.</param>
        public void ReqControle(string stringQuery)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Exécute une requête LMD (insert, update, delete).
        /// </summary>
        /// <param name="stringQuery">Requête LMD à exécuter.</param>
        /// <param name="parameters">Dictionnaire des paramètres (@clé / valeur). Peut être null.</param>
        public void ReqUpdate(string stringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);
            if (!(parameters is null))
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            command.Prepare();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Exécute une requête LIT (select) et retourne les lignes résultantes.
        /// </summary>
        /// <param name="stringQuery">Requête SELECT à exécuter.</param>
        /// <param name="parameters">Dictionnaire des paramètres (@clé / valeur). Peut être null.</param>
        /// <returns>Liste de tableaux d'objets ; chaque tableau représente une ligne résultat.</returns>
        public List<Object[]> ReqSelect(string stringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);
            if (!(parameters is null))
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();
            int nbCols = reader.FieldCount;
            List<Object[]> records = new List<Object[]>();
            while (reader.Read())
            {
                Object[] attributs = new Object[nbCols];
                reader.GetValues(attributs);
                records.Add(attributs);
            }
            reader.Close();
            return records;
        }
    }
}
