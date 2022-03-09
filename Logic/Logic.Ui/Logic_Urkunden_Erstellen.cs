using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Dokumente;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using static JaegerMeister.MvvmSample.Logic.Ui.Services.UrkundenerstellenService;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Urkunden_Erstellen : ViewModelBase, INotifyPropertyChanged
    {

        UrkundenerstellenService serv = new UrkundenerstellenService();


        public Logic_Urkunden_Erstellen()
        {
            Termin = serv.TermineListe();
            Messenger.Default.Register<UrkundenErstellenErfolgsMessage>(this, (UrkundenErstellenErfolgsMessage loginProof) =>
            {
                if (loginProof.erfolg == true)
                {
                    if (SelectedTermin != null)
                    {
                        if (Jaegerliste != null)
                        {
                            Jaegerliste.Clear();
                        }
                        Jaegerliste = serv.Jaeger(SelectedTermin.Termine_ID);
                        if (Ehrungen != null)
                        {
                            Ehrungen.Clear();
                        }
                    }
                }

            });
        }
        private int _laden;
        public int Laden
        {
            get
            {
                return _laden;
            }

            set
            {
                _laden = value;
                RaisePropertyChanged("Laden");
            }
        }
        private ICommand _jaegerbewegen;

        public ICommand Jaegerbewegen
        {
            get
            {
                if (_jaegerbewegen == null)
                {
                    _jaegerbewegen = new RelayCommand(() =>
                    {

                        Ehrungen = serv.EhrungenErstellen(Jaegerliste);

                    });
                }
                return _jaegerbewegen;
            }
        }
        private ICommand _abbrechen;

        public ICommand Abbrechen
        {
            get
            {
                if (_abbrechen == null)
                {
                    _abbrechen = new RelayCommand(() =>
                    {


                    });
                }
                return _abbrechen;
            }
        }

         void Aufgabe()
        {
            Messenger.Default.Send<UrkundenErstellenProgressbarStartenMessage>(new UrkundenErstellenProgressbarStartenMessage { erfolg = true });
        }

        private ICommand _urkundenErstellen;

        public ICommand UrkundenErstellen
        {
            get
            {
                if (_urkundenErstellen == null)
                {
                    _urkundenErstellen = new RelayCommand(() =>
                    {
                        Aufgabe();
                       
                        
                        if (SelectedTermin != null)
                        {
                            int dokumente = Jaegerliste.Count();

                            int count = 0;
                            if (Ehrungen != null)
                            {
                                foreach (var i in Ehrungen)
                                {
                                    if (i.Standard)
                                    {
                                        count++;
                                    }
                                    if (i.Ehrenuhrkunde)
                                    {
                                        count++;
                                    }
                                }
                            }
                            int result = 100 / (count + dokumente);
                            
                            
                           

                            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + SelectedTermin.Bezeichnung + SelectedTermin.DatumUhrzeit.Year);
                            string ordner = SelectedTermin.Bezeichnung + SelectedTermin.DatumUhrzeit.Year;
                            foreach (var item in Jaegerliste)
                            {
                                
                                Laden += result;
                                
                                string x = SelectedTermin.DatumUhrzeit.Year.ToString();
                                string zusammengesetzt = SelectedTermin.Typ + x + item.Nachname + item.ID.ToString();
                                string str = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + ordner + "\\" + zusammengesetzt + ".docx";

                                serv.Erstellen(item, Paths.GetFilePath("Logic\\Logic.Ui\\Dokumente\\JaegerTeilnahmeurkunde.docx"), str);

                            }


                            if (Ehrungen != null)
                            {
                                foreach (var item in Ehrungen)
                                {
                                    if (item.Standard)
                                    {
                                        Laden += result;
                                        string x = SelectedTermin.DatumUhrzeit.Year.ToString();
                                        string zusammengesetzt = "StandardUrkunde" + SelectedTermin.Typ + x + item.Nachname + item.ID.ToString();
                                        string str = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + ordner + "\\" + zusammengesetzt + ".docx";

                                        serv.UrkundenErstellen(item, Paths.GetFilePath("Logic\\Logic.Ui\\Dokumente\\JaegerStandardehrung.docx"), str);
                                    }

                                    if (item.Ehrenuhrkunde)
                                    {
                                        Laden += result;
                                        string x = SelectedTermin.DatumUhrzeit.Year.ToString();
                                        string zusammengesetzt = "Ehrenuhrkunde" + SelectedTermin.Typ + x + item.Nachname + item.ID.ToString();
                                        string str = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + ordner + "\\" + zusammengesetzt + ".docx";

                                        serv.UrkundenErstellen(item, Paths.GetFilePath("Logic\\Logic.Ui\\Dokumente\\JaegerEhrenurkunde.docx"), str);
                                    }

                                }
                            }

                        }


                    });
                }
                return _urkundenErstellen;
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


        private Teilname _selectedJaeger;

        public Teilname SelectedJaeger
        {
            get
            {
                return _selectedJaeger;
            }
            set
            {
                _selectedJaeger = value;
                RaisePropertyChanged("SelectedJaeger");
            }
        }



        private string _dg_urkunden_erhalten;

        public string Dg_urkunden_erhalten
        {
            get
            {
                return _dg_urkunden_erhalten;
            }
            set
            {
                _dg_urkunden_erhalten = value;
            }
        }

        private List<tbl_Termine> _termine;
        public List<tbl_Termine> Termin
        {
            get
            {
                return _termine;
            }

            set
            {
                _termine = value;
                RaisePropertyChanged("Termin");
            }
        }

        private List<Teilname> _jaegerliste;
        public List<Teilname> Jaegerliste
        {
            get
            {
                return _jaegerliste;
            }

            set
            {
                _jaegerliste = value;
                RaisePropertyChanged("Jaegerliste");
            }
        }

        private List<Urkunden> _ehrungen;
        public List<Urkunden> Ehrungen
        {
            get
            {
                return _ehrungen;
            }

            set
            {
                _ehrungen = value;
                RaisePropertyChanged("Ehrungen");
            }
        }

    }
}
