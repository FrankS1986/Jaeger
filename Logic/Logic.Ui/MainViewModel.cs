using System.Windows.Input;
using GalaSoft.MvvmLight;
using System.ComponentModel;

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