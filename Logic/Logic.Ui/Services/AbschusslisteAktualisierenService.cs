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
        public List<tbl_Tiere> Tiere()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {

                var liste = ctx.tbl_Tiere.ToList();

                return liste;
            }

        }
        


        

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
                                     select new { a.Vorname, a.Nachname };

                        foreach (var b in jaeger)
                        {
                            listeJaeger.Add(new tbl_Jaeger()
                            { 
                                Vorname = b.Vorname,
                                Nachname = b.Nachname
                            });
                        }

                    }

                }


                return listeJaeger;
            }
        }


    }
}
