using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Models
{
    //Klasse für den Bau der Liste, wie oft eine Tierart erlegt wurde.
    public class TierAbschussModel
    {
        private string _tierart;
        private int _abschuesse;
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
        public int Abschuesse
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
        public TierAbschussModel(string tierart, int abschuesse)
        {
            _tierart = tierart;
            _abschuesse = abschuesse;
        }
    }
}
