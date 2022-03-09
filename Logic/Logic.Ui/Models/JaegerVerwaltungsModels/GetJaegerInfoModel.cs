using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Models.JaegerVerwaltungsModels
{
    class GetJaegerInfoModel
    {
        //Properties mit maximalen Zugriff (lesen, schreiben)
        #region Properties
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
        public string Hausnummer
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
        public DateTime? Geburtsdatum
        {
            get;
            set;
        }
        public string Funktion
        {
            get;
            set;
        }
        public string Jagdhund
        {
            get;
            set;
        }
     
        #endregion Properties

        //Constructor (nimmt Variablen an und verbindet sie mit Properties
        public GetJaegerInfoModel (int id, string vorname, string nachname, string strasse, string hausnummer, string adresszusatz, string plz, string wohnort, string telefon1, string telefon2, string telefon3, string email, DateTime? geburtsdatum, string funktion, string jagdhund)
        {
            ID = id;
            Vorname = vorname;
            Nachname = nachname;
            Strasse = strasse;
            Hausnummer = hausnummer;
            Adresszusatz = adresszusatz;
            PLZ = plz;
            Wohnort = wohnort;
            Funktion = funktion;
            Telefon1 = telefon1;
            Telefon2 = telefon2;
            Telefon3 = telefon3;
            Email = email;
            Jagdhund = jagdhund;
            Geburtsdatum = geburtsdatum;
        }
    }
}
