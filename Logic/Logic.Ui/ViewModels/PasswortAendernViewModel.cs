using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace JaegerMeister.MvvmSample.Logic.Ui.ViewModels
{
    public class PasswortAendernViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _tbPw_Benutzername;
        public string tbPw_Benutzername

        {
            get
            {
                return _tbPw_Benutzername;
            }

            set
            {
                _tbPw_Benutzername = value;
                RaisePropertyChanged("tbPw_Benutzername");
            }
        }

        private string _altesPasswort;
        public string altesPasswort

        {
            get
            {
                return _altesPasswort;
            }

            set
            {
                _altesPasswort = value;
                RaisePropertyChanged("altesPasswort");
            }
        }

        private string _neuesPasswort;
        public string neuesPasswort

        {
            get
            {
                return _neuesPasswort;
            }

            set
            {
                _neuesPasswort = value;
                RaisePropertyChanged("altesPasswort");
            }
        }

        private string _Passwortbestaetigen;
        public string Passwortbestaetigen

        {
            get
            {
                return _Passwortbestaetigen;
            }

            set
            {
                _Passwortbestaetigen = value;
                RaisePropertyChanged("Passwortbestaetigen");
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
                        PasswortAendernViewModel logic = new PasswortAendernViewModel();


                        ////
                    });

                }
                return _btnPw_Bestaetigen;
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
                        PasswortAendernViewModel logic = new PasswortAendernViewModel();


                        ////
                    });

                }
                return _btnPw_Abbruch;
            }
        }

    }
}
