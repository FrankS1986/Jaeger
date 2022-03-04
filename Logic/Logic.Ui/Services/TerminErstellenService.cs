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
    }
}
