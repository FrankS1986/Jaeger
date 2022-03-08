using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    public class UrkundenerstellenService
    {
                 /// <summary>
                 /// erstellt Termine Liste
                 /// </summary>
                 /// <returns></returns>
        public List<tbl_Termine> TermineListe()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var termine = from a in ctx.tbl_Termine
                              where a.Typ != "Wildunfall"
                              select new { a.Termine_ID, a.Ort, a.DatumUhrzeit, a.Bezeichnung };
                var liste = new List<tbl_Termine>();

                foreach (var item in termine)
                {
                    liste.Add(new tbl_Termine()
                    {
                        Bezeichnung = item.Bezeichnung,
                        Ort = item.Ort,
                        DatumUhrzeit = item.DatumUhrzeit

                    });

                }
                return liste;
            }

        }
    }
}
