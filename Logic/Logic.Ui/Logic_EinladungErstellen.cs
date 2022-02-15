using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_EinladungErstellen : ViewModelBase, INotifyPropertyChanged
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

        private ObservableCollection<Logic_EinladungErstellen> _dg_termine;
        public ObservableCollection<Logic_EinladungErstellen> dg_Termine
        {
            get { return _dg_termine; }
            set
            {
                _dg_termine = value;
                
            }
        }
    }
}
