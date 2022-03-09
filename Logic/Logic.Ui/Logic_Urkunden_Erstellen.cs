using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
                        Jaegerliste.Clear();
                        Jaegerliste = serv.Jaeger(SelectedTermin.Termine_ID);
                        Ehrungen.Clear();
                    }
                }

            });
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
