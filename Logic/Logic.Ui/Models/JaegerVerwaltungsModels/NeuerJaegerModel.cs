using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Models
{
    public class NeuerJaegerModel
    {
        // Properties welche maximalen Zugriff (lesen, schreiben) erlauben 
        public int ID
        {
            get;
            set;
        }
        public string Anrede
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
        public string Strasse
        {
            get;
            set;
        }
        public int Hausnummer
        {
            get;
            set;
        }
        public string Adresszusatz
        {
            get;
            set;
        }
        public string PLZ
        {
            get;
            set;
        }
        public string Wohnort
        {
            get;
            set;
        }
        public string Funktion
        {
            get;
            set;
        }
        public string Telefon1
        {
            get;
            set;
        }
        public string Telefon2
        {
            get;
            set;
        }
        public string Telefon3
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public bool Jagdhund
        {
            get;
            set;
        }
        public DateTime Geburtsdatum
        {
            get;
            set;
        }




        // Constructor (Methode welche übergebene Variablen annimmt und diese mit den Properties verbindet)
        //public NeuerJaegerModel(int id, string anrede, string vorname, string nachname, string strasse, int hausnummer, string adresszusatz, string plz, string wohnort, string funktion, string tel1, string tel2, string tel3, string email, bool hund, DateTime geburtsdatum )
        //{
        //    ID = id;
        //    Anrede = anrede;
        //    Vorname = vorname;
        //    Nachname = nachname;
        //    Strasse = strasse;
        //    Hausnummer = hausnummer;
        //    PLZ = plz;
        //    Wohnort = wohnort;
        //    Funktion = funktion;
        //    Telefon1 = tel1;
        //    Telefon2 = tel2;
        //    Telefon3 = tel3;
        //    Email = email;
        //    Jagdhund = hund;
        //    Geburtsdatum = geburtsdatum;
        //}

    }
}
