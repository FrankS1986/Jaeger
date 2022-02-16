using System.Windows.Input;
using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace JaegerMeister.MvvmSample.Logic.Ui
{

    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        public string WindowTitle { get; private set; }
        public MainViewModel()
        {

            if (IsInDesignMode)
            {
                WindowTitle = "MvvSample (Designmode)";

            }
            else
            {
                WindowTitle = "MvvSample";

            }

        }




    }
}