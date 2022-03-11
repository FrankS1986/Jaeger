using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Models
{
    //Klasse die genutzt wird die Felder zu fuellen wenn im Jaegerinformationsfenster ein Jaeger ausgewaehlt wird
    public class JaegerInformationSelectedModel
    {
        public int Jäger_ID { get; set; }
        public string Anrede { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Straße { get; set; }
        public string Hausnummer { get; set; }
        public string Adresszusatz { get; set; }
        public string Postleitzahl { get; set; }
        public string Wohnort { get; set; }
        public string Funktion { get; set; }
        public string Telefonnummer1 { get; set; }
        public string Telefonnummer2 { get; set; }
        public string Telefonnummer3 { get; set; }
        public string Email { get; set; }
        public string Jagdhund { get; set; }
        public Nullable<System.DateTime> Geburtsdatum { get; set; }
    }
}
