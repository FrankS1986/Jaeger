using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using JaegerMeister.MvvmSample.Logic.Ui.Dokumente;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_EinladungErstellen : ViewModelBase, INotifyPropertyChanged
    {

        EinladungenErstellenService serv = new EinladungenErstellenService();


        public Logic_EinladungErstellen()
        {
          Termine = serv.Termine();
          Einladen=  serv.JaegerListe();

         
        }

        private bool _IsSelected;
        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                _IsSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }
        private ICommand _EinlandungSenden;
        public ICommand EinlandungSenden
        {
            get
            {
                if (_EinlandungSenden == null)
                {
                    _EinlandungSenden = new RelayCommand(() =>
                    {

                        

                        


                        if (SelectEinladen != null)
                        {
                            serv.CreateWordDocument(Paths.GetFilePath("Logic\\Logic.Ui\\Dokumente\\JaegerEinladung.docx"), Paths.GetFilePath("Logic\\Logic.Ui\\Dokumente\\.docx"), 3);
                        }

                    });
                }
                return _EinlandungSenden;
            }
        }

        
        private ICommand _Abbrechen;
        public ICommand Abbrechen
        {
            get
            {
                if (_Abbrechen == null)
                {
                    _Abbrechen = new RelayCommand(() =>
                    {


                        ///Logic
                    });
                }
                return _Abbrechen;
            }
        }

        private ICommand _Com;
        public ICommand Com
        {
            get
            {
                if (_Com == null)
                {
                    _Com = new RelayCommand(() =>
                    {


                        ///Logic
                    });
                }
                return _Com;
            }
        }

        private List<tbl_Termine> _Termine ;
        public List<tbl_Termine> Termine
        {
            get
            { return _Termine;
 }
            set
            {
                _Termine = value;
                RaisePropertyChanged("Termine");
            }
        }

        private tbl_Termine _SelectTermin;
        public tbl_Termine SelectTermin
        {
            get
            {
                return _SelectTermin;
            }
            set
            {
                _SelectTermin = value;
                RaisePropertyChanged("SelectTermin");
            }
        }


        private List<tbl_Jaeger> _Einladen;
        public List<tbl_Jaeger> Einladen
        {
            get
            {
                return _Einladen;
            }
            set
            {
                _Einladen = value;
                RaisePropertyChanged("Einladen");
            }
        }

        private List<tbl_Jaeger> _SelectEinladen;
        public List<tbl_Jaeger> SelectEinladen
        {
            get
            {
                return _SelectEinladen;
            }
            set
            {
                _SelectEinladen = value;
                RaisePropertyChanged("SelectEinladen");
            }
        }

    }
}
