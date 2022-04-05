using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{

    public class TerminUebersichtService
    {
        /// <summary>
        /// Holt die entsprechenden Daten aus der Tabelle tbl_Termine und packt diese in eine Liste.
        /// </summary>
        /// <returns></returns>
        public List<tbl_Termine> TerminUebersicht()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var termine = from a in ctx.tbl_Termine
                              where a.Bezeichnung != "Wildunfall" && a.DatumUhrzeit >= DateTime.Today
                              orderby a.DatumUhrzeit
                              select new { a.Termine_ID, a.Bezeichnung, a.Typ, a.Ort, a.DatumUhrzeit };
                var liste = new List<tbl_Termine>();

                foreach (var termin in termine)
                {
                    liste.Add(new tbl_Termine()
                    {
                        Termine_ID = termin.Termine_ID,
                        Bezeichnung = termin.Bezeichnung,
                        Typ = termin.Typ,
                        Ort = termin.Ort,
                        DatumUhrzeit = termin.DatumUhrzeit
                    });
                }
                return liste;
            }
        }
        /// <summary>
        /// Sucht den Datensatz durch den mitgegebenen Integer in der Datenbank um diesen dann zu löschen.
        /// </summary>
        /// <param name="terminID"></param>
        /// <returns></returns>
        /// TODO: Foreign Keys berücksichtigen.
        public bool TerminLoeschen(int terminID)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var post = from a in ctx.tbl_Postausgang
                           where a.Termine_ID == terminID
                           select new { a.Termine_ID };
                if (post.Count() > 0)
                {
                    return false;
                }
                else
                {
                    var termine = from a in ctx.tbl_Termine
                                  where a.Termine_ID == terminID
                                  select a;
                    ctx.tbl_Termine.RemoveRange(termine);
                    ctx.SaveChanges();
                    return true;
                }
            }
        }
        /// <summary>
        /// Sucht die eingeladenen Personen, die zu dem asugewählten Termin zugeordnet sind.
        /// </summary>
        /// <param name="terminID"></param>
        /// <returns></returns>
        public List<tbl_Jaeger> EingeladenePersonen(int terminID)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var personen = from a in ctx.tbl_Rueckmeldung
                               select new { a.Termine_ID, a.tbl_Jaeger.Vorname, a.tbl_Jaeger.Nachname };
                var liste = new List<tbl_Jaeger>();

                foreach (var item in personen)
                {
                    if (item.Termine_ID == terminID)
                    {
                        liste.Add(new tbl_Jaeger()
                        {
                            Vorname = item.Vorname,
                            Nachname = item.Nachname
                        });
                    }
                }
                return liste;
            }
        }
        /// <summary>
        /// Löscht alle Termine, die über ein Jahr alt sind.
        /// </summary>
        /// <returns></returns>
        /// TODO: Foreign Keys berücksichtigen.
        public IQueryable AutoDeleteTermin()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var termine = from a in ctx.tbl_Termine
                              where SqlFunctions.DateAdd("year", 1, a.DatumUhrzeit) < SqlFunctions.GetDate()
                              select a;
                foreach (var del in termine)
                {
                    ctx.tbl_Termine.Remove(del);
                }
                ctx.SaveChanges();
                return termine;
            }
        }
    }
}
