using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Wildunfaelle: ViewModelBase , INotifyPropertyChanged
    {
        private DateTime _dp_StartDate;
        public DateTime dp_StartDate
        {
            get
            {
                return _dp_StartDate;
            }
          set
            {
                _dp_StartDate = value;
                RaisePropertyChanged("dp_StartDate");
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
                        Logic_Wildunfaelle logic = new Logic_Wildunfaelle();


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
