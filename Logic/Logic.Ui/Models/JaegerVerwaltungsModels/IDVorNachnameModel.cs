using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Models
{
    public class IDVorNachnameModel
    {
        /* Properties welche maximalen Zugriff (lesen, schreiben) erlauben */
        public int ID
        {
            get;
            set;
        }
        public string Vorname
        {
            get;
            set;
        }
        public string Nachname
        {
            get;
            set;
        }
        // Constructor (Methode welche übergebene Variablen annimmt und diese mit den Properties verbindet)

        /// <summary>
        /// Klasse für die Zusammenstellung des Jägers im Fenster JaegerHinzufuegen
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vorname"></param>
        /// <param name="nachname"></param>
        public IDVorNachnameModel(int id, string vorname, string nachname)
        {
            ID = id;
            Vorname = vorname;
            Nachname = nachname;
        }
    }
   
}
