
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
        public ICommand btnUserEntfernen
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
        public ICommand btnPasswortZurueck
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
        public ICommand btnSichFrageZurueck
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
        public string lbNameAnzeigen
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
        public string lbVorname
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
        public string lbNachname
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
