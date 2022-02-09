using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace JaegerMeister.MvvmSample.Logic.Ui
{

    public class Logic_Jaeger_Informationen : ViewModelBase, INotifyPropertyChanged
    {

        private ICommand _btn_jaeger_hinzufuegen;

        public ICommand btn_jaeger_hinzufuegen
        {
            get
            {
                if (_btn_jaeger_hinzufuegen == null)
                {
                    _btn_jaeger_hinzufuegen = new RelayCommand(() =>
                    {
                        Logic_Jaeger_Informationen logic = new Logic_Jaeger_Informationen();

                        //Hier Logik einfügen
                    });

                }
                return _btn_jaeger_hinzufuegen;
            }
        }

        private ICommand _btn_jaeger_entfernen;

        public ICommand btn_jaeger_entfernen
        {
            get
            {
                if (_btn_jaeger_entfernen == null)
                {
                    _btn_jaeger_entfernen = new RelayCommand(() =>
                    {
                        Logic_Jaeger_Informationen logic = new Logic_Jaeger_Informationen();

                        //Hier Logik einfügen
                    });

                }
                return _btn_jaeger_entfernen;
            }
        }

        private ICommand _btn_bearbeiten;

        public ICommand btn_bearbeiten
        {
            get
            {
                if (_btn_bearbeiten == null)
                {
                    _btn_bearbeiten = new RelayCommand(() =>
                    {
                        Logic_Jaeger_Informationen logic = new Logic_Jaeger_Informationen();

                        //Hier Logik einfügen
                    });

                }
                return _btn_bearbeiten;
            }
        }

        private string _lab_vor_und_nachname;

        public string lab_vor_und_nachname
        {
            get
            {
                return _lab_vor_und_nachname;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }

        private string _lab_vorname;

        public string lab_vorname
        {
            get
            {
                return _lab_vorname;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }

        private string _lab_nachname;

        public string lab_nachname
        {
            get
            {
                return _lab_nachname;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }

        private string _lab_anrede;

        public string lab_anrede
        {
            get
            {
                return _lab_anrede;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }

        private string _lab_geburtstag;

        public string lab_geburtstag
        {
            get
            {
                return _lab_geburtstag;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }

        private string _lab_straße;

        public string lab_straße
        {
            get
            {
                return _lab_straße;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }

        private string _lab_hausnummer;

        public string lab_hausnummer
        {
            get
            {
                return _lab_hausnummer;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }

        private string _lab_adresszusatz;

        public string lab_adresszusatz
        {
            get
            {
                return _lab_adresszusatz;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }

        private int _lab_postleitzahl;

        public int lab_postleitzahl
        {
            get
            {
                return _lab_postleitzahl;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }

        private string _lab_wohnort;

        public string lab_wohnort
        {
            get
            {
                return _lab_wohnort;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }

        private string _lab_telefonnummer1;

        public string lab_telefonnummer1
        {
            get
            {
                return _lab_telefonnummer1;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }

        private string _lab_telefonnummer2;

        public string lab_telefonnummer2
        {
            get
            {
                return _lab_telefonnummer2;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }

        private string _lab_telefonnummer3;

        public string lab_telefonnummer3
        {
            get
            {
                return _lab_telefonnummer3;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }



        private string _lab_email;

        public string lab_email
        {
            get
            {
                return _lab_email;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }



        private string _lab_funktion;

        public string lab_funtkion
        {
            get
            {
                return _lab_funktion;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }



        private int _lab_jagdhunde;

        public int lab_jagdhunde
        {
            get
            {
                return _lab_jagdhunde;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }

    }
}
