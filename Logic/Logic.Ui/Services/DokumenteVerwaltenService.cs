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

            string[] datein = Directory.GetFiles(Paths.GetFilePath(@"Bilder"));
            foreach (string s in datein)
            {
                liste.Add(Path.GetFileName(s));
            }

            return liste;


        }
    }
}
