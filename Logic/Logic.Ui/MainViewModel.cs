using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{

    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        List<string> _lb_JaegerListe;
        List<string> _lb_UrkundenErhalten;
        ICommand _btn_Abbrechen;
        ICommand _btn_Urkunden_erstellen;
        public List<string> lb_JaegerListe
        {
            get { return _lb_JaegerListe; }
            set { _lb_JaegerListe = value; }
        }
        public List<string> lb_UrkundenErhalten
        {
            get { return _lb_UrkundenErhalten; }
            set { _lb_UrkundenErhalten = value; }
        }
        public ICommand Btn_Abbrechen
        {
            get
            {
                _btn_Abbrechen = new RelayCommand(() =>
                {
                    //WAS DER BUTTON MACHT HIER
                });
                return _btn_Abbrechen;
            }
        }
        public ICommand Btn_Urkunden_erstellen
        {
            get
            {
                _btn_Urkunden_erstellen = new RelayCommand(() =>
                {
                    //WAS DER BUTTON MACHT HIER
                });
                return _btn_Urkunden_erstellen;
            }
        }
        public MainViewModel()
        {
            _lb_JaegerListe = new List<string> { };
            _lb_UrkundenErhalten = new List<string> { };           
        }
    }
}