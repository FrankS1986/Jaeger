using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_AbschusslisteAktualisieren : ViewModelBase , INotifyPropertyChanged
    {
        
       private  List<Jaeger> _listboxJaeger;
       public List<Jaeger> listboxJaeger

        { 
        
           get
            {
                return _listboxJaeger;
            }

            set
            {
                _listboxJaeger = value;
                RaisePropertyChanged("listboxJaeger");
            }
        
        }

        private List<Jaeger> _listboxTermine;
        public List<Jaeger> listboxTermine

        {

            get
            {
                return _listboxTermine;
            }

            set
            {
                _listboxTermine = value;
                RaisePropertyChanged("listboxTermine");
            }

        }


        private List<Tierart> _comboBoxTierart;
        public List<Tierart> comboBoxTierart

        {
            get
            {
                return _comboBoxTierart;
            }

            set
            {
                _comboBoxTierart = value;
                RaisePropertyChanged("comboBoxTierart");
            }
        }

        private string _textboxAbschuesse;
        public string textboxAbschuesse

        {
            get
            {
                return _textboxAbschuesse;
            }

            set
            {
                _textboxAbschuesse = value;
                RaisePropertyChanged("textboxAbschuesse");
            }
        }



        private ICommand _btn_AbschusslisteAkualisieren;
        public ICommand btn_AbschusslisteAkualisiere
        {
            get
            {
                if (_btn_AbschusslisteAkualisieren == null)
                {
                    _btn_AbschusslisteAkualisieren = new RelayCommand(() =>
                    {
                        Logic_AbschusslisteAktualisieren logic = new Logic_AbschusslisteAktualisieren();


                        ////
                    });

                }
                return _btn_AbschusslisteAkualisieren;
            }
        }

        public class Jaeger
        {
            public int ID { get; set; }
            public int Vorname { get; set; }
            public int Name { get; set; }
        }

        public class Tierart
        {
            public int ID { get; set; }
            
            public int Name { get; set; }
        }

    }
}
