using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{

    public class Logic_Termine : ViewModelBase, INotifyPropertyChanged
    {
        TerminUebersichtService ueber = new TerminUebersichtService();
        TerminErstellenService erstell = new TerminErstellenService();
        public class Type
        {
            private string typ;
            public string Typ
            {
                get
                {
                    return typ;
                }
                set
                {
                    typ = value;
                }
            }
        }
        private ObservableCollection<Type> typ;
        public ObservableCollection<Type> Typ
        {
            get
            {
                return typ;
            }
            set
            {
                typ = value;
            }
        }
        private Type selectedType;
        public Type SelectedTyp
        {
            get
            {
                return selectedType;
            }
            set
            {
                selectedType = value;
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
                    UebersichtAnstehendeTermine = ueber.TerminUebersicht();
                    //ueber.AutoDeleteTermin();
                }
                else if (prop.Equals("Select"))
                {
                    if (SelectedTermin != null)
                    {
                        UebersichtBezeichnung = SelectedTermin.Bezeichnung;
                        UebersichtOrt = SelectedTermin.Ort;
                        UebersichtDatum = SelectedTermin.DatumUhrzeit.ToString("f");
                        UebersichtEingeladenePersonen = ueber.EingeladenePersonen(SelectedTermin.Termine_ID);
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
                        ErstellBezeichnung = SelectedTermin.Bezeichnung;
                        ErstellOrt = SelectedTermin.Ort;
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
                        ErstellDatum = Convert.ToDateTime(zeit[0]);
                        ErstellUhrzeit = zeit[1];
                    }
                }
                else if (prop.Equals("Abbruch"))
                {
                    id = 0;
                    ErstellBezeichnung = "";
                    ErstellOrt = "";
                    SelectedTyp = null;
                    ErstellDatum = DateTime.Today;
                    ErstellUhrzeit = "";
                }
                else if (prop.Equals("Termin"))
                {
                    ErstellDatum = DateTime.Today;
                }
            });
        }
        public int id = 0;

        private List<tbl_Termine> uebersichtAnstehendeTermine;
        public List<tbl_Termine> UebersichtAnstehendeTermine
        {
            get
            {
                return uebersichtAnstehendeTermine;
            }
            set
            {
                uebersichtAnstehendeTermine = value;
                RaisePropertyChanged("UebersichtAnstehendeTermine");
            }
        }

        private tbl_Termine selectedTermin;
        public tbl_Termine SelectedTermin
        {
            get
            {
                return selectedTermin;
            }

            set
            {
                selectedTermin = value;
                RaisePropertyChanged("SelectedTermin");
            }
        }
        private List<tbl_Jaeger> uebersichtEingeladenePersonen;
        public List<tbl_Jaeger> UebersichtEingeladenePersonen
        {
            get
            {
                return uebersichtEingeladenePersonen;
            }
            set
            {
                uebersichtEingeladenePersonen = value;
                RaisePropertyChanged("UebersichtEingeladenePersonen");
            }
        }
        private ICommand uebersichtRueckmeldungen;
        public ICommand UebersichtRueckmeldungen
        {
            get
            {
                if (uebersichtRueckmeldungen == null)
                {
                    uebersichtRueckmeldungen = new RelayCommand(() =>
                    {

                    });
                }
                return uebersichtRueckmeldungen;
            }
        }

        private ICommand uebersichtTerminhinzufuegen;
        public ICommand UebersichtTerminhinzufuegen
        {
            get
            {
                if (uebersichtTerminhinzufuegen == null)
                {
                    uebersichtTerminhinzufuegen = new RelayCommand(() =>
                    {

                    });
                }
                return uebersichtTerminhinzufuegen;
            }
        }
        private ICommand uebersichtLoeschen;
        public ICommand UebersichtLoeschen
        {
            get
            {
                if (uebersichtLoeschen == null)
                {
                    uebersichtLoeschen = new RelayCommand(() =>
                    {
                        var result = MessageBox.Show("Möchten Sie wirklich den Termin '" + SelectedTermin.Bezeichnung + "' löschen?", "Termin löschen?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                        if (result == MessageBoxResult.Yes)
                        {
                            if (ueber.TerminLoeschen(SelectedTermin.Termine_ID))
                            {
                                MessageBox.Show("Der Termin '" + SelectedTermin.Bezeichnung + "' wurde gelöscht.");
                                Messenger.Default.Send("Termine");
                            }
                            else
                            {
                                MessageBox.Show("Der Termin '" + SelectedTermin.Bezeichnung + "' kann nicht gelöscht werden!");
                            }
                        }
                    });
                }
                return uebersichtLoeschen;
            }
        }
        private ICommand uebersichtBearbeiten;
        public ICommand UebersichtBearbeiten
        {
            get
            {
                if (uebersichtBearbeiten == null)
                {
                    uebersichtBearbeiten = new RelayCommand(() =>
                    {

                    });
                }
                return uebersichtBearbeiten;
            }
        }
        private ICommand abbruch;
        public ICommand Abbruch
        {
            get
            {
                if (abbruch == null)
                {
                    abbruch = new RelayCommand(() =>
                    {

                    });
                }
                return abbruch;
            }
        }
        private ICommand bestaetigen;
        public ICommand Bestaetigen
        {
            get
            {
                if (bestaetigen == null)
                {
                    bestaetigen = new RelayCommand(() =>
                    {
                        if (ErstellBezeichnung == null || ErstellOrt == null || SelectedTyp == null || ErstellUhrzeit == null)
                        {
                            MessageBox.Show("Bitte füllen Sie alle Felder aus!");
                        }
                        else
                        {
                            if (erstell.TerminErstellen(id, ErstellBezeichnung, ErstellOrt, ErstellUhrzeit, SelectedTyp.Typ, ErstellDatum))
                            {
                                Messenger.Default.Send("Richtig");
                                UebersichtBezeichnung = "";
                                UebersichtOrt = "";
                                UebersichtDatum = "";
                                ErstellBezeichnung = "";
                                ErstellOrt = "";
                                SelectedTyp = null;
                                ErstellDatum = DateTime.Today;
                                ErstellUhrzeit = "";
                            }
                        }
                    });
                }
                return bestaetigen;
            }
        }
        private string uebersichtBezeichnung;
        public string UebersichtBezeichnung
        {
            get
            {
                return uebersichtBezeichnung;
            }
            set
            {
                uebersichtBezeichnung = value;
                RaisePropertyChanged("UebersichtBezeichnung");
            }
        }
        private string uebersichtOrt;
        public string UebersichtOrt
        {
            get
            {
                return uebersichtOrt;
            }
            set
            {
                uebersichtOrt = value;
                RaisePropertyChanged("UebersichtOrt");
            }
        }
        private string uebersichtDatum;
        public string UebersichtDatum
        {
            get
            {
                return uebersichtDatum;
            }
            set
            {
                uebersichtDatum = value;
                RaisePropertyChanged("UebersichtDatum");
            }
        }
        private string erstellBezeichnung;
        public string ErstellBezeichnung
        {
            get
            {
                return erstellBezeichnung;
            }
            set
            {
                erstellBezeichnung = value;
                RaisePropertyChanged("ErstellBezeichnung");
            }
        }
        private string erstellOrt;
        public string ErstellOrt
        {
            get
            {
                return erstellOrt;
            }
            set
            {
                erstellOrt = value;
                RaisePropertyChanged("ErstellOrt");
            }
        }
        private DateTime erstellDatum;
        public DateTime ErstellDatum
        {
            get
            {
                return erstellDatum;
            }
            set
            {
                erstellDatum = value;
                RaisePropertyChanged("ErstellDatum");
            }
        }
        private string erstellUhrzeit;
        public string ErstellUhrzeit
        {
            get
            {
                return erstellUhrzeit;
            }
            set
            {
                erstellUhrzeit = value;
                RaisePropertyChanged("ErstellUhrzeit");
            }
        }
    }
}