using System.Windows.Input;
using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;

namespace JaegerMeister.MvvmSample.Logic.Ui
{

    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 

        Service serv = new Service();

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