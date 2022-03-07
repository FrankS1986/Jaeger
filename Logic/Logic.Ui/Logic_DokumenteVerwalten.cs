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
using GalaSoft.MvvmLight.Messaging;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_DokumenteVerwalten : ViewModelBase, INotifyPropertyChanged
    {
        DokumenteVerwaltenService serv = new DokumenteVerwaltenService();

        public Logic_DokumenteVerwalten()
        {
            Dokumente = serv.DokumenteListe();

            Messenger.Default.Register()

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
                RaisePropertyChanged("Dokumente");
            }
        }

        private string _selectDokument;
        public string SelectDokument
        {
            get
            {
                return _selectDokument;
            }

            set
            {
                _selectDokument = value;
                RaisePropertyChanged("SelectDokument");
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
                       if(SelectDokument != null)
                        {
                            serv.DokumenteLoeschen(SelectDokument);
                            Dokumente = serv.DokumenteListe();
                        }


                        
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
                        if (SelectDokument != null)
                        {
                            serv.DokumenteBearbeiten(SelectDokument);
                        }



                    });

                }
                return _dokumentBearbeiten;
            }
        }

    }

}
