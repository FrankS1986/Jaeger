using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JaegerMeister.MvvmSample.Logic.Ui.Models;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    public class JaegerHinzufuegenService
    {
        private List<IDVorNachnameModel> _listeIDVorNachname = new List<IDVorNachnameModel>();
        public List<IDVorNachnameModel> ListeIDVorNachname()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {

                var nameIndex = from abfrage in ctx.tbl_Jaeger
                                select new
                                {
                                    abfrage.Jäger_ID,
                                    abfrage.Vorname,
                                    abfrage.Nachname

                                };
                foreach (var item in nameIndex)
                {
                    IDVorNachnameModel VNM = new IDVorNachnameModel(item.Jäger_ID, item.Vorname, item.Nachname);
                    _listeIDVorNachname.Add(VNM);
                }
            }
            return _listeIDVorNachname;
        }
    }
}
