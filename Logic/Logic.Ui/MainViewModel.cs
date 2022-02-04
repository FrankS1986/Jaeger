using GalaSoft.MvvmLight;

namespace JaegerMeister.MvvmSample.Logic.Ui
{

    public class MainViewModel : ViewModelBase
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

        public string WindowTitel { get; private set; }
    }
}