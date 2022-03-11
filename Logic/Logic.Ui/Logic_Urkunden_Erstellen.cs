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

        /// <summary>
        /// Leert die Listen
        /// </summary>
        public Logic_Urkunden_Erstellen()
        {
            Termin = serv.TermineListe();
            Messenger.Default.Register<UrkundenErstellenErfolgsMessage>(this, (UrkundenErstellenErfolgsMessage loginProof) =>
            {
                if (loginProof.Erfolg == true)
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



        private ICommand _urkundenErstellen;

        public ICommand UrkundenErstellen
        {
            get
            {
                if (_urkundenErstellen == null)
                {
                    _urkundenErstellen = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<UrkundenErstellenProgressbarStartenMessage>(new UrkundenErstellenProgressbarStartenMessage { Erfolg = true });


                        if (SelectedTermin != null)
                        {

                            // Hier wird ein Thread erstellt der den Fortschritt der Dokumente erstellung übergibt
                            BackgroundWorker worker = new BackgroundWorker();
                            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
                            worker.WorkerReportsProgress = true;
                            worker.DoWork += worker_DoWork;
                            worker.ProgressChanged += worker_ProgressChanged;
                            worker.RunWorkerAsync();




                        }


                    });
                }
                return _urkundenErstellen;
            }
        }

        /// <summary>
        /// Übergibt den Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            Laden = e.ProgressPercentage;

        }
        /// <summary>
        /// Erstellt Dokumente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int anzahlDokumente = Jaegerliste.Count();

            int count = 0;
            if (Ehrungen != null)
            {
                foreach (var i in Ehrungen)
                {
                    if (i.Standard)
                    {
                        count++;
                    }
                    if (i.Ehrenurkunde)
                    {
                        count++;
                    }
                }
            }
            int result = 100 / (count + anzahlDokumente);

            var worker = sender as BackgroundWorker;
            worker.ReportProgress(0);
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + SelectedTermin.Typ + SelectedTermin.DatumUhrzeit.Year);
            string ordner = SelectedTermin.Typ + SelectedTermin.DatumUhrzeit.Year;
            foreach (var item in Jaegerliste)
            {


                worker.ReportProgress(Laden += result);

                string datum = SelectedTermin.DatumUhrzeit.Year.ToString();
                string zusammengesetzt = SelectedTermin.Typ + datum + item.Nachname + item.ID.ToString();
                string speicherort = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + ordner + "\\" + zusammengesetzt + ".docx";

                serv.Erstellen(item, Paths.GetFilePath("Logic\\Logic.Ui\\Dokumente\\JaegerTeilnahmeurkunde.docx"), speicherort);

            }


            if (Ehrungen != null)
            {
                foreach (var item in Ehrungen)
                {    //Überprüft den ob ein Hacken gesetzt wurde oder nicht
                    if (item.Standard)
                    {
                        worker.ReportProgress(Laden += result);
                       
                        string datum = SelectedTermin.DatumUhrzeit.Year.ToString();
                        string zusammengesetzt = "StandardUrkunde" + SelectedTermin.Typ + datum + item.Nachname + item.ID.ToString();
                        string speicherort = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + ordner + "\\" + zusammengesetzt + ".docx";

                        serv.UrkundenErstellen(item, Paths.GetFilePath("Logic\\Logic.Ui\\Dokumente\\JaegerStandardehrung.docx"), speicherort);
                    }
                    //Überprüft den ob ein Hacken gesetzt wurde oder nicht
                    if (item.Ehrenurkunde)
                    {
                        worker.ReportProgress(Laden += result);

                        string datum = SelectedTermin.DatumUhrzeit.Year.ToString();
                        string zusammengesetzt = "Ehrenurkunde" + SelectedTermin.Typ + datum + item.Nachname + item.ID.ToString();
                        string speicherort = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + ordner + "\\" + zusammengesetzt + ".docx";

                        serv.UrkundenErstellen(item, Paths.GetFilePath("Logic\\Logic.Ui\\Dokumente\\JaegerEhrenurkunde.docx"), speicherort);
                    }

                }
            }

            worker.ReportProgress(100);
        }
        /// <summary>
        /// Sendet eine Nachricht wenn alle Dokumente erstellt wurden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Laden = 100;
            Messenger.Default.Send<ProgressbarValueMessage>(new ProgressbarValueMessage { });

            Laden = 0;

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
