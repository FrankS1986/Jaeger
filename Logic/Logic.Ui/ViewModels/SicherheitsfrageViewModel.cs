using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace JaegerMeister.MvvmSample.Logic.Ui.ViewModels
{
    public class SicherheitsfrageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _btn_bestaetigen;

        public ICommand btn_bestaetigen
        {
            get
            {
                if(_btn_bestaetigen==null)
                {
                    _btn_bestaetigen = new RelayCommand(() =>
                    {
                        SicherheitsfrageViewModel logic = new SicherheitsfrageViewModel();
                    });
                }
                return _btn_bestaetigen;
            }
        }
        private ICommand _btn_abbrechen;

        public ICommand btn_abbrechen
        {
            get
            {
                if (_btn_abbrechen == null)
                {
                    _btn_abbrechen = new RelayCommand(() =>
                    {
                        SicherheitsfrageViewModel logic = new SicherheitsfrageViewModel();
                    });
                }
                return _btn_abbrechen;
            }
        }

        private string _cb_sicherheitsfrage;

        public string cb_sicherheitsfrage
        {
            get
            {
                return _cb_sicherheitsfrage;
            }
            set
            {
                _cb_sicherheitsfrage = value;
                RaisePropertyChanged("cb_sicherheitsfrage");
            }
        }

        private string _tb_antwort;

        public string tb_antwort
        {
            get
            {
                return _tb_antwort;
            }
            set
            {
                _tb_antwort = value;
                RaisePropertyChanged("tb_antwort");
            }
        }
    }
}
