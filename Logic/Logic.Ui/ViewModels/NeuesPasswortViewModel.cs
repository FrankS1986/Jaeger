using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace JaegerMeister.MvvmSample.Logic.Ui.ViewModels
{
    public class NeuesPasswortViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _neuespasswort;
        public string neuespasswort

        {
            get
            {
                return _neuespasswort;
            }

            set
            {
                _neuespasswort = value;
                RaisePropertyChanged("neuespasswort");
            }
        }

        private string _passwortbestaetigen;
        public string passwortbestaetigen

        {
            get
            {
                return _passwortbestaetigen;
            }

            set
            {
                _passwortbestaetigen = value;
                RaisePropertyChanged("passwortbestaetigen");
            }
        }



        private ICommand _btnPw_Abbruch;
        public ICommand BtnPw_Abbruch
        {
            get
            {
                if (_btnPw_Abbruch == null)
                {
                    _btnPw_Abbruch = new RelayCommand(() =>
                    {
                        NeuesPasswortViewModel logic = new NeuesPasswortViewModel();


                        ////
                    });

                }
                return _btnPw_Abbruch;
            }
        }

        private ICommand _btnPw_Bestaetigen;
        public ICommand BtnPw_Bestaetigen
        {
            get
            {
                if (_btnPw_Bestaetigen == null)
                {
                    _btnPw_Bestaetigen = new RelayCommand(() =>
                    {
                        NeuesPasswortViewModel logic = new NeuesPasswortViewModel();


                        ////
                    });

                }
                return _btnPw_Bestaetigen;
            }
        }
    }
}
