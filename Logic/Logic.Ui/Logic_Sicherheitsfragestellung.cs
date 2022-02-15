using System;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_SicherheitsFragestellung : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _btn_bestaetigen;

        public ICommand btn_bestaetigen
        {
            get
            {
                if (_btn_bestaetigen == null)
                {
                    _btn_bestaetigen = new RelayCommand(() =>
                    {
                        Logic_SicherheitsFragestellung logic = new Logic_SicherheitsFragestellung();
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
                       Logic_SicherheitsFragestellung logic = new Logic_SicherheitsFragestellung();
                    });
                }
                return _btn_abbrechen;
            }
        }

        private string _lb_sicherheitsfrage;

        public string lb_sicherheitsfrage
        {
            get
            {
                return _lb_sicherheitsfrage;
            }
            set
            {
                _lb_sicherheitsfrage = value;
                RaisePropertyChanged("");
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
                RaisePropertyChanged("");
            }
        }

    }
}
