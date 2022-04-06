using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.Models;
using JaegerMeister.MvvmSample.Logic.Ui.Services;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Jaeger_Hinzufuegen : ViewModelBase, INotifyPropertyChanged
    {
        //initiert Service Klasse 
        JaegerHinzufuegenService serv = new JaegerHinzufuegenService();

        public Logic_Jaeger_Hinzufuegen()
        {
            Aufgabe = serv.Funktionen();
            Anrede = serv.Anrede();
           Tb_jagdhunde = "0";
           
        }


        //erstellt Liste vom Typ IDVorNachnameModel, ruft serv. Methode auf zum Anzeigen im Datagrid "JaegerListe"
        private List<IDVorNachnameModel> _listIDVorNachname = new List<IDVorNachnameModel>();
        public List<IDVorNachnameModel> JaegerListe
        {           
            get 
            {
                
                _listIDVorNachname = serv.ListeIDVorNachname();
                return _listIDVorNachname;
            }

        }

        /* bei Button klick wird überprüft ob alle Pflichtfelder ausgefüllt sind und anschließend ein neuer eintrag 
         * in die DB tabelle jaeger eingefügt mit den aus den Textboxen übergebenen werten
         Die Text Boxen werden wieder auf null gesetzt
        Es erscheint eine MessageBox nach einem Erfolgreichen Durchlauf*/
        private ICommand _btn_jaeger_hinzufuegen;
        public ICommand Btn_jaeger_hinzufuegen
        {
            get
            {
                if (_btn_jaeger_hinzufuegen == null)
                {
                    _btn_jaeger_hinzufuegen = new RelayCommand(() =>
                    {

                        if(!string.IsNullOrEmpty(Tb_vorname) && !string.IsNullOrEmpty(Tb_nachname) && !string.IsNullOrEmpty(Tb_straße) && !string.IsNullOrEmpty(Tb_hausnummer)&& !string.IsNullOrEmpty(Tb_postleitzahl) && !string.IsNullOrEmpty(Tb_wohnort) && !string.IsNullOrEmpty(Tb_telefonnummer1) && Cb_anrede != null)
                        {
                            var newItem = new tbl_Jaeger()
                            {
                                Anrede = Cb_anrede.Anrede,
                                Vorname = Tb_vorname,
                                Nachname = Tb_nachname,
                                Straße = Tb_straße,
                                Hausnummer = Tb_hausnummer,
                                Adresszusatz = Tb_adresszusatz,
                                Postleitzahl = Tb_postleitzahl,
                                Wohnort = Tb_wohnort,
                                Telefonnummer1 = Tb_telefonnummer1,
                                Telefonnummer2 = Tb_telefonnummer2,
                                Telefonnummer3 = Tb_telefonnummer3,
                                Email = Tb_email,
                                Geburtsdatum = Dp_geburtstag,
                                Funktion = Cb_funktion.Funktion,
                                Jagdhund = Tb_jagdhunde
                            };

                            #region TextBoxenZurücksetzen
                            Tb_vorname = null;
                            Tb_nachname = null;
                            Tb_straße = null;
                            Tb_hausnummer = null;
                            Tb_adresszusatz = null;
                            Tb_postleitzahl = null;
                            Tb_wohnort = null;
                            Tb_telefonnummer1 = null;
                            Tb_telefonnummer2 = null;
                            Tb_telefonnummer3 = null;
                            Tb_email = null;
                            Tb_jagdhunde = null;
                            #endregion TextBoxenZurücksetzen

                            Messenger.Default.Send<JaegerHinzufuegenErfolgsMessage>(new JaegerHinzufuegenErfolgsMessage { Success = serv.InsertNeuerJaeger(newItem) });
                            
                        }
                    
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


        private tbl_Funktionen _cb_funktion;
        public tbl_Funktionen Cb_funktion
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

        private tbl_Anrede _cb_anrede;
        public tbl_Anrede Cb_anrede
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

        private List<tbl_Anrede> _anrede;
        public List<tbl_Anrede> Anrede
        {
            get
            {
                return _anrede;
                ;
            }
            set
            {
                _anrede = value;
                RaisePropertyChanged("Anrede");
            }
        }

        private DateTime _dp_geburtstag;
        public DateTime Dp_geburtstag
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

        #region properties TextBoxen
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
# endregion properties TextBoxen

    }
}
