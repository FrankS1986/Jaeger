using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace JaegerMeister.MvvmSample.Logic.Ui.ViewModels
{

    public class TermineViewModel: ViewModelBase, INotifyPropertyChanged
    {
        ICommand _btn_UebersichtTerminhinzufuegen, _btn_UebersichtLoeschen, _btn_hinzufuegen, _btn_entfernen, _btn_Abbruch, _btn_Bestaetigen, _btn_UebersichtRueckmeldungen;
        string _txt_UebersichtBezeichnung, _txt_UebersichtOrt, _txt_UebersichtUhrzeit, _txt_bezeichnung, _txt_Ort, _txt_Uhrzeit;
        DateTime _datepicker_UebersichtDatum, _datepicker_Datum;
        List<ClassListTermine> _list_UebersichtAnstehendeTermine;
        List<ClassListRueckmeldung> _list_UebersichtEingeladenePersonen;
        public List<ClassListTermine> List_UebersichtAnstehendeTermine
        {
            get
            {
                return _list_UebersichtAnstehendeTermine;
            }
            set
            {
                _list_UebersichtAnstehendeTermine = value;
            }
        }
        public List<ClassListRueckmeldung> List_UebersichtEingeladenePersonen
        {
            get
            {
                return _list_UebersichtEingeladenePersonen;
            }
            set
            {
                _list_UebersichtEingeladenePersonen = value;
            }
        }
        public List<ClassListRueckmeldung> List_personen
        {
            get
            {
                return _list_UebersichtEingeladenePersonen;
            }
            set
            {
                _list_UebersichtEingeladenePersonen = value;
            }
        }
        public List<ClassListRueckmeldung> List_einladung
        {
            get
            {
                return _list_UebersichtEingeladenePersonen;
            }
            set
            {
                _list_UebersichtEingeladenePersonen = value;
            }
        }
        public ICommand Btn_UebersichtRueckmeldungen
        {
            get
            {
                if (_btn_UebersichtRueckmeldungen==null)
                {
                    _btn_UebersichtRueckmeldungen = new RelayCommand(() =>
                    {

                    });
                }
                return _btn_UebersichtRueckmeldungen;
            }
        }

        public ICommand Btn_UebersichtTerminhinzufuegen
        {
            get
            {
                if (_btn_UebersichtTerminhinzufuegen == null)
                {
                    _btn_UebersichtTerminhinzufuegen = new RelayCommand(() =>
                    {
                        //WAS SOLL DER BUTTON TUN
                    });
                }
                return _btn_UebersichtTerminhinzufuegen;
            }
        }
        public ICommand Btn_UebersichtLoeschen
        {
            get
            {
                if (_btn_UebersichtLoeschen == null)
                {
                    _btn_UebersichtLoeschen = new RelayCommand(() =>
                    {
                        //WAS SOLL DER BUTTON TUN
                    });
                }
                return _btn_UebersichtLoeschen;
            }
        }
        public ICommand Btn_hinzufuegen
        {
            get
            {
                if (_btn_hinzufuegen == null)
                {
                    _btn_hinzufuegen = new RelayCommand(() =>
                    {
                        //WAS SOLL DER BUTTON TUN
                    });
                }
                return _btn_hinzufuegen;
            }
        }
        public ICommand Btn_entfernen
        {
            get
            {
                if (_btn_entfernen == null)
                {
                    _btn_entfernen = new RelayCommand(() =>
                    {
                        //WAS SOLL DER BUTTON TUN
                    });
                }
                return _btn_entfernen;
            }
        }
        public ICommand Btn_Abbruch
        {
            get
            {
                if (_btn_Abbruch == null)
                {
                    _btn_Abbruch = new RelayCommand(() =>
                    {
                        //WAS SOLL DER BUTTON TUN
                    });
                }
                return _btn_Abbruch;
            }
        }
        public ICommand Btn_Bestaetigen
        {
            get
            {
                if (_btn_Bestaetigen == null)
                {
                    _btn_Bestaetigen = new RelayCommand(() =>
                    {
                        //WAS SOLL DER BUTTON TUN
                    });
                }
                return _btn_Bestaetigen;
            }
        }
        public string Txt_UebersichtBezeichnung
        {
            get
            {
                return _txt_UebersichtBezeichnung;
            }
            set
            {
                _txt_UebersichtBezeichnung = value;
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
            }
        }
        public string Txt_UebersichtUhrzeit
        {
            get
            {
                return _txt_UebersichtUhrzeit;
            }
            set
            {
                _txt_UebersichtUhrzeit = value;
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

    public class ClassListTermine
    {
        public int ID { get; set; }
        public string Ort { get; set; }
        public DateTime Date { get; set; }
        public string Bezeichnung { get; set; }
        public string Typ { get; set; }
        public ClassListTermine(int id, string ort, DateTime date, string bezeichnung, string typ)
        {
            this.ID = id;
            this.Ort = ort;
            this.Date = date;
            this.Bezeichnung = bezeichnung;
            this.Typ = typ;
        }
    }
    public class ClassListRueckmeldung
    {
        public int ID { get; set; }
        public string Rolle { get; set; }
        public string Gaeste { get; set; }
        public int TerminID { get; set; }
        public int JaegerID { get; }
        public ClassListRueckmeldung(int id, string rolle, string gaeste, int terminID, int jaegerID)
        {
            this.ID = id;
            this.Rolle = rolle;
            this.Gaeste = gaeste;
            this.TerminID = terminID;
            this.JaegerID = jaegerID;
        }
    }
}