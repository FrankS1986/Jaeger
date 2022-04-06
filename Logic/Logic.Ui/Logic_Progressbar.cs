using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
   public class Logic_Progressbar : ViewModelBase, INotifyPropertyChanged
    {

        private int _laden;
        public int Laden
        {
            get
            {
                return _laden;
            }

            set
            {
                _laden = value;
                RaisePropertyChanged("Laden");
            }
        }

    }
}
