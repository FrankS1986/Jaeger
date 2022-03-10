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
        TerminUebersichtService ueber = new TerminUebersichtService();
        TerminErstellenService erstell = new TerminErstellenService();
        public class Type
        {
            private string _typ;
            public string Typ
            {
                get
                {
                    return _typ;
                }
                set
                {
                    _typ = value;
                }
            }
        }
        private ObservableCollection<Type> _typ;
        public ObservableCollection<Type> Typ
        {
            get
            {
                return _typ;
            }
            set
            {
                _typ = value;
            }
        }
        private Type _selectedTyp;
        public Type SelectedTyp
        {
            get
            {
                return _selectedTyp;
            }
            set
            {
                _selectedTyp = value;
            }
        }
        public Logic_Termine()
        {
            Typ = new ObservableCollection<Type>()
            {
                new Type() {Typ="Treibjagd"},
                new Type() {Typ="Geburtstag"},
                new Type() {Typ="Treffen"},
                new Type() {Typ="Versammlung"},
                new Type() {Typ="Sonstige"}
            };
            Messenger.Default.Register<string>(this, (prop) =>
            {
                if (prop.Equals("Termine"))
                {
                    List_UebersichtAnstehendeTermine = ueber.terminUebersicht();
                }
                else if (prop.Equals("Select"))
                {
                    if (SelectedTermin != null)
                    {
                        Txt_UebersichtBezeichnung = SelectedTermin.Bezeichnung;
                        Txt_UebersichtOrt = SelectedTermin.Ort;
                        Txt_UebersichtDatum = SelectedTermin.DatumUhrzeit.ToString();
                        List_UebersichtEingeladenePersonen = ueber.Personen(SelectedTermin.Termine_ID);
                    }
                }
                //<summary
                //Nimmt die Informationen vom ausgewählten Termin und packt diese in die entsprechenden Boxen.
                //</summary>
                else if (prop.Equals("Bearbeiten"))
                {
                    if (SelectedTermin != null)
                    {
                        int count = 0;
                        id = SelectedTermin.Termine_ID;
                        Txt_Bezeichnung = SelectedTermin.Bezeichnung;
                        Txt_Ort = SelectedTermin.Ort;
                        //<summary>
                        //Wenn der Termin-Typ vorhanden ist, wird dieser in der ComboBox ausgewählt. Wenn nicht, dann wird ein neuer Termin-Typ erstellt und dieser wird dann ausgewählt.
                        //</summary>
                        foreach (var item in Typ)
                        {
                            if (item.Typ == SelectedTermin.Typ)
                            {
                                SelectedTyp = item;
                                break;
                            }
                            else
                            {
                                count++;
                            }
                        }
                        if (count == Typ.Count)
                        {
                            Typ.Add(new Type() { Typ = SelectedTermin.Typ });
                            foreach (var item in Typ)
                            {
                                if (item.Typ == SelectedTermin.Typ)
                                {
                                    SelectedTyp = item;
                                    break;
                                }
                            }
                        }
                        string[] zeit = SelectedTermin.DatumUhrzeit.ToString().Split();
                        Datepicker_Datum = Convert.ToDateTime(zeit[0]);
                        Txt_Uhrzeit = zeit[1];
                    }
                }
                else if (prop.Equals("Abbruch"))
                {
                    id = 0;
                    Txt_Bezeichnung = "";
                    Txt_Ort = "";
                    SelectedTyp = null;
                    Datepicker_Datum = DateTime.Today;
                    Txt_Uhrzeit = "";
                }
                else if (prop.Equals("Termin"))
                {
                    Datepicker_Datum = DateTime.Today;
                }
            });
        }
        public int id = 0;

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
                        var result = MessageBox.Show("Möchten Sie wirklich den Termin '" + SelectedTermin.Bezeichnung + "' löschen?", "Termin löschen?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                        if (result == MessageBoxResult.Yes)
                        {
                            MessageBox.Show("Der Termin '" + SelectedTermin.Bezeichnung + "' wurde gelöscht.");
                            ueber.terminLoeschen(SelectedTermin.Termine_ID);
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
                        if (Txt_Bezeichnung == null || Txt_Ort == null || SelectedTyp == null || Txt_Uhrzeit == null)
                        {
                            MessageBox.Show("Bitte füllen Sie alle Felder aus!");
                        }
                        else
                        {
                            if (erstell.Termin(id, Txt_Bezeichnung, Txt_Ort, Txt_Uhrzeit, SelectedTyp.Typ, Datepicker_Datum))
                            {
                                Messenger.Default.Send("Richtig");
                                Txt_UebersichtBezeichnung = "";
                                Txt_UebersichtOrt = "";
                                Txt_UebersichtDatum = "";
                                Txt_Bezeichnung = "";
                                Txt_Ort = "";
                                SelectedTyp = null;
                                Datepicker_Datum = DateTime.Today;
                                Txt_Uhrzeit = "";
                            }
                        }
                    });
                }
                return _btn_Bestaetigen;
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
        private string _txt_UebersichtOrt;
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
        private string _txt_UebersichtDatum;
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
        private string _txt_bezeichnung;
        public string Txt_Bezeichnung
        {
            get
            {
                return _txt_bezeichnung;
            }
            set
            {
                _txt_bezeichnung = value;
                RaisePropertyChanged("Txt_Bezeichnung");
            }
        }
        private string _txt_Ort;
        public string Txt_Ort
        {
            get
            {
                return _txt_Ort;
            }
            set
            {
                _txt_Ort = value;
                RaisePropertyChanged("Txt_Ort");
            }
        }
        private string _txt_Typ;
        public string Txt_Typ
        {
            get
            {
                return _txt_Typ;
            }
            set
            {
                _txt_Typ = value;
                RaisePropertyChanged("Txt_Typ");
            }
        }
        private DateTime _datepicker_Datum;
        public DateTime Datepicker_Datum
        {
            get
            {
                return _datepicker_Datum;
            }
            set
            {
                _datepicker_Datum = value;
                RaisePropertyChanged("Datepicker_Datum");
            }
        }
        private string _txt_Uhrzeit;
        public string Txt_Uhrzeit
        {
            get
            {
                return _txt_Uhrzeit;
            }
            set
            {
                _txt_Uhrzeit = value;
                RaisePropertyChanged("Txt_Uhrzeit");
            }
        }
    }
}