using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Models
{
    //Die Klasse fuer den Bau der Abschussliste fuer Jaeger
    public class JaegerAbschussModel
    {
        private string _vorname;
        private string _nachname;
        private int _abschuesse = 0;


        public string Vorname
        {
            get { return _vorname; }
            set { _vorname = value; }
        }
        public string Nachname
        {
            get
            { return _nachname; } 
            set { _nachname = value; }
        }
        public int Abschüsse 
        {
            get { return _abschuesse; }
            set { _abschuesse = value; }
        }

        public JaegerAbschussModel(string vorname, string nachname, int abschuesse)
        {
            _vorname = vorname;
            _nachname = nachname;
            _abschuesse = abschuesse;
        }        
    }
}
