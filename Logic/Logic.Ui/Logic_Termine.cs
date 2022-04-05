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
        int id = 0;
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
        private ObservableCollection<Type> terminTyp;
        public ObservableCollection<Type> TerminTyp
        {
            get
            {
                return terminTyp;
            }
            set
            {
                terminTyp = value;
            }
        }
        private Type selectedTerminTyp;
        public Type SelectedTerminTyp
        {
            get
            {
                return selectedTerminTyp;
            }
            set
            {
                selectedTerminTyp = value;
            }
        }
        public Logic_Termine()
        {
            TerminTyp = new ObservableCollection<Type>()
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
                }
                ///<summary>
                ///Bei der Auswahl eines Termines werden die entsprechenden Informationen in Textboxen dargestellt.
                ///</summary>
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
                ///<summary>
                ///Nimmt die Informationen vom ausgewählten Termin und packt diese in die entsprechenden Boxen.
                ///</summary>
                else if (prop.Equals("Bearbeiten"))
                {
                    if (SelectedTermin != null)
                    {
                        id = SelectedTermin.Termine_ID;
                        ErstellBezeichnung = SelectedTermin.Bezeichnung;
                        ErstellOrt = SelectedTermin.Ort;
                        foreach (var typ in TerminTyp)
                        {
                            if (typ.Typ == SelectedTermin.Typ)
                            {
                                SelectedTerminTyp = typ;
                                break;
                            }
                        }
                        string[] zeit = SelectedTermin.DatumUhrzeit.ToString().Split();
                        ErstellDatum = Convert.ToDateTime(zeit[0]);
                        ErstellUhrzeit = zeit[1];
                    }
                }
                ///<summary>
                ///Beim Abbruch werden die Felder im Erstellen-Fenster geleert.
                ///</summary>
                else if (prop.Equals("Abbruch"))
                {
                    id = 0;
                    ErstellBezeichnung = "";
                    ErstellOrt = "";
                    SelectedTerminTyp = null;
                    ErstellDatum = DateTime.Today;
                    ErstellUhrzeit = "";
                }
                else if (prop.Equals("Termin"))
                {
                    ErstellDatum = DateTime.Today;
                }
            });
        }

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
        /// <summary>
        /// Prüft, ob es möglich ist, den Termin zu löschen.
        /// </summary>
        private ICommand uebersichtLoeschen;
        public ICommand UebersichtLoeschen
        {
            get
            {
                if (uebersichtLoeschen == null)
                {
                    uebersichtLoeschen = new RelayCommand(() =>
                    {
                        MessageBoxResult checkDelete = MessageBox.Show("Möchten Sie wirklich den Termin '" + SelectedTermin.Bezeichnung + "' löschen?", "Termin löschen?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                        if (checkDelete == MessageBoxResult.Yes)
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
                        if (ErstellBezeichnung == null || ErstellOrt == null || SelectedTerminTyp == null || ErstellUhrzeit == null)
                        {
                            MessageBox.Show("Bitte füllen Sie alle Felder aus!");
                        }
                        else
                        {
                            if (erstell.TerminErstellen(id, ErstellBezeichnung, ErstellOrt, ErstellUhrzeit, SelectedTerminTyp.Typ, ErstellDatum))
                            {
                                Messenger.Default.Send("Richtig");
                                UebersichtBezeichnung = "";
                                UebersichtOrt = "";
                                UebersichtDatum = "";
                                ErstellBezeichnung = "";
                                ErstellOrt = "";
                                SelectedTerminTyp = null;
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