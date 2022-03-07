using JaegerMeister.MvvmSample.Logic.Ui.Dokumente;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
   public class DokumenteVerwaltenService
    {
        
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


        public List<string> DokumenteLoeschen()
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

    }
}
