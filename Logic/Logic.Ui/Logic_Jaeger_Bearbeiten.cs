using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using JaegerMeister.MvvmSample.Logic.Ui.Models;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;

namespace JaegerMeister.MvvmSample.Logic.Ui
{

    public class Logic_Jaeger_Bearbeiten : ViewModelBase, INotifyPropertyChanged
    {
        //initiert Service Klasse zum Bearbeiten des Jägers
        JaegerBearbeitenService servEdit = new JaegerBearbeitenService();

        public Logic_Jaeger_Bearbeiten()
        {
            Messenger.Default.Register<string>(this, (prop) =>
            {
                if (prop.Equals("Jaeger"))
                {
                    Lb_jaeger = servEdit.GetJaegerInfoList();
                }
                else if (prop.Equals("Select"))
                {
                    if (SelectedItemJaeger != null)
                    {
                        Tb_vorname = SelectedItemJaeger.Vorname;
                        Tb_nachname = SelectedItemJaeger.Nachname;
                        Cb_anrede = SelectedItemJaeger.Anrede;
                        Dp_geburtstag = SelectedItemJaeger.Geburtsdatum.ToString();
                        Tb_straße = SelectedItemJaeger.Straße;
                        Tb_hausnummer = SelectedItemJaeger.Hausnummer;
                        Tb_adresszusatz = SelectedItemJaeger.Adresszusatz;
                        Tb_postleitzahl = SelectedItemJaeger.Postleitzahl;
                        Tb_wohnort = SelectedItemJaeger.Wohnort;
                        Tb_telefonnummer1 = SelectedItemJaeger.Telefonnummer1;
                        Tb_telefonnummer2 = SelectedItemJaeger.Telefonnummer2;
                        Tb_telefonnummer3 = SelectedItemJaeger.Telefonnummer3;
                        Tb_email = SelectedItemJaeger.Email;
                        Cb_funtkion = SelectedItemJaeger.Funktion;
                        Tb_jagdhunde = SelectedItemJaeger.Jagdhund;

                    }
                }
            });
        }

        private tbl_Jaeger _selectedItemJaeger;
        public tbl_Jaeger SelectedItemJaeger
        {
            get
            {
                return _selectedItemJaeger;
            }
            set
            {
                _selectedItemJaeger = value;
                RaisePropertyChanged("SelectedItemJaeger");
            }
        }

        private List<tbl_Jaeger> _Lb_jaeger;
        public List<tbl_Jaeger> Lb_jaeger
        {
            get
            {
                return _Lb_jaeger;
            }
            set
            {
                _Lb_jaeger = value;
                RaisePropertyChanged("Lb_jaeger");
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
                        Logic_Jaeger_Informationen logic = new Logic_Jaeger_Informationen();

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
                        Logic_Jaeger_Informationen logic = new Logic_Jaeger_Informationen();

                        //Hier Logik einfügen
                    });

                }
                return _btn_jaeger_entfernen;
            }
        }

        private ICommand _btn_bestaetigen;

        public ICommand Btn_bestaetigen
        {
            get
            {
                if (_btn_bestaetigen == null)
                {
                    _btn_bestaetigen = new RelayCommand(() =>
                    {

                    });
                }
                return _btn_bestaetigen;
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
                        Logic_Jaeger_Informationen logic = new Logic_Jaeger_Informationen();

                        //Hier Logik einfügen
                    });

                }
                return _btn_abbrechen;
            }
        }

        private List<tbl_Funktionen> _funktion;
        public List<tbl_Funktionen> Aufgabe
        {
            get
            {
                return _funktion;
            }
            set
            {
                _funktion = value;
                RaisePropertyChanged("Funktion");
            }
        }

        private List<tbl_Anrede> _anrede;
        public List<tbl_Anrede> Anrede
        {
            get
            {
                return _anrede;

            }
            set
            {
                _anrede = value;
                RaisePropertyChanged("Anrede");
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
                _tb_vorname = value;
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
                _cb_anrede = value;
                RaisePropertyChanged("Cb_anrede");
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
                _dp_geburtstag = value;
                RaisePropertyChanged("Dp_geburtstag");
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
                _tb_straße = value;
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
                _tb_hausnummer = value;
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
                _tb_adresszusatz = value;
                RaisePropertyChanged("Tb_adresszusatz");
            }
        }

        private string _tb_postleitzahl;

        public string Tb_postleitzahl
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
                _tb_wohnort = value;
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
                RaisePropertyChanged("Tb_telefonnumer2");
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
                _tb_email = value;
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
                _cb_funktion = value;
                RaisePropertyChanged("Cb_funktion");
            }
        }



        private string _tb_jagdhunde;
public string Tb_jagdhunde
        {
            get
            {
                return _tb_jagdhunde;
            }
            set
            {
                _tb_jagdhunde = value;
                RaisePropertyChanged("Tb_jagdhunde");
            }
        }

    }
}
