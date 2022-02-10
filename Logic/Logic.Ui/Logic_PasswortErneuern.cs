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
    public class Logic_PasswortErneuern : ViewModelBase, INotifyPropertyChanged
    {

        private string _tbPw_Benutzername;
        public string TbPw_Benutzername
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

        

        private string _neuespasswort;
        public string Neuespasswort
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
        public string Passwortbestaetigen
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
                        Logic_PasswortErneuern logic = new Logic_PasswortErneuern();


                        
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
                        Logic_PasswortErneuern logic = new Logic_PasswortErneuern();



                    });

                }
                return _btnPw_Bestaetigen;
            }
        }

        

    }
}
