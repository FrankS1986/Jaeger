using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace JaegerMeister.MvvmSample.Logic.Ui.ViewModels
{
    public class AdminViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private ICommand _btnUserEntfernen;
        public ICommand BtnUserEntfernen
        {
            get
            {
                if(_btnUserEntfernen == null)
                {
                    _btnUserEntfernen = new RelayCommand(() =>
                      {
                          //Logic
                      });
                }
                return _btnUserEntfernen;
            }
        }

        private ICommand _btnPasswortZurueck;
        public ICommand BtnPasswortZurueck
        {
            get
            {
                if (_btnPasswortZurueck == null)
                {
                    _btnPasswortZurueck = new RelayCommand(() =>
                    {
                        //Logic
                    });
                }
                return _btnPasswortZurueck;
            }
        }


        private ICommand _btnSichFrageZurueck;
        public ICommand BtnSichFrageZurueck
        {
            get
            {
                if (_btnSichFrageZurueck == null)
                {
                    _btnSichFrageZurueck = new RelayCommand(() =>
                    {
                        //Logic
                    });
                }
                return _btnSichFrageZurueck;
            }
        }

        private string _lbNameAnzeigen;
        public string LbNameAnzeigen
        {
            get
            {
                return _lbNameAnzeigen;
            }
            set
            {
                //Logic
            }
        }

        private string _lbVorname;
        public string LbVorname
        {
            get
            {
                return _lbVorname;
            }
            set
            {
                //Logic
            }
        }

        private string _lbNachname;
        public string LbNachname
        {
            get
            {
                return _lbNachname;
            }
            set
            {
                //Logic
            }
        }

    }
}
