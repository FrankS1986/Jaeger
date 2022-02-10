using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_NeuesPasswort : ViewModelBase, INotifyPropertyChanged
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
        public ICommand btnPw_Abbruch
        {
            get
            {
                if (_btnPw_Abbruch == null)
                {
                    _btnPw_Abbruch = new RelayCommand(() =>
                    {
                        Logic_NeuesPasswort logic = new Logic_NeuesPasswort();


                        ////
                    });

                }
                return _btnPw_Abbruch;
            }
        }

        private ICommand _btnPw_Bestaetigen;
        public ICommand btnPw_Bestaetigen
        {
            get
            {
                if (_btnPw_Bestaetigen == null)
                {
                    _btnPw_Bestaetigen = new RelayCommand(() =>
                    {
                        Logic_NeuesPasswort logic = new Logic_NeuesPasswort();


                        ////
                    });

                }
                return _btnPw_Bestaetigen;
            }
        }
    }
}
