using Mediatek86.modele;
using System;
using System.Collections.Generic;

namespace Mediatek86.dal
{
    /// <summary>
    /// Classe d'accès aux données pour la gestion des absences du personnel.
    /// </summary>
    public class AbsenceAccess
    {
        /// <summary>
        /// Instance unique de l'accès aux données.
        /// </summary>
        private readonly Access access = null;

        /// <summary>
        /// Initialise l'accès aux données via le singleton Access.
        /// </summary>
        public AbsenceAccess()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Récupère et retourne les absences d'un membre du personnel, triées par date décroissante.
        /// </summary>
        /// <param name="idpersonnel">Identifiant du personnel concerné.</param>
        /// <returns>Liste des objets Absence.</returns>
        public List<Absence> GetLesAbsences(int idpersonnel)
        {
            List<Absence> lesAbsences = new List<Absence>();
            if (access.Manager != null)
            {
                string req = "select a.idpersonnel, a.datedebut, a.datefin, m.idmotif, m.libelle ";
                req += "from absence a join motif m on a.idmotif = m.idmotif ";
                req += "where a.idpersonnel = @idpersonnel ";
                req += "order by a.datedebut desc;";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@idpersonnel", idpersonnel }
                };
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req, parameters);
                    if (records != null)
                    {
                        foreach (Object[] record in records)
                        {
                            Motif motif = new Motif((int)record[3], (string)record[4]);
                            Absence absence = new Absence(
                                (int)record[0],
                                (DateTime)record[1],
                                (DateTime)record[2],
                                motif);
                            lesAbsences.Add(absence);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return lesAbsences;
        }

        /// <summary>
        /// Ajoute une nouvelle absence en base de données.
        /// </summary>
        /// <param name="absence">Objet Absence à insérer.</param>
        public void AjouterAbsence(Absence absence)
        {
            if (access.Manager != null)
            {
                string req = "insert into absence (idpersonnel, datedebut, datefin, idmotif) ";
                req += "values (@idpersonnel, @datedebut, @datefin, @idmotif);";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@idpersonnel", absence.Idpersonnel },
                    { "@datedebut",   absence.DateDebut },
                    { "@datefin",     absence.DateFin },
                    { "@idmotif",     absence.Motif.Idmotif }
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
        /// Met à jour une absence existante. Utilise l'ancienne date de début comme critère
        /// de recherche car la clé primaire est composite (idpersonnel, datedebut).
        /// </summary>
        /// <param name="absence">Objet Absence avec les nouvelles valeurs.</param>
        /// <param name="ancienneDateDebut">Date de début originale servant de clé de recherche.</param>
        public void ModifierAbsence(Absence absence, DateTime ancienneDateDebut)
        {
            if (access.Manager != null)
            {
                string req = "update absence set datedebut=@datedebut, datefin=@datefin, idmotif=@idmotif ";
                req += "where idpersonnel=@idpersonnel and datedebut=@ancienneDateDebut;";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@datedebut",          absence.DateDebut },
                    { "@datefin",            absence.DateFin },
                    { "@idmotif",            absence.Motif.Idmotif },
                    { "@idpersonnel",        absence.Idpersonnel },
                    { "@ancienneDateDebut",  ancienneDateDebut }
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
        /// Supprime une absence de la base de données.
        /// La clé primaire composite (idpersonnel, datedebut) est utilisée pour identifier la ligne.
        /// </summary>
        /// <param name="absence">Objet Absence à supprimer.</param>
        public void SupprimerAbsence(Absence absence)
        {
            if (access.Manager != null)
            {
                string req = "delete from absence where idpersonnel=@idpersonnel and datedebut=@datedebut;";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@idpersonnel", absence.Idpersonnel },
                    { "@datedebut",   absence.DateDebut }
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
    }
}
