using JaegerMeister.MvvmSample.Logic.Ui.Dokumente;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows;





namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    public class DokumenteVerwaltenService
    {
        /// <summary>
        /// Liest den Ordner Dokumente aus und schreibt die datein in einer Liste.
        /// </summary>
        /// <returns></returns>
        public List<string> DokumenteListe()
        {
            List<string> liste = new List<string>();

            liste.Clear();

            string[] datein = Directory.GetFiles(Paths.GetFilePath(@"Logic\\Logic.Ui\\Dokumente\\"));
            foreach (string s in datein)
            {
                liste.Add(Path.GetFileName(s));
            }

            liste = liste.Where(x => x != "Paths.cs").ToList();
            return liste;


        }

        /// <summary>
        ///   Löscht das angegebene Dokument
        /// </summary>
        /// <returns></returns>
        public void DokumenteLoeschen(string name)
        {

            System.IO.File.Delete(Paths.GetFilePath(@"Logic\\Logic.Ui\\Dokumente\\" + name));
          

        }

        /// <summary>
        /// Öffnet das Dokument zum Bearbeiten
        /// </summary>
        /// <param name="name"></param>
        public void DokumenteBearbeiten(string name)
        {

            Process.Start(Paths.GetFilePath(@"Logic\\Logic.Ui\\Dokumente\\" + name));

        }

        public bool pruefen;
        public bool DokumentUeberpruefen(string datei)
        {
            List<string> liste = new List<string>();

            liste.Clear();

            string[] datein = Directory.GetFiles(Paths.GetFilePath(@"Logic\\Logic.Ui\\Dokumente\\"));
            foreach (string s in datein)
            {
                liste.Add(Path.GetFileName(s));
            }

            for (int i = 0; i < liste.Count; i++)
            {
                pruefen = liste[1] != datei;

            }

            return pruefen;

        }


    }
}
