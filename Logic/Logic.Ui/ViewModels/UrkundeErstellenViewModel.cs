using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace JaegerMeister.MvvmSample.Logic.Ui.ViewModels
{
    public class UrkundeErstellenViewModel: ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _btn_jaeger_bewegen;

        public ICommand Btn_jaeger_bewegen
        {
            get
            {
                if(_btn_jaeger_bewegen == null)
                {
                    _btn_jaeger_bewegen = new RelayCommand(() =>
                    {
                        UrkundeErstellenViewModel logic = new UrkundeErstellenViewModel();
                    });
                }
                return _btn_jaeger_bewegen;
            }
        }
        private ICommand _btn_abbrechen;

        public ICommand Btn_abbrechen
        {
            get
            {
                if (_btn_abbrechen == null)
                {
                    _btn_abbrechen = new RelayCommand(() =>
                    {
                        UrkundeErstellenViewModel logic = new UrkundeErstellenViewModel();
                    });
                }
                return _btn_abbrechen;
            }
        }
        private ICommand _btn_urkunden_erstellen;

        public ICommand Btn_urkunden_erstellen
        {
            get
            {
                if (_btn_urkunden_erstellen == null)
                {
                    _btn_urkunden_erstellen = new RelayCommand(() =>
                    {
                        UrkundeErstellenViewModel logic = new UrkundeErstellenViewModel();
                    });
                }
                return _btn_urkunden_erstellen;
            }
        }

        private string _dg_jaegerliste;

        public string Dg_jaegerliste
        {
            get
            {
                return _dg_jaegerliste;
            }
            set
            {
                _dg_jaegerliste = value;
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


    }
}
