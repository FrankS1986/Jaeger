using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    class TerminErstellenService
    {
        //<summary>
        //Nimmt die Vornamen und Nachname aus tbl_Jaeger und speichert diese in eine Liste.
        //</summary>
        public List<tbl_Jaeger> Personen()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var liste = from a in ctx.tbl_Jaeger
                            select new { a.Vorname, a.Nachname };
                var Personen = new List<tbl_Jaeger>();

                foreach (var item in liste)
                {
                    Personen.Add(new tbl_Jaeger()
                    { 
                        Vorname = item.Vorname,
                        Nachname = item.Nachname
                    });
                }
                return Personen;
            }
        }

        //<summary>
        //Nimmt die beiden Strings und führt diese in eine Liste hinzu.
        //</summary>
        public List<tbl_Jaeger> Einladung(string vorname, string nachname)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var liste = from a in ctx.tbl_Jaeger
                            where a.Vorname == vorname && a.Nachname == nachname
                            select new { a.Vorname, a.Nachname };
                var Einladungen = new List<tbl_Jaeger>();

                foreach (var item in liste)
                {
                    Einladungen.Add(new tbl_Jaeger()
                    {
                        Vorname = item.Vorname,
                        Nachname = item.Nachname
                    });
                }
                return Einladungen;
            }
        }

        //<summary>
        //Wenn ein Termin bearbeitet wird, wird dieser in der Datebank überschrieben. Ansonsten wird ein neuer Termin angelegt.
        //</summary>
        public IQueryable Termin(int id, string bezeichnung, string ort, string zeit, string typ, DateTime datum)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                if (id == 0)
                {
                    var liste = from a in ctx.tbl_Termine
                                select a;

                    string[] einheit = zeit.Split(':');
                    datum = datum.AddHours(Convert.ToDouble(einheit[0]));
                    datum = datum.AddMinutes(Convert.ToDouble(einheit[1]));
                    tbl_Termine termin = new tbl_Termine
                    {
                        Ort = ort,
                        DatumUhrzeit = datum,
                        Bezeichnung = bezeichnung,
                        Typ = typ
                    };
                    ctx.tbl_Termine.Add(termin);
                    ctx.SaveChanges();
                    return liste;
                }
                else
                {
                    var liste = from a in ctx.tbl_Termine
                                where a.Termine_ID == id
                                select a;

                    string[] einheit = zeit.Split(':');
                    datum = datum.AddHours(Convert.ToDouble(einheit[0]));
                    datum = datum.AddMinutes(Convert.ToDouble(einheit[1]));
                    foreach (var item in liste)
                    {
                        item.Bezeichnung = bezeichnung;
                        item.Ort = ort;
                        item.Typ = typ;
                        item.DatumUhrzeit = datum;
                    }
                    ctx.SaveChanges();
                    return liste;
                }
            }
        }
    }
}
