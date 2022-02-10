
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Admin : ViewModelBase, INotifyPropertyChanged
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
