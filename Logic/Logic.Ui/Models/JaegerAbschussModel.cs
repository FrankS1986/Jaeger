using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Models
{
    //Die Klasse fuer den Bau der Abschussliste
    public class JaegerAbschussModel
    {
        private string _vorname;
        private string _nachname;
        private int _abschuesse;
        private string _tierart;

        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Abschuesse { get; set; }
        public string Tierart { get; set; }
        JaegerAbschussModel(string vorname, string nachname, int abschuesse, string tierart)
        {
            _vorname = vorname;
            _nachname = nachname;
            _abschuesse = abschuesse;
            _tierart = tierart;
        }
        
    }
}
