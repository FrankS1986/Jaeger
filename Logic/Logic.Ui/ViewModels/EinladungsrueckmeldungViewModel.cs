using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace JaegerMeister.MvvmSample.Logic.Ui.ViewModels
{
    public class EinladungsrueckmeldungViewModel : ViewModelBase, INotifyPropertyChanged
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
                          EinladungsrueckmeldungViewModel logic = new EinladungsrueckmeldungViewModel();
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
                       EinladungsrueckmeldungViewModel logic = new EinladungsrueckmeldungViewModel();
                   });
                }
                return _btn_Einladungsrueckmeldung_Abbrechen;
            }
        }
    }
}
