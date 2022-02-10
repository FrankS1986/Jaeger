using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class UrkundeErstellenViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _btn_Urkunden_erstellen;
        public ICommand btn_Urkunden_erstellen
        {
            get 
            {
                 if (_btn_Urkunden_erstellen==null)
                 {
                    _btn_Urkunden_erstellen = new RelayCommand(() =>
                    {
                        UrkundeErstellenViewModel logic = new UrkundeErstellenViewModel();
                    });
                 }
                return _btn_Urkunden_erstellen;
            }
        }

        private ICommand _btn_Abbrechen;
        public ICommand btn_Abbrechen
        {
            get
            {
                if (_btn_Abbrechen== null)
                {
                    _btn_Abbrechen = new RelayCommand(() =>
                    {
                        UrkundeErstellenViewModel logic = new UrkundeErstellenViewModel();
                    });
                }
                return _btn_Abbrechen;
            }
        }
        private ICommand _lb_UrkundenErhalten;
        public ICommand lb_UrkundenErhalten
        {
            get
            {
                if (_lb_UrkundenErhalten == null)
                {
                    _lb_UrkundenErhalten = new RelayCommand(() =>
                    {
                        UrkundeErstellenViewModel logic = new UrkundeErstellenViewModel();
                    });
                }
                return _lb_UrkundenErhalten;
            }
        }
        private ICommand _lb_JaegerListe;
        public ICommand lb_JaegerListe
        {
            get
            {
                if (_lb_JaegerListe == null)
                {
                    _lb_JaegerListe = new RelayCommand(() =>
                    {
                        UrkundeErstellenViewModel logic = new UrkundeErstellenViewModel();
                    });
                }
                return _lb_JaegerListe;
            }
        }
        private ICommand _btn_Jaeger_bewegen;
        public ICommand btn_Jaeger_bewegen
        {
            get
            {
                if (_btn_Jaeger_bewegen== null)
                {
                    _btn_Jaeger_bewegen = new RelayCommand(() =>
                    {
                        UrkundeErstellenViewModel logic = new UrkundeErstellenViewModel();
                    });
                }
                return _btn_Jaeger_bewegen;
            }
        }
    }
}
