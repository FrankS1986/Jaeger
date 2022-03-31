using System.ComponentModel;
using GalaSoft.MvvmLight;

namespace JaegerMeister.MvvmSample.Logic.Ui.ViewModels
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