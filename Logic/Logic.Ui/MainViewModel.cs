using GalaSoft.MvvmLight;
using System.ComponentModel;

namespace JaegerMeister.MvvmSample.Logic.Ui
{

    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                WindowTitel = "JaegerMeister (Design)";
            }
            else
            {
                WindowTitel = "Jaegermeister";
            }
        }
    }
}