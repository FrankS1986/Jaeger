using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JaegerMeister.MvvmSample.Logic.Ui.Models;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    public class Service_Abschussliste
    {
        //Hier wird die gesamte Tabelle der Tiere an den Anfrager zurueck gegeben.
        List<string> _tierartListe = new List<string>();
        public List<string> TierartListe()
        {
            _tierartListe = new List<string>();
            using (TreibjagdTestEntities datenbankVerbindung = new TreibjagdTestEntities())
            {
                var tierartSuche = from aktuellerDatensatz in datenbankVerbindung.tbl_Tiere
                                   select new { aktuellerDatensatz.Tierart};

                foreach (var item in tierartSuche)
                {
                    _tierartListe.Add(item.Tierart);
                }
                _tierartListe.Sort();
                return _tierartListe;
            }
        }
        //Hier wird die Liste mit Vornamen, Namen und Abschuessen gefuellt. Dafuer zaehlt er
        //wie oft die Jaeger ID in der Jagderfolgsliste vorkommt.
        List<JaegerAbschussModel> jaegerAbschussModels = new List<JaegerAbschussModel>();
        public List<JaegerAbschussModel> JaegerAbschuesse()
        {
            using (TreibjagdTestEntities datenbankVerbindung = new TreibjagdTestEntities())
            {
                var Jaegerliste = from jaeger in datenbankVerbindung.tbl_Jaeger
                                  select new
                                  {
                                      jaeger.Vorname,
                                      jaeger.Nachname,
                                      jaeger.Jäger_ID
                                  };
                foreach (var jaeger in Jaegerliste)
                {
                    if (jaeger.Vorname == "Wildunfall")
                    {
                        continue;
                    }
                    int jagderfolge = (from jagderfolg in datenbankVerbindung.tbl_Jagderfolge
                                       where jagderfolg.Jäger_ID == jaeger.Jäger_ID
                                       select jagderfolg).Count();
                    if(jagderfolge == 0)
                    {
                        continue;
                    }
                    jaegerAbschussModels.Add(new JaegerAbschussModel(jaeger.Vorname, jaeger.Nachname, jagderfolge));
                }
            }
            return jaegerAbschussModels;
        }
        //Hier wird die Liste der Tierabschuesse gefuellt, indem gezaehlt wird wie oft die
        //TierID in der Jagderfolgsliste vorkommt. Die Liste besteht aus Tierart und Anzahl der 
        //Abschuesse
        List<TierAbschussModel> _tierAbschussListe = new List<TierAbschussModel>();
        public List<TierAbschussModel> TierAbschussListeMethode(string tierartWahl)
        {
            _tierAbschussListe = new List<TierAbschussModel>();
            using (TreibjagdTestEntities datenbankVerbindung = new TreibjagdTestEntities())
            {   
                if (string.IsNullOrEmpty(tierartWahl) || tierartWahl == "--Alle Tiere--")
                {
                    var tierListe = from tierart in datenbankVerbindung.tbl_Tiere
                                    select new
                                    {
                                        tierart.Tiere_ID,
                                        tierart.Tierart
                                    };
                    foreach (var einzelTier in tierListe)
                    {
                        if (einzelTier.Tierart == "--Alle Tiere--")
                        {
                            continue;
                        }
                        var tierAbschussAnzahl = (from tierabschuss in datenbankVerbindung.tbl_Jagderfolge
                                                  where einzelTier.Tiere_ID == tierabschuss.Tiere_ID
                                                  select tierabschuss).Count();
                        _tierAbschussListe.Add(new TierAbschussModel(einzelTier.Tierart, tierAbschussAnzahl));
                    }
                }
                else
                {
                    var tierListe = from tierart in datenbankVerbindung.tbl_Tiere
                                    where tierart.Tierart == tierartWahl
                                    select new
                                    {
                                        tierart.Tiere_ID,
                                        tierart.Tierart
                                    };
                    foreach (var einzelTier in tierListe)
                    {
                        if(einzelTier.Tierart == "--Alle Tiere--")
                        {
                            continue;
                        }
                        var tierAbschussAnzahl = (from tierabschuss in datenbankVerbindung.tbl_Jagderfolge
                                                  where einzelTier.Tiere_ID == tierabschuss.Tiere_ID
                                                  select tierabschuss).Count();
                        _tierAbschussListe.Add(new TierAbschussModel(einzelTier.Tierart, tierAbschussAnzahl));
                    }
                }
            }
            return _tierAbschussListe;
        }
    }
}
