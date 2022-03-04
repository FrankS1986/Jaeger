using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Models;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{

    public class Logic_Termine : ViewModelBase, INotifyPropertyChanged
    {
        TerminUebersichtService serv1 = new TerminUebersichtService();
        TerminErstellenService serv2 = new TerminErstellenService();

        public Logic_Termine()
        {
            Messenger.Default.Register<string>(this, (prop) =>
            {
                if (prop.Equals("Termine"))
                {
                    List_UebersichtAnstehendeTermine = serv1.terminUebersicht();
                }
                else if (prop.Equals("Personen"))
                {
                    List_Personen = serv2.Personen();
                }
                else if (prop.Equals("Select"))
                {
                    if (SelectedTermin != null)
                    {
                        Txt_UebersichtBezeichnung = SelectedTermin.Bezeichnung;
                        Txt_UebersichtOrt = SelectedTermin.Ort;
                        Txt_UebersichtDatum = SelectedTermin.DatumUhrzeit.ToString();
                        List_UebersichtEingeladenePersonen = serv1.Personen(SelectedTermin.Termine_ID);
                    }
                }
                else if (prop.Equals("Change"))
                {
                    SelectedTermin = null;
                }
                else if (prop.Equals("Hinzufuegen"))
                {
                    if (SelectedPerson != null)
                    {
                        List_einladung.Add(serv2.Einladung(SelectedPerson.Vorname, SelectedPerson.Nachname));
                    }
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

        private tbl_Jaeger _selectedPerson;

        public tbl_Jaeger SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
                RaisePropertyChanged("SelectedPerson");
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

        private List<tbl_Jaeger> _list_Personen;
        public List<tbl_Jaeger> List_Personen
        {
            get
            {
                return _list_Personen;
            }
            set
            {
                _list_Personen = value;
                RaisePropertyChanged("List_Personen");
            }
        }

        private List<tbl_Jaeger> _list_Einladung;
        public List<tbl_Jaeger> List_einladung
        {
            get
            {
                return _list_Einladung;
            }
            set
            {
                _list_Einladung = value;
                RaisePropertyChanged("List_einladung");
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
                        var result = MessageBox.Show("Möchten Sie wirklich den Termin '" + SelectedTermin.Bezeichnung + "' löschen?", "Termin löschen?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                        if (result == MessageBoxResult.Yes)
                        {
                            MessageBox.Show("Der Termin '" + SelectedTermin.Bezeichnung + "' wurde gelöscht.");
                            serv1.terminLoeschen(SelectedTermin.Termine_ID);
                            Messenger.Default.Send("Termine");
                        }
                        else if (result == MessageBoxResult.No)
                        {
                            MessageBox.Show("Der Termin '" + SelectedTermin.Bezeichnung + "' wird nicht gelöscht.");
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
                        Messenger.Default.Send("Hinzufuegen");
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

    //public class ClassListTermine
    //{
    //    public int ID { get; set; }
    //    public string Ort { get; set; }
    //    public DateTime Date { get; set; }
    //    public string Bezeichnung { get; set; }
    //    public string Typ { get; set; }
    //    public ClassListTermine(int id, string ort, DateTime date, string bezeichnung, string typ)
    //    {
    //        this.ID = id;
    //        this.Ort = ort;
    //        this.Date = date;
    //        this.Bezeichnung = bezeichnung;
    //        this.Typ = typ;
    //    }
    //}
    //public class ClassListRueckmeldung
    //{
    //    public int ID { get; set; }
    //    public string Rolle { get; set; }
    //    public string Gaeste { get; set; }
    //    public int TerminID { get; set; }
    //    public int JaegerID { get; }
    //    public ClassListRueckmeldung(int id, string rolle, string gaeste, int terminID, int jaegerID)
    //    {
    //        this.ID = id;
    //        this.Rolle = rolle;
    //        this.Gaeste = gaeste;
    //        this.TerminID = terminID;
    //        this.JaegerID = jaegerID;
    //    }
    //}
}