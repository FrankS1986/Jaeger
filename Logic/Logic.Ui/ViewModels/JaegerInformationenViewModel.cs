using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace JaegerMeister.MvvmSample.Logic.Ui.ViewModels
{

    public class JaegerInformationenViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private ICommand _btn_jaeger_hinzufuegen;

        public ICommand Btn_jaeger_hinzufuegen
        {
            get
            {
                if (_btn_jaeger_hinzufuegen == null)
                {
                    _btn_jaeger_hinzufuegen = new RelayCommand(() =>
                    {
                        JaegerInformationenViewModel logic = new JaegerInformationenViewModel();

                        //Hier Logik einfügen
                    });

                }
                return _btn_jaeger_hinzufuegen;
            }
        }

        private ICommand _btn_jaeger_entfernen;

        public ICommand Btn_jaeger_entfernen
        {
            get
            {
                if (_btn_jaeger_entfernen == null)
                {
                    _btn_jaeger_entfernen = new RelayCommand(() =>
                    {
                        JaegerInformationenViewModel logic = new JaegerInformationenViewModel();

                        //Hier Logik einfügen
                    });

                }
                return _btn_jaeger_entfernen;
            }
        }

        private ICommand _btn_bearbeiten;

        public ICommand Btn_bearbeiten
        {
            get
            {
                if (_btn_bearbeiten == null)
                {
                    _btn_bearbeiten = new RelayCommand(() =>
                    {
                        JaegerInformationenViewModel logic = new JaegerInformationenViewModel();

                        //Hier Logik einfügen
                    });

                }
                return _btn_bearbeiten;
            }
        }

        private string _lab_vor_und_nachname;

        public string Lab_vor_und_nachname
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

        public string Lab_vorname
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

        public string Lab_nachname
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

        public string Lab_anrede
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

        public string Lab_geburtstag
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

        public string Lab_straße
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

        public string Lab_hausnummer
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

        public string Lab_adresszusatz
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

        public int Lab_postleitzahl
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

        public string Lab_wohnort
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

        public string Lab_telefonnummer1
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

        public string Lab_telefonnummer2
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

        public string Lab_telefonnummer3
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

        public string Lab_email
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

        public string Lab_funktion
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

        public int Lab_jagdhunde
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
