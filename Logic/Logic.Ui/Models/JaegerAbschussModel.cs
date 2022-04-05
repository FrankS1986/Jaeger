namespace JaegerMeister.MvvmSample.Logic.Ui.Models
{
    //Die Klasse fuer den Bau der Abschussliste fuer Jaeger
    public class JaegerAbschussModel
    {
        private string _Vorname;
        private string _Nachname;
        private int _Abschuesse = 0;


        public string Vorname
        {
            get { return _Vorname; }
            set { _Vorname = value; }
        }
        public string Nachname
        {
            get
            { return _Nachname; }
            set { _Nachname = value; }
        }
        public int Abschüsse
        {
            get { return _Abschuesse; }
            set { _Abschuesse = value; }
        }

        public JaegerAbschussModel(string vorname, string nachname, int abschuesse)
        {
            _Vorname = vorname;
            _Nachname = nachname;
            _Abschuesse = abschuesse;
        }
    }
}
