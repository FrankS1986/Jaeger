using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{

    public class MainViewModel : ViewModelBase
    {
        ICommand _btn_Kalender, _btn_Termin, _btn_Jaegerliste, _btn_Abschlussliste, _btn_Wildunfaelle, _btn_Einladungsuebersicht, _btn_Dokumenteverwalten,
            _btn_Urkundeerstellen, _btn_Admin;


        public MainViewModel()
        {  
            
        }
        public ICommand btn_Kalender
        {
            get
                {
                _btn_Kalender = new RelayCommand(() =>
                {
                    //WAS SOLL DER BUTTON TUN?
                });
                return _btn_Kalender;
            }         
        }
        public ICommand btn_Termin
        {
            get
            {
                _btn_Termin = new RelayCommand(() =>
                {
                    //WAS SOLL DER BUTTON TUN?
                });
                return _btn_Termin;
            }
        }
        public ICommand btn_Jaegerliste
        {
            get
            {
                _btn_Jaegerliste = new RelayCommand(() =>
                {
                    //WAS SOLL DER BUTTON TUN?
                });
                return _btn_Jaegerliste;
            }
        }
        public ICommand btn_Abschussliste
        {
            get
            {
                _btn_Abschlussliste = new RelayCommand(() =>
                {
                    //WAS SOLL DER BUTTON TUN?
                });
                return _btn_Abschlussliste;
            }
        }
        public ICommand btn_Wildunfaelle
        {
            get
            {
                _btn_Wildunfaelle = new RelayCommand(() =>
                {
                    //WAS SOLL DER BUTTON TUN?
                });
                return _btn_Wildunfaelle;
            }
        }
        public ICommand btn_Einladungsuebersicht
        {
            get
            {
                _btn_Einladungsuebersicht = new RelayCommand(() =>
                {
                    //WAS SOLL DER BUTTON TUN?
                });
                return _btn_Einladungsuebersicht;
            }
        }
        public ICommand btn_Dokumenteverwalten
        {
            get
            {
                _btn_Dokumenteverwalten = new RelayCommand(() =>
                {
                    //WAS SOLL DER BUTTON TUN?
                });
                return _btn_Dokumenteverwalten;
            }
        }
        public ICommand btn_Urkundeerstellen
        {
            get
            {
                _btn_Urkundeerstellen = new RelayCommand(() =>
                {
                    //WAS SOLL DER BUTTON TUN?
                });
                return _btn_Urkundeerstellen;
            }
        }
        public ICommand btn_Admin
        {
            get
            {
                _btn_Admin = new RelayCommand(() =>
                {
                    //WAS SOLL DER BUTTON TUN?
                });
                return _btn_Admin;
            }
        }
    }
}