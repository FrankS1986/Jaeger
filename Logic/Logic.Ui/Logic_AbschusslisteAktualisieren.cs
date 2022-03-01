using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_AbschusslisteAktualisieren : ViewModelBase , INotifyPropertyChanged
    {
        AbschusslisteAktualisierenService serv = new  AbschusslisteAktualisierenService();
        public Logic_AbschusslisteAktualisieren()
        {
            Tierart = serv.Tiere();
          
            


            Messenger.Default.Register<string>(this, (prop) =>
            {
                if (prop.Equals("Liste"))
                {
                    Termine = serv.Termine();
                    
                }
            });

           
                Messenger.Default.Register<string>(this, (prop2) =>
                {
                    if (prop2.Equals("JaegerListe"))
                    {
                       
                        
                     Jaeger=serv.Jaeger(SelectTermin.Termine_ID);
                       
                    }
                });

            

        }
   
        
        private List<tbl_Tiere> _Tierart;
        public List<tbl_Tiere> Tierart

        {
            get
            {
                return _Tierart;
            }

            set
            {
                _Tierart = value;
                RaisePropertyChanged("Tierart");
            }
        }

        private tbl_Termine _SelectTermin;
        public tbl_Termine SelectTermin
        {
            get
            {
                return _SelectTermin;
            }

            set
            {
                _SelectTermin = value;
                RaisePropertyChanged("SelectTermin");
            }
        }

        private List<tbl_Termine> _Termine;
        public List<tbl_Termine> Termine

        {
            get
            {
                return _Termine;
            }

            set
            {
                _Termine = value;
                RaisePropertyChanged("Termine");
            }
        }

        private List<tbl_Jaeger> _Jaeger;
        public List<tbl_Jaeger> Jaeger

        {
            get
            {
                return _Jaeger;
            }

            set
            {
                _Jaeger = value;
                RaisePropertyChanged("Jaeger");
            }
        }

        private string _Abschuesse;
        public string Abschuesse

        {
            get
            {
                return _Abschuesse;
            }

            set
            {
                _Abschuesse = value;
                RaisePropertyChanged("Abschuesse");
            }
        }



        private ICommand _AbschusslisteAkualisieren;
        public ICommand AbschusslisteAkualisieren
        {
            get
            {
                if (_AbschusslisteAkualisieren == null)
                {
                    _AbschusslisteAkualisieren = new RelayCommand(() =>
                    {
                        


                     
                    });

                }
                return _AbschusslisteAkualisieren;
            }
        }

        public class TestJaeger
        {
           
            public string Ort { get; set; }
            public DateTime Datum { get; set; }


        }

        

    }
}
