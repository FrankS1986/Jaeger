using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace JaegerMeister.MvvmSample.Logic.Ui.ViewModels
{
    public class KalenderViewModel: ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _btn_TerminHinzufuegen;
        public ICommand Btn_TerminHinzufuegen
        {
            get
            {
                if (_btn_TerminHinzufuegen == null)
                {
                    _btn_TerminHinzufuegen = new RelayCommand(() =>
                    {
                        KalenderViewModel logic = new KalenderViewModel();
                    });
                }
                return _btn_TerminHinzufuegen;
            }
        
        }
        private ICommand _dg_TermineKalender;
        public ICommand Dg_TermineKalender
        {
            get
            {
                if (_dg_TermineKalender == null)
                {
                    _dg_TermineKalender = new RelayCommand(() =>
                    {
                        KalenderViewModel logic = new KalenderViewModel();
                    });
                }
                return _dg_TermineKalender;
            }
        }
        private ICommand _dg_KalenderAnzeige;
        public ICommand Dg_KalenderAnzeige
        {
            get
            {
                if (_dg_KalenderAnzeige == null)
                {
                    _dg_KalenderAnzeige = new RelayCommand(() =>
                    {
                        KalenderViewModel logic = new KalenderViewModel();
                    });
                }
                return _dg_KalenderAnzeige;
            }
        }

    }
}
