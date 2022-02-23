using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JaegerMeister.MvvmSample.Logic.Ui.Models;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{

    //In der Jaegerliste wird nach Vor- und Nachnamen gesucht, und beides gemeinsam in eine stringliste
    //gepackt und zurueck gegeben.
    public class Service_Abschussliste
    {
        List<GesamtNameModel> gesamtnamenListe = new List<GesamtNameModel>();
        public List<GesamtNameModel> GesamtnameMethode()
        {
            using (TreibjagdTestEntities datenbankVerbindung = new TreibjagdTestEntities())
            {
                var gesamtnamenSuche = from aktuellerDatensatz in datenbankVerbindung.tbl_Jaeger
                                       select new { aktuellerDatensatz.Vorname, aktuellerDatensatz.Nachname };

                foreach (var item in gesamtnamenSuche)
                {
                    GesamtNameModel neuerName = new GesamtNameModel(item.Vorname.ToString() + " ", item.Nachname.ToString());
                    gesamtnamenListe.Add(neuerName);
                }
                return gesamtnamenListe;
            }
        }

        //Hier wird die gesamte Tabelle der Tiere an den Anfrager zurueck gegeben.
        List<tbl_Tiere> _tierartListe = new List<tbl_Tiere>();
        public List<tbl_Tiere> TierartListe()
        {

            using (TreibjagdTestEntities datenbankVerbindung = new TreibjagdTestEntities())
            {
                var tierartSuche = from aktuellerDatensatz in datenbankVerbindung.tbl_Tiere
                                   select new { aktuellerDatensatz.Tierart, aktuellerDatensatz.Tiere_ID };

                foreach(var item in tierartSuche)
                {
                    _tierartListe.Add(new tbl_Tiere()
                    {
                        Tiere_ID = item.Tiere_ID,
                        Tierart = item.Tierart
                    }); ;                                        
                }
                return _tierartListe;
            }
        }

        //Hier wird geschaut ob Jaeger oder Tiere oder beides gegeben ist, und eine 
        //entsprechende Liste zurueck gegeben.
        List<JaegerAbschussModel> jaegerAbschussModels = new List<JaegerAbschussModel>();
        public List<JaegerAbschussModel> JaegerAbschussModels(string wahlJaeger, string wahlTierart)
        {

        }
    }
}
