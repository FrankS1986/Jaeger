﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{

    public class Logic_Termine : ViewModelBase, INotifyPropertyChanged
    {
        TerminUebersichtService serv = new TerminUebersichtService();

        public Logic_Termine()
        {
            Messenger.Default.Register<string>(this, (prop) =>
            {
                if(prop.Equals("Termine"))
                {
                    //<summary>
                    //Die Liste wird mit allen aktuellen Terminen gefüllt.
                    //</summary>
                    List_UebersichtAnstehendeTermine = serv.TerminUebersicht();
                }
                else if (prop.Equals("Select"))
                {
                    //<summary>
                    //Wenn man einen Termin anklickt, gibt er die entsprechenden Informationen an die Textboxen und der Liste weiter.
                    //</summary>
                    if (SelectedTermin != null)
                    {
                        Txt_UebersichtBezeichnung = SelectedTermin.Bezeichnung;
                        Txt_UebersichtOrt = SelectedTermin.Ort;
                        Txt_UebersichtDatum = SelectedTermin.DatumUhrzeit.ToString("g");
                        List_UebersichtEingeladenePersonen = serv.Personen(SelectedTermin.Termine_ID);
                    }
                }
                else if (prop.Equals("Change"))
                {
                    //<summary
                    //Wenn man den ContentControl wechselt, wird der ausgewählte Termin entfernt.
                    //</summary>
                    SelectedTermin = null;
                }
            });
        }
        private string _txt_UebersichtOrt, _txt_UebersichtDatum, _txt_bezeichnung, _txt_Ort, _txt_Uhrzeit;
        private DateTime _datepicker_UebersichtDatum, _datepicker_Datum;

        private List<tbl_Termine> _list_UebersichtAnstehendeTermine;
        public List<tbl_Termine> List_UebersichtAnstehendeTermine
        {
            get
            {
                return _list_UebersichtAnstehendeTermine;
            }
            set
            {
                _list_UebersichtAnstehendeTermine = value;
                RaisePropertyChanged("List_UebersichtAnstehendeTermine");
            }
        }

        private tbl_Termine _selectedTermin;
        public tbl_Termine SelectedTermin
        {
            get
            {
                return _selectedTermin;
            }

            set
            {
                _selectedTermin = value;
                RaisePropertyChanged("SelectedTermin");
            }
        }

        private List<tbl_Jaeger> _list_UebersichtEingeladenePersonen;
        public List<tbl_Jaeger> List_UebersichtEingeladenePersonen
        {
            get
            {
                return _list_UebersichtEingeladenePersonen;
            }
            set
            {
                _list_UebersichtEingeladenePersonen = value;
                RaisePropertyChanged("List_UebersichtEingeladenePersonen");
            }
        }
        private ICommand _btn_UebersichtRueckmeldungen;
        public ICommand Btn_UebersichtRueckmeldungen
        {
            get
            {
                if (_btn_UebersichtRueckmeldungen == null)
                {
                    _btn_UebersichtRueckmeldungen = new RelayCommand(() =>
                    {

                    });
                }
                return _btn_UebersichtRueckmeldungen;
            }
        }

        private ICommand _btn_UebersichtTerminhinzufuegen;
        public ICommand Btn_UebersichtTerminhinzufuegen
        {
            get
            {
                if (_btn_UebersichtTerminhinzufuegen == null)
                {
                    _btn_UebersichtTerminhinzufuegen = new RelayCommand(() =>
                    {
                        
                    });
                }
                return _btn_UebersichtTerminhinzufuegen;
            }
        }
        private ICommand _btn_UebersichtLoeschen;
        public ICommand Btn_UebersichtLoeschen
        {
            get
            {
                if (_btn_UebersichtLoeschen == null)
                {
                    _btn_UebersichtLoeschen = new RelayCommand(() =>
                    {
                        //<summary>
                        //Wenn man einen Termin ausgewählt hat, wird dieser aus der Datenbank entfernt.
                        //</summary>
                        if (SelectedTermin != null)
                        {
                            var result = MessageBox.Show("Möchten Sie wirklich den Termin '" + SelectedTermin.Bezeichnung + "' löschen?", "Termin löschen?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                            if (result == MessageBoxResult.Yes)
                            {
                                MessageBox.Show("Der Termin '" + SelectedTermin.Bezeichnung + "' wurde gelöscht.");
                                serv.TerminLoeschen(SelectedTermin.Termine_ID);
                                Messenger.Default.Send("Termine");
                            }
                        } 
                    });
                }
                return _btn_UebersichtLoeschen;
            }
        }
        private ICommand _btn_UebersichtBearbeiten;
        public ICommand Btn_UebersichtBearbeiten
        {
            get
            {
                if (_btn_UebersichtBearbeiten == null)
                {
                    _btn_UebersichtBearbeiten = new RelayCommand(() =>
                    {
                        if (SelectedTermin != null)
                        {

                        }
                    });
                }
                return _btn_UebersichtBearbeiten;
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
        private ICommand _btn_entfernen;
        public ICommand Btn_entfernen
        {
            get
            {
                if (_btn_entfernen == null)
                {
                    _btn_entfernen = new RelayCommand(() =>
                    {
                        
                    });
                }
                return _btn_entfernen;
            }
        }
        private ICommand _btn_Abbruch;
        public ICommand Btn_Abbruch
        {
            get
            {
                if (_btn_Abbruch == null)
                {
                    _btn_Abbruch = new RelayCommand(() =>
                    {
                        
                    });
                }
                return _btn_Abbruch;
            }
        }
        private ICommand _btn_Bestaetigen;
        public ICommand Btn_Bestaetigen
        {
            get
            {
                if (_btn_Bestaetigen == null)
                {
                    _btn_Bestaetigen = new RelayCommand(() =>
                    {
                        
                    });
                }
                return _btn_Bestaetigen;
            }
        }
        private string _bezeichnung;
        public string Bezeichnung
        {
            get
            {
                return _bezeichnung;
            }
            set
            {
                _bezeichnung = value;
            }
        }
        private string _txt_UebersichtBezeichnung;
        public string Txt_UebersichtBezeichnung
        {
            get
            {
                return _txt_UebersichtBezeichnung;
            }
            set
            {
                _txt_UebersichtBezeichnung = value;
                RaisePropertyChanged("Txt_UebersichtBezeichnung");
            }
        }
        public string Txt_UebersichtOrt
        {
            get
            {
                return _txt_UebersichtOrt;
            }
            set
            {
                _txt_UebersichtOrt = value;
                RaisePropertyChanged("Txt_UebersichtOrt");
            }
        }
        public string Txt_UebersichtDatum
        {
            get
            {
                return _txt_UebersichtDatum;
            }
            set
            {
                _txt_UebersichtDatum = value;
                RaisePropertyChanged("Txt_UebersichtDatum");
            }
        }
        public string Txt_bezeichnung
        {
            get
            {
                return _txt_bezeichnung;
            }
            set
            {
                _txt_bezeichnung = value;
            }
        }
        public string Txt_Ort
        {
            get
            {
                return _txt_Ort;
            }
            set
            {
                _txt_Ort = value;
            }
        }

        public string Txt_Uhrzeit
        {
            get
            {
                return _txt_Uhrzeit;
            }
            set
            {
                _txt_Uhrzeit = value;
            }
        }
        public DateTime Datepicker_UebersichtDatum
        {
            get
            {
                return _datepicker_UebersichtDatum;
            }
            set
            {
                _datepicker_UebersichtDatum = value;
            }
        }
        public DateTime Datepicker_Datum
        {
            get
            {
                return _datepicker_Datum;
            }
            set
            {
                _datepicker_Datum = value;
            }
        }

    }
}