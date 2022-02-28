using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JaegerMeister.MvvmSample.Logic.Ui.Models;
using JaegerMeister.MvvmSample.Logic.Ui.Services;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Jaeger_Hinzufuegen : ViewModelBase, INotifyPropertyChanged
    {
        JaegerHinzufuegenService serv = new JaegerHinzufuegenService();
        
        private List<IDVorNachnameModel> _listIDVorNachname = new List<IDVorNachnameModel>();
        public List<IDVorNachnameModel> JaegerListe
        {
            get 
            {
                _listIDVorNachname = serv.ListeIDVorNachname();
                return _listIDVorNachname;
            }
            set 
            {
                _listIDVorNachname = value;
                RaisePropertyChanged("JaegerListe");

            }
         
        }
        private ICommand _btn_jaeger_hinzufuegen;

        public ICommand Btn_jaeger_hinzufuegen
        {
            get
            {
                if (_btn_jaeger_hinzufuegen == null)
                {
                    _btn_jaeger_hinzufuegen = new RelayCommand(() =>
                    {
                     
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
                      
                    });

                }
                return _btn_jaeger_entfernen;
            }
        }

        private ICommand _btn_hinzufuegen;

        public ICommand Btn_hinzufuegen
        {
            get
            {
                if (_btn_hinzufuegen == null)
                {
                    _btn_hinzufuegen = new RelayCommand(() =>
                    {
                  
                    });

                }
                return _btn_hinzufuegen;
            }
        }

        private ICommand _btn_abbrechen;

        public ICommand Btn_abbrechen
        {
            get
            {
                if (_btn_abbrechen == null)
                {
                    _btn_abbrechen = new RelayCommand(() =>
                    {
                       
                    });

                }
                return _btn_abbrechen;
            }
        }

        private string _tb_vorname;

        public string Tb_vorname
        {
            get
            {
                return _tb_vorname;
            }
            set
            {
                _tb_vorname= value;
                RaisePropertyChanged("Tb_vorname");
            }
        }

        private string _tb_nachname;

        public string Tb_nachname
        {
            get
            {
                return _tb_nachname;
            }
            set
            {
                _tb_nachname = value;
                RaisePropertyChanged("Tb_nachname");
            }
        }

        private string _cb_anrede;

        public string Cb_anrede
        {
            get
            {
                return _cb_anrede;
            }
            set
            {
               
            }
        }

        private string _dp_geburtstag;

        public string Dp_geburtstag
        {
            get
            {
                return _dp_geburtstag;
            }
            set
            {
               
            }
        }

        private string _tb_straße;

        public string Tb_straße
        {
            get
            {
                return _tb_straße;
            }
            set
            {
                _tb_straße= value;
                RaisePropertyChanged("Tb_straße");
            }
        }

        private string _tb_hausnummer;

        public string Tb_hausnummer
        {
            get
            {
                return _tb_hausnummer;
            }
            set
            {
                _tb_hausnummer= value;
                RaisePropertyChanged("Tb_hausnummer");
            }
        }

        private string _tb_adresszusatz;

        public string Tb_adresszusatz
        {
            get
            {
                return _tb_adresszusatz;
            }
            set
            {
                _tb_adresszusatz= value;
                RaisePropertyChanged("Tb_adresszusatz");
            }
        }

        private int _tb_postleitzahl;

        public int Tb_postleitzahl
        {
            get
            {
                return _tb_postleitzahl;
            }
            set
            {
                _tb_postleitzahl = value;
                RaisePropertyChanged("Tb_postleitzahl");
            }
        }

        private string _tb_wohnort;

        public string Tb_wohnort
        {
            get
            {
                return _tb_wohnort;
            }
            set
            {
                _tb_wohnort= value;
                RaisePropertyChanged("Tb_wohnort");
            }
        }

        private string _tb_telefonnummer1;

        public string Tb_telefonnummer1
        {
            get
            {
                return _tb_telefonnummer1;
            }
            set
            {
                _tb_telefonnummer1 = value;
                RaisePropertyChanged("Tb_telefonnummer1");
            }
        }

        private string _tb_telefonnummer2;

        public string Tb_telefonnummer2
        {
            get
            {
                return _tb_telefonnummer2;
            }
            set
            {
                _tb_telefonnummer2 = value;
                RaisePropertyChanged("Tb_telefonnummer2");
            }
        }

        private string _tb_telefonnummer3;

        public string Tb_telefonnummer3
        {
            get
            {
                return _tb_telefonnummer3;
            }
            set
            {
                _tb_telefonnummer3 = value;
                RaisePropertyChanged("Tb_telefonnummer3");
            }
        }

        private string _tb_email;

        public string Tb_email
        {
            get
            {
                return _tb_email;
            }
            set
            {
                _tb_email= value;
                RaisePropertyChanged("Tb_email"); 
            }
        }

        private string _cb_funktion;

        public string Cb_funtkion
        {
            get
            {
                return _cb_funktion;
            }
            set
            {
                
            }
        }

        private int _tb_jagdhunde;

        public int Tb_jagdhunde
        {
            get
            {
                return _tb_jagdhunde;
            }
            set
            {
                _tb_jagdhunde = value;
                RaisePropertyChanged("tb_jagdhunde");
            }
        }


    }
}
