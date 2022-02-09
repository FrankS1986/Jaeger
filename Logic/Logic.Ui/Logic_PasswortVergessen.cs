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
    public class Logic_PasswortVergessen : ViewModelBase, INotifyPropertyChanged
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

        private string _altespasswort;
        public string altespasswort
        {
            get
            {
                return _altespasswort;

            }

            set
            {
                _altespasswort = value;
                RaisePropertyChanged("altespasswort");
            }
        }

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
                        Logic_PasswortVergessen logic = new Logic_PasswortVergessen();


                        
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
                        Logic_PasswortVergessen logic = new Logic_PasswortVergessen();



                    });

                }
                return _btnPw_Bestaetigen;
            }
        }

        // Binding für Commandparameter

    }
}
