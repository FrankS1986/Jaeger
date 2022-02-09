using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_UrkundeErstellen : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _btn_Urkunden_erstellen;
        public ICommand btn_Urkunden_erstellen
        {
            get 
            {
                 if (_btn_Urkunden_erstellen==null)
                 {
                    _btn_Urkunden_erstellen = new RelayCommand(() =>
                    {
                        Logic_UrkundeErstellen logic = new Logic_UrkundeErstellen();
                    });
                 }
                return _btn_Urkunden_erstellen;
            }
        }
    }
}
