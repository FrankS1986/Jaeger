using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using JaegerMeister.MvvmSample.Logic.Ui.Services;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_DokumenteVerwalten : ViewModelBase, INotifyPropertyChanged
    {
        DokumenteVerwaltenService serv = new DokumenteVerwaltenService();

        public Logic_DokumenteVerwalten()
        {
            Dokumente = serv.DokumenteListe();

        }


        private List<string> _dokumente;
        public List<string> Dokumente
        {
            get
            {
                return _dokumente;
            }

            set
            {
                _dokumente = value;
                RaisePropertyChanged("Dokumnete");
            }
        }

        


        private ICommand _dokumentloeschen;
        public ICommand Dokumentloeschen
        {
            get
            {
                if (_dokumentloeschen == null)
                {
                    _dokumentloeschen = new RelayCommand(() =>
                    {
                        Logic_DokumenteVerwalten logic = new Logic_DokumenteVerwalten();


                        
                    });

                }
                return _dokumentloeschen;
            }
        }

        private ICommand _dokumentBearbeiten;
        public ICommand DokumentBearbeiten
        {
            get
            {
                if (_dokumentBearbeiten == null)
                {
                    _dokumentBearbeiten = new RelayCommand(() =>
                    {
                        Logic_DokumenteVerwalten logic = new Logic_DokumenteVerwalten();



                    });

                }
                return _dokumentBearbeiten;
            }
        }

        private ICommand _dokumentHizufuegen;
        public ICommand DokumentHizufuegen
        {
            get
            {
                if (_dokumentHizufuegen == null)
                {
                    _dokumentHizufuegen = new RelayCommand(() =>
                    {
                        Logic_DokumenteVerwalten logic = new Logic_DokumenteVerwalten();



                    });

                }
                return _dokumentHizufuegen;
            }
        }



        private ICommand _dateipfad;
        public ICommand Dateipfad
        {
            get
            {
                if (_dateipfad == null)
                {
                    _dateipfad = new RelayCommand(() =>
                    {
                        Logic_DokumenteVerwalten logic = new Logic_DokumenteVerwalten();



                    });

                }
                return _dateipfad;
            }
        }

    }

}
