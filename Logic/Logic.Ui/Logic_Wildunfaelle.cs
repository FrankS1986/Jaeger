using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private ICommand _Jaergliste;
        public ICommand jaegerliste
        {
            get
            {
                if (_Jaergliste == null)
                {
                    _Jaergliste = new RelayCommand(() =>
                    {
                        JaegerlisteFensterLogic logic = new JaegerlisteFensterLogic();


                        text = logic.WindowTitle;
                    });

                }
                return _Jaergliste;
            }
        }


        public class Tierart
        {
            public int ID {get; set;}
            public string name { get; set; }
    }
}
