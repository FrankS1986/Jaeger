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
    public class Logic_Einladungsrueckmeldung : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _btn_Einladungsrueckmeldung_Aktualisieren;
        public ICommand btn_Einladungsrueckmeldung_Aktualisieren
        {
            get
            {
                if(_btn_Einladungsrueckmeldung_Aktualisieren==null)
                {
                    _btn_Einladungsrueckmeldung_Aktualisieren = new RelayCommand(() =>
                      {
                          Logic_Einladungsrueckmeldung logic = new Logic_Einladungsrueckmeldung();
                      });
                }
                return _btn_Einladungsrueckmeldung_Aktualisieren;
            }
        }

        private ICommand _btn_Einladungsrueckmeldung_Abbrechen;
        public ICommand btn_Einladungsrueckmeldung_Abbrechen
        {
            get
            { 
                if(_btn_Einladungsrueckmeldung_Abbrechen == null)
                {
                    _btn_Einladungsrueckmeldung_Abbrechen = new RelayCommand(() =>
                   {
                       Logic_Einladungsrueckmeldung logic = new Logic_Einladungsrueckmeldung();
                   });
                }
                return _btn_Einladungsrueckmeldung_Abbrechen;
            }
        }
    }
}
