using System;
using System.Collections.Generic;
using System.Linq;



namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    class JaegerBearbeitenService
    {
        /// <summary>
        /// Holt alle Jägerbezogenen Daten aus der DB, außer ID10=Wildunfall, speichert in eine Liste und weist zu.
        /// </summary>
        /// <returns></returns>
        public List<tbl_Jaeger> GetJaegerInfoList()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var jaegerInfos = from abfrage in ctx.tbl_Jaeger
                                  where abfrage.Jäger_ID != 10
                                  orderby abfrage.Vorname
                                  select new
                                  {
                                      abfrage.Jäger_ID,
                                      abfrage.Vorname,
                                      abfrage.Nachname,
                                      abfrage.Anrede,
                                      abfrage.Straße,
                                      abfrage.Hausnummer,
                                      abfrage.Adresszusatz,
                                      abfrage.Postleitzahl,
                                      abfrage.Wohnort,
                                      abfrage.Telefonnummer1,
                                      abfrage.Telefonnummer2,
                                      abfrage.Telefonnummer3,
                                      abfrage.Email,
                                      abfrage.Geburtsdatum,
                                      abfrage.Funktion,
                                      abfrage.Jagdhund

                                  };
                List<tbl_Jaeger> liste = new List<tbl_Jaeger>();
                foreach (var item in jaegerInfos)
                {
                    liste.Add(new tbl_Jaeger()
                    {
                        Jäger_ID = item.Jäger_ID,
                        Vorname = item.Vorname,
                        Nachname = item.Nachname,
                        Anrede = item.Anrede,
                        Straße = item.Straße,
                        Hausnummer = item.Hausnummer,
                        Adresszusatz = item.Adresszusatz,
                        Postleitzahl = item.Postleitzahl,
                        Wohnort = item.Wohnort,
                        Funktion = item.Funktion,
                        Telefonnummer1 = item.Telefonnummer1,
                        Telefonnummer2= item.Telefonnummer2,
                        Telefonnummer3= item.Telefonnummer3,
                        Email = item.Email,
                        Jagdhund = item.Jagdhund,
                        Geburtsdatum = item.Geburtsdatum
                    });
                }
                return liste;

            }

        }

        public bool OverwriteJaegerInfo(tbl_Jaeger neuerJaeger, int id)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var jaeger = from abfrage in ctx.tbl_Jaeger
                             where abfrage.Jäger_ID == id
                             select new
                             {
                                 abfrage.Jäger_ID,
                                 abfrage.Vorname,
                                 abfrage.Nachname,
                                 abfrage.Anrede,
                                 abfrage.Straße,
                                 abfrage.Hausnummer,
                                 abfrage.Adresszusatz,
                                 abfrage.Postleitzahl,
                                 abfrage.Wohnort,
                                 abfrage.Telefonnummer1,
                                 abfrage.Telefonnummer2,
                                 abfrage.Telefonnummer3,
                                 abfrage.Email,
                                 abfrage.Geburtsdatum,
                                 abfrage.Funktion,
                                 abfrage.Jagdhund

                             };
                try
                {
                    ctx.tbl_Jaeger.Add(neuerJaeger);
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

        public IQueryable DeleteJaeger (int id)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var jaeger = from abfrage in ctx.tbl_Jaeger
                             where abfrage.Jäger_ID == id
                             select abfrage;
                foreach ( tbl_Jaeger del in jaeger)
                {
                    ctx.tbl_Jaeger.Remove(del);
                }
                ctx.SaveChanges();

                return jaeger;
            }
        }

    }
}
