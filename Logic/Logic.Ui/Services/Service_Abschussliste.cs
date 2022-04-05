using System;
using System.Collections.Generic;
using System.Linq;
using JaegerMeister.MvvmSample.Logic.Ui.Models;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    public class Service_Abschussliste
    {
        //Hier wird die gesamte Tabelle der Tiere an den Anfrager zurueck gegeben.
        List<TierAbschussModel> _tierartListe = new List<TierAbschussModel>();
        /// <summary>
        /// Gibt eine Liste vom Typ String mit allen Tierarten zurück.
        /// </summary>
        /// <returns></returns>
        public List<TierAbschussModel> TierartListe()
        {
            _tierartListe = new List<TierAbschussModel>();
            using (TreibjagdTestEntities datenbankVerbindung = new TreibjagdTestEntities())
            {
                var tierartSuche = from aktuellerDatensatz in datenbankVerbindung.tbl_Tiere
                                   orderby aktuellerDatensatz.Tierart ascending
                                   select new { aktuellerDatensatz.Tierart };

                foreach (var item in tierartSuche)
                {
                    _tierartListe.Add(new TierAbschussModel(item.Tierart, 0, 0));
                }
                return _tierartListe;
            }
        }
        //Hier wird die Liste mit Vornamen, Namen und Abschuessen gefuellt. Dafuer zaehlt er
        //wie oft die Jaeger ID in der Jagderfolgsliste vorkommt.
        List<JaegerAbschussModel> _jaegerAbschussModels = new List<JaegerAbschussModel>();
        /// <summary>
        /// Gibt eine Liste vom Typ JaegerAbschussModel mit allen Jaegern zurück.
        /// </summary>
        /// <returns></returns>
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
                DateTime _aktuellesJahr = new DateTime(DateTime.Now.Year, 1, 1);

                _jaegerAbschussModels = new List<JaegerAbschussModel>();
                foreach (var jaeger in Jaegerliste)
                {
                    if (jaeger.Vorname == "Wildunfall")
                    {
                        continue;
                    }
                    int jagderfolge = (from aktuellerDatzensatzErfolg in datenbankVerbindung.tbl_Jagderfolge
                                       join aktuellerDatensatzTermin in datenbankVerbindung.tbl_Termine
                                       on aktuellerDatzensatzErfolg.Termine_ID equals aktuellerDatensatzTermin.Termine_ID
                                       where aktuellerDatzensatzErfolg.Jäger_ID == jaeger.Jäger_ID
                                       && aktuellerDatensatzTermin.DatumUhrzeit >= _aktuellesJahr
                                       select aktuellerDatzensatzErfolg).Count();

                    if (jagderfolge == 0)
                    {
                        continue;
                    }
                    _jaegerAbschussModels.Add(new JaegerAbschussModel(jaeger.Vorname, jaeger.Nachname, jagderfolge));
                }
            }
            return _jaegerAbschussModels;
        }
        //Hier wird die Liste der Tierabschuesse gefuellt, indem gezaehlt wird wie oft die
        //TierID in der Jagderfolgsliste vorkommt. Die Liste besteht aus Tierart und Anzahl der 
        //Abschuesse
        List<TierAbschussModel> _tierAbschussListe = new List<TierAbschussModel>();
        /// <summary>
        /// Gibt eine Liste vom Typ TierAbschussModel mit allen Tierarten zurück.
        /// </summary>
        /// <param name="tierartWahl"></param>
        /// <returns></returns>
        public List<TierAbschussModel> TierAbschussListeMethode(string tierartWahl)
        {
            DateTime _aktuellesJahr = new DateTime(DateTime.Now.Year, 1, 1);
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
                    _tierAbschussListe = new List<TierAbschussModel>();
                    foreach (var einzelTier in tierListe)
                    {
                        if (einzelTier.Tierart == "--Alle Tiere--")
                        {
                            continue;
                        }
                        var tierAbschussAnzahl = (from tierabschuss in datenbankVerbindung.tbl_Jagderfolge
                                                  join termine in datenbankVerbindung.tbl_Termine
                                                    on tierabschuss.Termine_ID equals termine.Termine_ID
                                                  where einzelTier.Tiere_ID == tierabschuss.Tiere_ID && tierabschuss.Jäger_ID != 10
                                                  && termine.DatumUhrzeit >= _aktuellesJahr
                                                  select tierabschuss).Count();
                        var _wildunfaelle = (from wildunfall in datenbankVerbindung.tbl_Jagderfolge
                                             where wildunfall.Jäger_ID == 10 && einzelTier.Tiere_ID == wildunfall.Tiere_ID
                                             select wildunfall).Count();


                        _tierAbschussListe.Add(new TierAbschussModel(einzelTier.Tierart, tierAbschussAnzahl, _wildunfaelle));
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
                        if (einzelTier.Tierart == "--Alle Tiere--")
                        {
                            continue;
                        }
                        //Nimm tbl_jagderfolge, pack den passenden Termin dazu, das aktuelle tier und nicht Wildunfaelle,
                        //und was im aktuellen jahr geschehen ist
                        var tierAbschussAnzahl = (from aktuellerDatensatzJagderfolg in datenbankVerbindung.tbl_Jagderfolge
                                                  join aktuellerDatensatzTermine in datenbankVerbindung.tbl_Termine
                                                    on aktuellerDatensatzJagderfolg.Termine_ID equals aktuellerDatensatzTermine.Termine_ID
                                                  where einzelTier.Tiere_ID == aktuellerDatensatzJagderfolg.Tiere_ID && aktuellerDatensatzJagderfolg.Jäger_ID != 10
                                                  && aktuellerDatensatzTermine.DatumUhrzeit >= _aktuellesJahr
                                                  select aktuellerDatensatzJagderfolg).Count();
                        var _wildunfaelle = (from aktuellerDatzensatzJagderfolg in datenbankVerbindung.tbl_Jagderfolge
                                             join aktuellerDatzensatzTermine in datenbankVerbindung.tbl_Termine
                                                on aktuellerDatzensatzJagderfolg.Termine_ID equals aktuellerDatzensatzTermine.Termine_ID
                                             where aktuellerDatzensatzJagderfolg.Jäger_ID == 10 && einzelTier.Tiere_ID == aktuellerDatzensatzJagderfolg.Tiere_ID
                                             && aktuellerDatzensatzTermine.DatumUhrzeit >= _aktuellesJahr
                                             select aktuellerDatzensatzJagderfolg).Count();
                        _tierAbschussListe.Add(new TierAbschussModel(einzelTier.Tierart, tierAbschussAnzahl, _wildunfaelle));
                    }
                }
            }
            return _tierAbschussListe;
        }
    }
}

