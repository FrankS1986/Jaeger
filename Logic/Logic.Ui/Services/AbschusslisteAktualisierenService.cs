using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
   public class AbschusslisteAktualisierenService
    {
        List<int> listeID = new List<int>();
        /// <summary>
        /// Es wird eine Liste von Tieren erstellt die man dann in der combobox auswählen kann.
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
        


        
          /// <summary>
          /// Erstellt Liste mit Terminen die vom Typ Treibjagd sind
          /// </summary>
          /// <returns></returns>
        public List<tbl_Termine> Termine()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var termine = from a in ctx.tbl_Termine
                              where a.Typ == "Treibjagd"
                              select new {a.Termine_ID, a.Ort, a.DatumUhrzeit };
                var liste = new List<tbl_Termine>();

                foreach (var item in termine)
                {
                    liste.Add(new tbl_Termine()
                    {
                        Termine_ID = item.Termine_ID,
                        Ort = item.Ort,
                        DatumUhrzeit = item.DatumUhrzeit
                        

                    }) ;
                }

                return liste;
            }
        }

                /// <summary>
                /// Erzeugt eine Liste der Eingeladenen Jäger zum Termin
                /// </summary>
                /// <param name="jaegerID"></param>
                /// <returns></returns>
        public List<tbl_Jaeger> Jaeger(int jaegerID)
        {

            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var teilnahme = from a in ctx.tbl_Rueckmeldung
                              where a.Termine_ID == jaegerID
                              select new { a.Jäger_ID };
                
                var listeJaeger = new List<tbl_Jaeger>();
                if (teilnahme.Count() >= 1)
                {
                    foreach (var item in teilnahme)
                    {
                        var jaeger = from a in ctx.tbl_Jaeger
                                     where a.Jäger_ID == item.Jäger_ID
                                     select new {a.Jäger_ID, a.Vorname, a.Nachname };

                        foreach (var b in jaeger)
                        {
                            listeJaeger.Add(new tbl_Jaeger()
                            {   Jäger_ID = b.Jäger_ID,
                                Vorname = b.Vorname,
                                Nachname = b.Nachname
                            });
                        }

                    }

                }

                return listeJaeger;
            }
        }

            /// <summary>
            /// Speichert die Jagderfolge ab
            /// </summary>
            /// <param name="jagd"></param>
            /// <param name="abschuesse"></param>
            /// <returns></returns>

        public bool InsertJagdErfolge(tbl_Jagderfolge jagd, int abschuesse)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())


            {
                try
                {
                    for (int i = 0; i < abschuesse; i++)
                    {
                        ctx.tbl_Jagderfolge.Add(jagd);
                        ctx.SaveChanges();
                    }
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
