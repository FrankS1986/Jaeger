using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    public class Service_Abschussliste
    {
        List<GesamtName> gesamtnamenListe = new List<GesamtName>();
        public List<GesamtName> GesamtnameMethode()
        {
            using (TreibjagdTestEntities datenbankVerbindung = new TreibjagdTestEntities())
            {
                var gesamtnamenSuche = from aktuellerDatensatz in datenbankVerbindung.tbl_Jaeger
                                       select new { aktuellerDatensatz.Vorname, aktuellerDatensatz.Nachname };

                foreach (var item in gesamtnamenSuche)
                {
                    GesamtName neuerName = new GesamtName(item.Vorname.ToString() + " ", item.Nachname.ToString());
                    gesamtnamenListe.Add(neuerName);
                }
                return gesamtnamenListe;
            }
        }
        List<tbl_Tiere> tierartListe = new List<tbl_Tiere>();
        public List<tbl_Tiere> TierartListe()
        {

            using (TreibjagdTestEntities datenbankVerbindung = new TreibjagdTestEntities())
            {
                var tierartSuche = from aktuellerDatensatz in datenbankVerbindung.tbl_Tiere
                                   select new { aktuellerDatensatz.Tierart };

                return tierartListe;
            }
        }
    }
    public class GesamtName
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        public GesamtName(string gegebenerVorname, string gegebenerNachname)
        {
            Vorname = gegebenerVorname;
            Nachname = gegebenerNachname;
        }
    }
}
