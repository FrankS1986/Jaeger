using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace JaegerMeister.MvvmSample.Logic.Ui.ViewModels
{
    public class EinladungErstellenViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _btn_einlandungSenden;
        public ICommand btn_EinlandungSenden
        {
            get
            {
                if (_btn_einlandungSenden == null)
                {
                    _btn_einlandungSenden = new RelayCommand(() =>
                    {


                        ///Logic
                    });
                }
                return _btn_einlandungSenden;
            }
        }


        private ICommand _btn_abbrechen;
        public ICommand btn_Abbrechen
        {
            get
            {
                if (_btn_abbrechen == null)
                {
                    _btn_abbrechen = new RelayCommand(() =>
                    {


                        ///Logic
                    });
                }
                return _btn_abbrechen;
            }
        }

        private ObservableCollection<EinladungErstellenViewModel> _dg_termine;
        public ObservableCollection<EinladungErstellenViewModel> dg_Termine
        {
            get { return _dg_termine; }
            set
            {
                _dg_termine = value;
                
            }
        }
    }
}
