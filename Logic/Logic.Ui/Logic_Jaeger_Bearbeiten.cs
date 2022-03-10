using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;

namespace JaegerMeister.MvvmSample.Logic.Ui
{

    public class Logic_Jaeger_Bearbeiten : ViewModelBase, INotifyPropertyChanged
    {
        //initiert Service Klasse zum Bearbeiten des Jägers
        JaegerBearbeitenService servEdit = new JaegerBearbeitenService();

        JaegerHinzufuegenService serv = new JaegerHinzufuegenService();

        public Logic_Jaeger_Bearbeiten()
        {
            //Aufgabe = serv.Funktionen();
            //Anrede = serv.Anrede();

            Messenger.Default.Register<string>(this, (prop) =>
            {

                if (prop.Equals("Jaeger"))
                {
                    //Ruft Methode zum Daten in Liste speichern auf und stellt sie im DataGrid dar
                    Lb_jaeger = servEdit.GetJaegerInfoList();
                }
                else if (prop.Equals("Select"))
                {
                    //wird ein Jäger in der Liste ausgewählt, werden seine Infos übernommen und in den Boxen dargestellt
                    if (SelectedItemJaeger != null)
                    {
                        Tb_vorname = SelectedItemJaeger.Vorname;
                        Tb_nachname = SelectedItemJaeger.Nachname;
                        Cb_anrede = SelectedItemJaeger.Anrede;
                        Dp_geburtstag = (DateTime)SelectedItemJaeger.Geburtsdatum;
                        Tb_straße = SelectedItemJaeger.Straße;
                        Tb_hausnummer = SelectedItemJaeger.Hausnummer;
                        Tb_adresszusatz = SelectedItemJaeger.Adresszusatz;
                        Tb_postleitzahl = SelectedItemJaeger.Postleitzahl;
                        Tb_wohnort = SelectedItemJaeger.Wohnort;
                        Tb_telefonnummer1 = SelectedItemJaeger.Telefonnummer1;
                        Tb_telefonnummer2 = SelectedItemJaeger.Telefonnummer2;
                        Tb_telefonnummer3 = SelectedItemJaeger.Telefonnummer3;
                        Tb_email = SelectedItemJaeger.Email;
                        Cb_funktion = SelectedItemJaeger.Funktion;
                        Tb_jagdhunde = SelectedItemJaeger.Jagdhund;

                    }
                }
                else if (prop.Equals("Change"))
                {
                    //beim wechsel des ContentControls wild die Jägerauswahl entfernt & die Boxen zurückgesetzt
                    SelectedItemJaeger = null;

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


        private ICommand _btn_jaeger_entfernen;

        public ICommand Btn_jaeger_entfernen
        {
            get
            {
                if (_btn_jaeger_entfernen == null)
                {
                    _btn_jaeger_entfernen = new RelayCommand(() =>
                    {
                        if (SelectedItemJaeger != null)
                        {
                            var result = MessageBox.Show("Soll der Jäger'" + SelectedItemJaeger.Vorname + " '" + SelectedItemJaeger.Nachname + "' wirklich gelöscht werden?", "Jäger löschen?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                            if (result == MessageBoxResult.Yes)
                            {
                                MessageBox.Show("Der Jäger '" + SelectedItemJaeger.Vorname + "' '" + SelectedItemJaeger.Nachname + "' wurde gelöscht.");
                                servEdit.DeleteJaeger(SelectedItemJaeger.Jäger_ID);
                                Messenger.Default.Send("Jaeger");
                            }
                        }


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
                        if (SelectedItemJaeger != null)
                        {
                            if (!string.IsNullOrEmpty(Tb_vorname) && !string.IsNullOrEmpty(Tb_nachname) && !string.IsNullOrEmpty(Tb_straße) && !string.IsNullOrEmpty(Tb_hausnummer) && !string.IsNullOrEmpty(Tb_postleitzahl) && !string.IsNullOrEmpty(Tb_wohnort) && !string.IsNullOrEmpty(Tb_telefonnummer1) && Cb_anrede != null)
                            {
                                var newItem = new tbl_Jaeger()
                                {
                                    Anrede = Cb_anrede,
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
                                    Funktion = Cb_funktion,
                                    Jagdhund = Tb_jagdhunde
                                };

                                Messenger.Default.Send<JaegerBearbeitenErfolgsMessage>(new JaegerBearbeitenErfolgsMessage { JaegerBearbeitenErfolg = servEdit.OverwriteJaegerInfo(newItem, SelectedItemJaeger.Jäger_ID) });
                            }
                        }
                    });
                }
                return _btn_bestaetigen;
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

        //private tbl_Anrede _cb_anrede;
        //public tbl_Anrede Cb_anrede
        //{
        //    get
        //    {
        //        return _cb_anrede;
        //    }
        //    set
        //    {
        //        _cb_anrede = value;
        //        RaisePropertyChanged("Cb_anrede");
        //    }
        //}

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

        public string Cb_funktion
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
