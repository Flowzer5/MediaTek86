using Mediatek86.modele;
using System;
using System.Collections.Generic;

namespace Mediatek86.dal
{
    /// <summary>
    /// Classe d'accès aux données pour la gestion du personnel.
    /// </summary>
    public class PersonnelAccess
    {
        /// <summary>
        /// Instance unique de l'accès aux données.
        /// </summary>
        private readonly Access access = null;

        /// <summary>
        /// Initialise l'accès aux données via le singleton Access.
        /// </summary>
        public PersonnelAccess()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Récupère et retourne la liste de tous les membres du personnel avec leur service,
        /// triés par nom puis prénom.
        /// </summary>
        /// <returns>Liste des objets Personnel.</returns>
        public List<Personnel> GetLesPersonnels()
        {
            List<Personnel> lesPersonnels = new List<Personnel>();
            if (access.Manager != null)
            {
                string req = "select p.idpersonnel, p.nom, p.prenom, p.tel, p.mail, s.idservice, s.nom as nomservice ";
                req += "from personnel p join service s on p.idservice = s.idservice ";
                req += "order by p.nom, p.prenom;";
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null)
                    {
                        foreach (Object[] record in records)
                        {
                            Service service = new Service((int)record[5], (string)record[6]);
                            Personnel personnel = new Personnel(
                                (int)record[0],
                                (string)record[1],
                                (string)record[2],
                                (string)record[3],
                                (string)record[4],
                                service);
                            lesPersonnels.Add(personnel);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return lesPersonnels;
        }

        /// <summary>
        /// Ajoute un nouveau membre du personnel en base de données.
        /// </summary>
        /// <param name="personnel">Objet Personnel à insérer.</param>
        public void AjouterPersonnel(Personnel personnel)
        {
            if (access.Manager != null)
            {
                string req = "insert into personnel (nom, prenom, tel, mail, idservice) ";
                req += "values (@nom, @prenom, @tel, @mail, @idservice);";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@nom",       personnel.Nom },
                    { "@prenom",    personnel.Prenom },
                    { "@tel",       personnel.Tel },
                    { "@mail",      personnel.Mail },
                    { "@idservice", personnel.Service.Idservice }
                };
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Met à jour les informations d'un membre du personnel existant.
        /// </summary>
        /// <param name="personnel">Objet Personnel avec les nouvelles valeurs.</param>
        public void ModifierPersonnel(Personnel personnel)
        {
            if (access.Manager != null)
            {
                string req = "update personnel set nom=@nom, prenom=@prenom, tel=@tel, mail=@mail, idservice=@idservice ";
                req += "where idpersonnel=@idpersonnel;";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@nom",          personnel.Nom },
                    { "@prenom",       personnel.Prenom },
                    { "@tel",          personnel.Tel },
                    { "@mail",         personnel.Mail },
                    { "@idservice",    personnel.Service.Idservice },
                    { "@idpersonnel",  personnel.Idpersonnel }
                };
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Supprime un membre du personnel ainsi que toutes ses absences (contrainte FK).
        /// Supprime d'abord les absences, puis le personnel.
        /// </summary>
        /// <param name="personnel">Objet Personnel à supprimer.</param>
        public void SupprimerPersonnel(Personnel personnel)
        {
            if (access.Manager != null)
            {
                string reqAbsences = "delete from absence where idpersonnel=@idpersonnel;";
                string reqPersonnel = "delete from personnel where idpersonnel=@idpersonnel;";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@idpersonnel", personnel.Idpersonnel }
                };
                try
                {
                    access.Manager.ReqUpdate(reqAbsences, parameters);
                    access.Manager.ReqUpdate(reqPersonnel, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}
