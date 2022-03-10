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
    public class UrkundenerstellenService
    {
        /// <summary>
        /// Erstellt eine Termine Liste von Typ Treibjagd
        /// </summary>
        /// <returns></returns>
        public List<tbl_Termine> TermineListe()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var termine = from a in ctx.tbl_Termine
                              where a.Typ == "Treibjagd"
                              select new { a.Termine_ID, a.Ort, a.DatumUhrzeit, a.Bezeichnung };
                var liste = new List<tbl_Termine>();

                foreach (var item in termine)
                {
                    liste.Add(new tbl_Termine()
                    {
                        Termine_ID = item.Termine_ID,
                        Bezeichnung = item.Bezeichnung,
                        Ort = item.Ort,
                        DatumUhrzeit = item.DatumUhrzeit

                    });

                }
                return liste;
            }

        }

         /// <summary>
         /// Erstellt eine Liste von Jägern die sich für diesen Termin angemeldet haben
         /// </summary>
         /// <param name="jaegerID"></param>
         /// <returns></returns>
        public List<Teilname> Jaeger(int jaegerID)
        {

            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var teilnahme = from a in ctx.tbl_Rueckmeldung
                                where a.Termine_ID == jaegerID
                                select new { a.Jäger_ID, a.Termine_ID };

                var listeJaeger = new List<Teilname>();
                if (teilnahme.Count() >= 1)
                {
                    foreach (var item in teilnahme)
                    {
                        var jaeger = from a in ctx.tbl_Jaeger
                                     where a.Jäger_ID == item.Jäger_ID
                                     from b in ctx.tbl_Termine
                                     where b.Termine_ID == item.Termine_ID
                                     select new { a.Jäger_ID, a.Vorname, a.Nachname, a.Anrede, b.Termine_ID, b.Ort, b.DatumUhrzeit, b.Typ };

                        foreach (var b in jaeger)
                        {
                            listeJaeger.Add(new Teilname()
                            {
                                ID = b.Jäger_ID,
                                Anrede = b.Anrede,
                                Vorname = b.Vorname,
                                Nachname = b.Nachname,
                                Ort = b.Ort,
                                Datum = b.DatumUhrzeit.Date,
                                Typ = b.Typ
                            });
                        }

                    }

                }

                return listeJaeger;
            }
        }
        /// <summary>
        /// Erstellt eine Liste von Jägern die Extrag Urkunden bekommen sollen
        /// </summary>
        /// <param name="xy"></param>
        /// <returns></returns>
        public List<Urkunden> EhrungenErstellen(List<Teilname> xy)
        {
            var liste = new List<Urkunden>();
            foreach (var i in xy)
            {
                if (i.Ehrenuhrkunde)
                {
                    liste.Add(new Urkunden()
                    {

                        ID = i.ID,
                        Vorname = i.Vorname,
                        Nachname = i.Nachname,
                        Ort= i.Ort,
                        Anrede=i.Anrede,
                        Datum = i.Datum.Date,
                        Typ = i.Typ



                    });
                }
            }
            return liste;
        }

         /// <summary>
         /// Erstellt für den Teilnehmenden Jäger eine Teilnahme Uhrkunde
         /// </summary>
         /// <param name="teilname"></param>
         /// <param name="filename"></param>
         /// <param name="SaveAs"></param>
        public void Erstellen(Teilname teilname, object filename, object SaveAs)
        {

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;
              // Überprüft  ob das Dokument Existiert
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



                this.FindAndReplace(wordApp, "<anrede>", teilname.Anrede);
                this.FindAndReplace(wordApp, "<name>", teilname.Vorname);
                this.FindAndReplace(wordApp, "<nachname>", teilname.Nachname);

                this.FindAndReplace(wordApp, "<typ>", teilname.Typ);
                this.FindAndReplace(wordApp, "<ort>", teilname.Ort);
                this.FindAndReplace(wordApp, "<datum>", teilname.Datum.Date);

                this.FindAndReplace(wordApp, "<now>", DateTime.Now.Date);




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



         /// <summary>
         /// Erstellt eine Ehrenurkunde oder eine Standardurkunde für die ausgewählten Jäger
         /// </summary>
         /// <param name="teilname"></param>
         /// <param name="filename"></param>
         /// <param name="SaveAs"></param>
        public void UrkundenErstellen(Urkunden teilname, object filename, object SaveAs)
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



                this.FindAndReplace(wordApp, "<anrede>", teilname.Anrede);
                this.FindAndReplace(wordApp, "<name>", teilname.Vorname);
                this.FindAndReplace(wordApp, "<nachname>", teilname.Nachname);

                this.FindAndReplace(wordApp, "<typ>", teilname.Typ);
                this.FindAndReplace(wordApp, "<ort>", teilname.Ort);
                this.FindAndReplace(wordApp, "<datum>", teilname.Datum.Date);

                this.FindAndReplace(wordApp, "<now>", DateTime.Now.Date);




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







         /// <summary>
         /// Findet den Text im Dokument
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

        public class Teilname
        {
            public string Anrede { get; set; }
            public string Vorname { get; set; }
            public string Nachname { get; set; }

            public string Typ { get; set; }
            public string Ort { get; set; }
            public DateTime Datum { get; set; }


            public int ID { get; set; }

            public bool Ehrenuhrkunde { get; set; }


        }

        public class Urkunden
        {
            public string Anrede { get; set; }
            public string Vorname { get; set; }
            public string Nachname { get; set; }
            public int ID { get; set; }

            public string Typ { get; set; }
            public string Ort { get; set; }
            public DateTime Datum { get; set; }

            public bool Ehrenuhrkunde { get; set; }
            public bool Standard { get; set; }


        }

    }
}
