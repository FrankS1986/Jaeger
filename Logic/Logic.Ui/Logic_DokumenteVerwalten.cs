using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_DokumenteVerwalten : ViewModelBase, INotifyPropertyChanged
    {
        private List<Dokumente> _listboxDokumnete;
        public List<Dokumente> listboxDokumente
        {
            get
            {
                return _listboxDokumnete;
            }

            set
            {
                _listboxDokumnete = value;
                RaisePropertyChanged("listboxDokumnete");
            }
        }

          public class Dokumente
        {
                 public int ID { get; set; }
                 public int Name { get; set; }
        }


        private ICommand _btn_dokumenteUnbenennen;
        public ICommand btn_dokumenteUnbenennen
        {
            get
            {
                if (_btn_dokumenteUnbenennen == null)
                {
                    _btn_dokumenteUnbenennen = new RelayCommand(() =>
                    {
                        Logic_DokumenteVerwalten logic = new Logic_DokumenteVerwalten();


                        
                    });

                }
                return _btn_dokumenteUnbenennen;
            }
        }

        private ICommand _btn_dokumentErsetzen;
        public ICommand btn_dokumentErsetzen
        {
            get
            {
                if (_btn_dokumentErsetzen == null)
                {
                    _btn_dokumentErsetzen = new RelayCommand(() =>
                    {
                        Logic_DokumenteVerwalten logic = new Logic_DokumenteVerwalten();



                    });

                }
                return _btn_dokumentErsetzen;
            }
        }

        private ICommand _btn_dokumentHizufuegen;
        public ICommand btn_dokumentHizufuegen
        {
            get
            {
                if (_btn_dokumentHizufuegen == null)
                {
                    _btn_dokumentHizufuegen = new RelayCommand(() =>
                    {
                        Logic_DokumenteVerwalten logic = new Logic_DokumenteVerwalten();



                    });

                }
                return _btn_dokumentHizufuegen;
            }
        }
        private ICommand _btn_dateipfad;
        public ICommand btn_dateipfad
        {
            get
            {
                if (_btn_dateipfad == null)
                {
                    _btn_dateipfad = new RelayCommand(() =>
                    {
                        Logic_DokumenteVerwalten logic = new Logic_DokumenteVerwalten();



                    });

                }
                return _btn_dateipfad;
            }
        }

        private string _textboxDateiName;
        public string textboxDateiName
        {
            get
            {
                return _textboxDateiName;
            }

            set
            {
                _textboxDateiName = value;
                RaisePropertyChanged("textboxDateiName");
            }
        }


    }

}
