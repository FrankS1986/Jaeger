using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Sicherheitsfrage : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _btn_bestaetigen;

        public ICommand Btn_bestaetigen
        {
            get
            {
                if(_btn_bestaetigen==null)
                {
                    _btn_bestaetigen = new RelayCommand(() =>
                    {
                        Logic_Sicherheitsfrage logic = new Logic_Sicherheitsfrage();
                    });
                }
                return _btn_bestaetigen;
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
                        Logic_Sicherheitsfrage logic = new Logic_Sicherheitsfrage();
                    });
                }
                return _btn_abbrechen;
            }
        }

        private string _lb_sicherheitsfrage;

        public string Lb_sicherheitsfrage
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

        public string Tb_antwort
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
