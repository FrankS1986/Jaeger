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
        private ICommand _EinlandungSenden;
        public ICommand EinlandungSenden
        {
            get
            {
                if (_EinlandungSenden == null)
                {
                    _EinlandungSenden = new RelayCommand(() =>
                    {


                        ///Logic
                    });
                }
                return _EinlandungSenden;
            }
        }


        private ICommand _Abbrechen;
        public ICommand Abbrechen
        {
            get
            {
                if (_Abbrechen == null)
                {
                    _Abbrechen = new RelayCommand(() =>
                    {


                        ///Logic
                    });
                }
                return _Abbrechen;
            }
        }

        private List<tbl_Termine> _Termine ;
        public List<tbl_Termine> Termine
        {
            get
            { return _Termine;
 }
            set
            {
                _Termine = value;
                RaisePropertyChanged("Termine");
            }
        }
    }
}
