using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Einladungsuebersicht : MainViewModel, INotifyPropertyChanged
    {
        private ICommand _btn_einlandungSicht;
        public ICommand btn_EinlandungSicht
        {
            get
            {
                if (_btn_einlandungSicht == null)
                {
                    _btn_einlandungSicht = new RelayCommand(() =>
                    {


                        ///Logic
                    });
                }
                return _btn_einlandungSicht;
            }
        }


    }

   
}
