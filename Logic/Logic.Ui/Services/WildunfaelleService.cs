using System;
using System.Collections.Generic;
using System.Linq;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    public class WildunfaelleService
    {
        /// <summary>
        /// Liste Tiere wird erstellt und sortiert
        /// </summary>
        /// <returns></returns>
        public List<tbl_Tiere> Tiere()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {

                var liste = ctx.tbl_Tiere.ToList();
                liste = liste.OrderBy(x => x.Tierart).ToList();
                liste = liste.Where(x => x.Tierart != "--Alle Tiere--").ToList();
                return liste;
            }

        }


        public int DatumID;
        public int TierartID;
        public DateTime Time;
        public int JaegerID;
        /// <summary>
        ///      Erstellt ein Termin zum Wildunfall und ids werden abgefragt
        /// </summary>
        /// <param name="date"></param>
        /// <param name="id"></param>
        /// <param name="ort"></param>
        /// <returns></returns>
        public bool Tierhinzufuegen(DateTime date, int id, string ort)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                Time = date;
                try
                {
                    tbl_Termine itbl_Termine = new tbl_Termine
                    {
                        Ort = ort,
                        DatumUhrzeit = date,

                        Bezeichnung = "Wildunfall",
                        Typ = "Unfall"
                    };
                    ctx.tbl_Termine.Add(itbl_Termine);
                    ctx.SaveChanges();



                    var indexName = from a in ctx.tbl_Jaeger
                                    where a.Vorname == "Wildunfall"
                                    select new { a.Jäger_ID };

                    if (indexName.Count() == 1)
                    {
                        foreach (var j in indexName)
                        {
                            JaegerID = j.Jäger_ID;
                        }

                    }

                    var indexTier = from a in ctx.tbl_Tiere
                                    where a.Tiere_ID == id
                                    select new { a.Tiere_ID };

                    if (indexTier.Count() == 1)
                    {
                        foreach (var j in indexTier)
                        {
                            TierartID = j.Tiere_ID;
                        }

                    }

                    var indexTermin = from a in ctx.tbl_Termine
                                      select new
                                      {
                                          Termine_ID = a.Termine_ID,
                                          Ort = a.Ort,
                                          DatumUhrzeit = a.DatumUhrzeit,
                                          Bezeichnung = a.Bezeichnung,
                                          Typ = a.Typ
                                      };

                    int ergebnis = indexTermin.Count();
                    DatumID = ergebnis;

                    return true;
                }

                catch (Exception ex)
                {

                    return false;
                    throw ex;
                }

            }

        }
        /// <summary>
        ///Ein Eintrag wir in der Tabelle Jagderfolge hinzugefügt. 
        /// </summary>
        /// <param name="jagd"></param>
        /// <returns></returns>
        public bool InsertJagdErfolge(tbl_Jagderfolge jagd)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())


            {
                try
                {
                    ctx.tbl_Jagderfolge.Add(jagd);
                    ctx.SaveChanges();
                    return true;

                }

                catch (Exception ex)
                {

                    return false;
                    throw ex;
                }

            }



        }

    }
}
