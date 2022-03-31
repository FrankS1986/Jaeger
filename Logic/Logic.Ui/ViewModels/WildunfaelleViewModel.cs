using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace JaegerMeister.MvvmSample.Logic.Ui.ViewModels
{
    public class WildunfaelleViewModel: ViewModelBase , INotifyPropertyChanged
    {
        private DateTime _dpStartDate;
        public DateTime DpStartDate
        {
            get
            {
                return _dpStartDate;
            }
          set
            {
                _dpStartDate = value;
                RaisePropertyChanged("DpStartDate");
            }
        }                                                                                   



        private List<Tierart> _tb_Tierart;
        public List<Tierart> tb_Tierart
        {
            get
            {
                return _tb_Tierart;
            }

            set
            {
                _tb_Tierart = value;
                RaisePropertyChanged("tb_Tierart");
            }
        }

        private ICommand _btn_Wildunfaelle;
        public ICommand btn_Wildunfaelle
        {
            get
            {
                if (_btn_Wildunfaelle == null)
                {
                    _btn_Wildunfaelle = new RelayCommand(() =>
                    {
                        WildunfaelleViewModel logic = new WildunfaelleViewModel();


                        ////// logic
                    });

                }
                return _btn_Wildunfaelle;
            }
        }


        public class Tierart
        {
            public int ID { get; set; }
            public string name { get; set; }
        }
    }
}
