namespace JaegerMeister.MvvmSample.Logic.Ui.Models
{
    //Klasse für den Bau der Liste, wie oft eine Tierart erlegt wurde, für die Abschussliste
    public class TierAbschussModel
    {
        private string _Tierart;
        private int _Abschuesse;
        private int _Wildunfaelle;
        public string Tierart
        {
            get
            {
                return _Tierart;
            }
            set
            {
                _Tierart = value;
            }
        }
        public int Abschüsse
        {
            get
            {
                return _Abschuesse;
            }
            set
            {
                _Abschuesse = value;
            }
        }
        public int Wildunfälle
        {
            get
            {
                return _Wildunfaelle;
            }
            set
            {
                _Wildunfaelle = value;
            }
        }
        public TierAbschussModel(string tierart, int abschuesse, int wildunfaelle)
        {
            _Tierart = tierart;
            _Abschuesse = abschuesse;
            _Wildunfaelle = wildunfaelle;
        }
        
    }
}
