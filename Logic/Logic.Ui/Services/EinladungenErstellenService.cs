using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    public class EinladungenErstellenService
    {
        //TODO: Ladebalken hinzufügen
        /// <summary>
        /// Es wird in der Tabelle Postaussgang ein eintrag hinzugefügt.
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public bool InsertPostausgang(tbl_Postausgang post)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())


            {
                try
                {

                    ctx.tbl_Postausgang.Add(post);
                    ctx.SaveChanges();

                    return true;

                }

                catch (Exception ex)
                {

                    return false;
                    throw ex;
                }

            }

        }
        /// <summary>
        /// Es wird eine Tabelle mit Terminen erstellt
        /// </summary>
        /// <returns></returns>
        public List<tbl_Termine> Termine()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var termine = from a in ctx.tbl_Termine
                              where a.Typ != "Wildunfall"
                              select new { a.Termine_ID, a.Ort, a.DatumUhrzeit, a.Typ };
                var liste = new List<tbl_Termine>();

                foreach (var item in termine)
                {
                    liste.Add(new tbl_Termine()
                    {
                        Termine_ID = item.Termine_ID,
                        Ort = item.Ort,
                        DatumUhrzeit = item.DatumUhrzeit,
                        Typ = item.Typ


                    });

                }

                return liste;
            }
        }

        private List<int> jaegerIDListe = new List<int>();
        /// <summary>
        /// Hier wird eine string Liste erstellt von den Bereits Eingeladenen Personen.
        /// </summary>
        /// <param name="terminid"></param>
        /// <returns></returns>
        public List<string> Eingeladen(int terminid)
        {
            jaegerIDListe.Clear();
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {


                var nameIndex = from abfrage in ctx.tbl_Postausgang
                                where abfrage.Termine_ID == terminid
                                select new
                                {
                                    abfrage.Postausgang_ID,
                                    abfrage.tbl_Dokumente.Bezeichnung,
                                    abfrage.tbl_Jaeger.Jäger_ID,
                                    abfrage.tbl_Jaeger.Vorname,
                                    abfrage.tbl_Jaeger.Nachname,

                                    abfrage.DatumUhrzeit
                                };

                var liste3 = new List<string>();

                foreach (var item in nameIndex)
                {
                    liste3.Add(item.Vorname + " " + item.Nachname);
                    jaegerIDListe.Add(item.Jäger_ID);

                }


                return liste3;

            }
        }




        /// <summary>
        ///   Hier wird eine Jaegerliste erstellt abzüglich der schon eingeladenen Personen
        /// </summary>
        /// <returns></returns>
        public List<Einladung> JaegerListe()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {


                var jaeger = from a in ctx.tbl_Jaeger

                             orderby a.Vorname, a.Nachname
                             select new { a.Jäger_ID,a.Anrede, a.Vorname, a.Nachname, a.Straße, a.Hausnummer, a.Adresszusatz, a.Postleitzahl, a.Wohnort };

                var liste = new List<Einladung>();

                foreach (var item in jaeger)
                {
                    liste.Add(new Einladung()
                    {
                        ID = item.Jäger_ID,
                        Anrede = item.Anrede,
                        Vorname = item.Vorname,
                        Nachname = item.Nachname,
                        Strasse = item.Straße,
                        Hausnummer = item.Hausnummer,
                        Adresszusatz = item.Adresszusatz,
                        Postleitzahl = item.Postleitzahl,
                        Ort = item.Wohnort,

                    });

                }
                for (int i = 0; i < jaegerIDListe.Count; i++)
                {
                    liste = liste.Where(x => x.ID != jaegerIDListe[i]).ToList();
                }

                return liste;

            }

        }

        /// <summary>
        /// Sucht den Text im Dokument und wird erstetz
        /// </summary>
        /// <param name="wordApp"></param>
        /// <param name="ToFindText"></param>
        /// <param name="replaceWithText"></param>
        private void FindAndReplace(Word.Application wordApp, object ToFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref ToFindText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundLike,
                ref nmatchAllforms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiactitics, ref matchAlefHamza,
                ref matchControl);
        }

        /// <summary>
        /// Hier wird das Dokument erstellt und gespeichert
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="SaveAs"></param>
        /// <param name="jaegerID"></param>
        public void CreateWordDocument(Einladung einladen, object filename, object SaveAs)
        {


            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
               

                Word.Application wordApp = new Word.Application();
                object missing = Missing.Value;
                Word.Document myWordDoc = null;

                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    wordApp.Visible = false;

                    myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing, ref missing);
                    myWordDoc.Activate();


                    
                        this.FindAndReplace(wordApp, "<anrede>", einladen.Anrede );
                        this.FindAndReplace(wordApp, "<name>", einladen.Vorname);
                        this.FindAndReplace(wordApp, "<nachname>", einladen.Nachname);
                        this.FindAndReplace(wordApp, "<strasse>", einladen.Strasse);
                        this.FindAndReplace(wordApp, "<hausnummer>", einladen.Hausnummer);
                        this.FindAndReplace(wordApp, "<adresszusatz>", einladen.Adresszusatz);
                        this.FindAndReplace(wordApp, "<postleitzahl>", einladen.Postleitzahl);
                        this.FindAndReplace(wordApp, "<ort>", einladen.Ort);
                    



                }
                else
                {

                }

                //Save as
                myWordDoc.SaveAs2(ref SaveAs, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);

                myWordDoc.Close();
                wordApp.Quit();



            }





        }


        public class Einladung
        {
            public int ID { get; set; }
            public string Anrede { get; set; }
            public string Vorname { get; set; }
            public string Nachname { get; set; }
            public string Strasse { get; set; }

            public string Hausnummer { get; set; }

            public string Adresszusatz { get; set; }

            public string Postleitzahl { get; set; }
            public string Ort { get; set; }

            public bool Eingeladen { get; set; }



        }
             
    }
}
