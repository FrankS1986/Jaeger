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

            //Farbe der Textboxen falls leer
            BBvorname = "#230C0F";
            BBnachname = "#230C0F";
            BBgeburtstag = "#230C0F";
            BBstrasse = "#230C0F";
            //BBhausnummer = "#230C0F";
            BBadresszusatz = "#230C0F";
            BBplz = "#230C0F";
            BBwohnort = "#230C0F";
            BBtel1 = "#230C0F";
            BBtel2 = "#230C0F";
            BBtel3 = "#230C0F";
            BBmail = "#230C0F";
            BBhunde = "#230C0F";

        }

        /// <summary>
        /// Methode zum Färben der Textboxen: wenn leer, dann rot, wenn befüllt, dann default
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private string ValidateInput(string field)
        {
            field.Trim();
            if (string.IsNullOrEmpty(field))
            {
                return "Red";
            }
            return "#230C0F";
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
         * Die Text Boxen werden wieder auf null gesetzt
         * Es erscheint eine MessageBox nach einem Erfolgreichen Durchlauf */
        private ICommand _btn_jaeger_hinzufuegen;
        public ICommand Btn_jaeger_hinzufuegen
        {
            get
            {
                if (_btn_jaeger_hinzufuegen == null)
                {
                    _btn_jaeger_hinzufuegen = new RelayCommand(() =>
                    {

                        if (!string.IsNullOrEmpty(Tb_vorname) && !string.IsNullOrEmpty(Tb_nachname) && !string.IsNullOrEmpty(Tb_straße) && /*!string.IsNullOrEmpty(Tb_hausnummer) && */!string.IsNullOrEmpty(Tb_postleitzahl) && !string.IsNullOrEmpty(Tb_wohnort) && !string.IsNullOrEmpty(Tb_telefonnummer1) && Cb_anrede != null)
                        {
                            var newItem = new tbl_Jaeger()
                            {
                                Anrede = Cb_anrede.Anrede,
                                Vorname = Tb_vorname,
                                Nachname = Tb_nachname,
                                Straße = Tb_straße,
                                Hausnummer = Tb_hausnummer.ToString(),
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
                            Tb_hausnummer = 0;
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
                        else
                        {
                            Messenger.Default.Send<JaegerHinzufuegenErfolgsMessage>(new JaegerHinzufuegenErfolgsMessage { Success = false });
                            
                            BBvorname = ValidateInput(Tb_vorname);
                            BBnachname = ValidateInput(Tb_nachname);
                            BBstrasse = ValidateInput(Tb_straße);
                            //BBhausnummer = ValidateInput(Tb_hausnummer);
                            BBplz = ValidateInput(Tb_postleitzahl);
                            BBwohnort = ValidateInput(Tb_wohnort);
                            BBtel1 = ValidateInput(Tb_telefonnummer1);
                           
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
        private string _BBvorname;
        public string BBvorname
        {
            get
            {
                return _BBvorname;
            }
            set
            {
                _BBvorname = value;
                RaisePropertyChanged("BBvorname");
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

        private string _BBnachname;
        public string BBnachname
        {
            get
            {
                return _BBnachname;
            }
            set
            {
                _BBnachname = value;
                RaisePropertyChanged("BBnachname");
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

        private string _BBgeburtstag;
        public string BBgeburtstag
        {
            get
            {
                return _BBgeburtstag;
            }
            set
            {
                _BBgeburtstag = value;
                RaisePropertyChanged("BBgeburtstag");
            }
        }

        private string _BBstrasse;
        public string BBstrasse
        {
            get
            {
                return _BBstrasse;
            }
            set
            {
                _BBstrasse = value;
                RaisePropertyChanged("BBstrasse");
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

        private int _BBhausnummer;
        public int BBhausnummer
        {
            get
            {
                return _BBhausnummer;
            }
            set
            {
                _BBhausnummer = value;
                RaisePropertyChanged("BBhausnummer");
            }
        }

        private int _tb_hausnummer;
        public int Tb_hausnummer
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

        private string _BBadresszusatz;
        public string BBadresszusatz
        {
            get
            {
                return _BBadresszusatz;
            }
            set
            {
                _BBadresszusatz = value;
                RaisePropertyChanged("BBadresszusatz");
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

        private string _BBplz;
        public string BBplz
        {
            get
            {
                return _BBplz;
            }
            set
            {
                _BBplz = value;
                RaisePropertyChanged("BBplz");
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

        private string _BBwohnort;
        public string BBwohnort
        {
            get
            {
                return _BBwohnort;
            }
            set
            {
                _BBwohnort = value;
                RaisePropertyChanged("BBwohnort");
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

        private string _BBtel1;
        public string BBtel1
        {
            get
            {
                return _BBtel1;
            }
            set
            {
                _BBtel1 = value;
                RaisePropertyChanged("BBtel1");
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

        private string _BBtel2;
        public string BBtel2
        {
            get
            {
                return _BBtel2;
            }
            set
            {
                _BBtel2 = value;
                RaisePropertyChanged("BBtel2");
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

        private string _BBtel3;
        public string BBtel3
        {
            get
            {
                return _BBtel3;
            }
            set
            {
                _BBtel3 = value;
                RaisePropertyChanged("BBtel3");
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

        private string _BBmail;
        public string BBmail
        {
            get
            {
                return _BBmail;
            }
            set
            {
                _BBmail = value;
                RaisePropertyChanged("BBmail");
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

        private string _BBhunde;
        public string BBhunde
        {
            get
            {
                return _BBhunde;
            }
            set
            {
                _BBhunde = value;
                RaisePropertyChanged("BBhunde");
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
        #endregion properties TextBoxen

    }
}
