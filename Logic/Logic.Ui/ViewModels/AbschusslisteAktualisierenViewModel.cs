using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace JaegerMeister.MvvmSample.Logic.Ui.ViewModels
{
    public class AbschusslisteAktualisierenViewModel : ViewModelBase , INotifyPropertyChanged
    {
        
       private  List<Jaeger> _listboxJaeger;
       public List<Jaeger> ListboxJaeger

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
        public List<Jaeger> ListboxTermine

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
        public List<Tierart> ComboBoxTierart

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
        public string TextboxAbschuesse

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
        public ICommand Btn_AbschusslisteAkualisieren
        {
            get
            {
                if (_btn_AbschusslisteAkualisieren == null)
                {
                    _btn_AbschusslisteAkualisieren = new RelayCommand(() =>
                    {
                        AbschusslisteAktualisierenViewModel logic = new AbschusslisteAktualisierenViewModel();


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
