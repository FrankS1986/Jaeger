using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Models
{
    //Klasse für den Bau der Liste, wie oft eine Tierart erlegt wurde, für die Abschussliste
    public class TierAbschussModel
    {
        private string _tierart;
        private int _abschuesse;
        private int _wildunfaelle;
        public string Tierart
        {
            get
            {
                return _tierart;
            }
            set
            {
                _tierart = value;
            }
        }
        public int Abschüsse
        {
            get
            {
                return _abschuesse;
            }
            set
            {
                _abschuesse = value;
            }
        }
        public int Wildunfälle
        {
            get
            {
                return _wildunfaelle;
            }
            set
            {
                _wildunfaelle = value;
            }
        }
        public TierAbschussModel(string tierart, int abschuesse, int wildunfaelle)
        {
            _tierart = tierart;
            _abschuesse = abschuesse;
            _wildunfaelle = wildunfaelle;
        }
        
    }
}
