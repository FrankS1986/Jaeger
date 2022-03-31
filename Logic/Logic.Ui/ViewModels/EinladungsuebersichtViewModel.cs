using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace JaegerMeister.MvvmSample.Logic.Ui.ViewModels
{
    public class EinladungsuebersichtViewModel : MainViewModel, INotifyPropertyChanged
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
