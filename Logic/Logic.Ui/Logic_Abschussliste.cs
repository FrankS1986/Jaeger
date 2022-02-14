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
    public class Logic_Abschussliste : ViewModelBase, INotifyPropertyChanged
    {

        private ICommand _bt_abschuesseHinzufuegen;
        public ICommand bt_abschuesseHinzufuegen
        {
            get
            {
                if(_bt_abschuesseHinzufuegen == null)
                {
                    _bt_abschuesseHinzufuegen = new RelayCommand(() =>
                     {
                        ///Logic
                    });
                }
                return _bt_abschuesseHinzufuegen;
            }
        }
    }
}
