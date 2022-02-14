using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Login : ViewModelBase, INotifyPropertyChanged
    {


        //Properties      

        private ICommand _btn_abbruch;
        public ICommand btn_Abbruch
        {
            get
            {
                if (_btn_abbruch == null)
                {
                    _btn_abbruch = new RelayCommand(() =>
                    {
                        /// Logic
                    });

                }
                return _btn_abbruch;
            }
        }


        private ICommand _btn_Registrieren;
        public ICommand btn_Registrieren
        {
            get
            {
                if (_btn_Registrieren == null)
                {
                    _btn_Registrieren = new RelayCommand(() =>
                    {
                        /// Logic
                    });

                }
                return _btn_Registrieren;
            }
        }

        private ICommand _btn_bestaetigen;
        public ICommand btn_Bestaetigen
        {
            get
            {
                if (_btn_bestaetigen == null)
                {
                    _btn_bestaetigen = new RelayCommand(() =>
                    {
                        ///Logic
                    });
                }
                return _btn_bestaetigen;
            }
        }

        private string _tb_benutzername;
        public string tb_Benutzername
        {
            get
            {
                return _tb_benutzername;
            }
            set
            {
                _tb_benutzername = value;
                RaisePropertyChanged("tb_Benutzername");
            }
        }
        private string _passwort;
        public string passwort
        {
            get
            {
                return _passwort;
            }
            set
            {
                _passwort = value;
                RaisePropertyChanged("passwort");
            }
        }

        private ICommand _btn_passwortvergessen;
        public ICommand btn_Passwortvergessen
        {
            get
            {
                if (_btn_passwortvergessen == null)
                {
                    _btn_passwortvergessen = new RelayCommand(() =>
                    {
                        ///Logic
                    });
                }
                return _btn_passwortvergessen;
            }
        }

    }
}

