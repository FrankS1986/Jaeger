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

        private List<GetJaegerInfoModel> _getJaegerInfoList;
        public List<GetJaegerInfoModel> DataGridVorname
        {

        }

        //erstellt Liste vom Typ IDVorNachnameModel, ruft serv. Methode auf zum Anzeigen im Datagrid "Lb_jaeger"
        private List<IDVorNachnameModel> _listIDVorNachname;
        public List<IDVorNachnameModel> Lb_jaeger
        {
            get
            {
                _listIDVorNachname = serv.ListeIDVorNachname();
                return _listIDVorNachname;
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
        public List <tbl_Funktionen> Aufgabe
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
            }
        }

    }
}
