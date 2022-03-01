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
            Abschuesse = 0;
            


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

        private int _Abschuesse;
        public int Abschuesse

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

        private tbl_Tiere _TierId;
        public tbl_Tiere TierId

        {
            get
            {
                return _TierId;
            }

            set
            {
                _TierId = value;
                RaisePropertyChanged("TierId");
            }
        }

        private tbl_Jaeger _JaegerId;
        public tbl_Jaeger JaegerId

        {
            get
            {
                return _JaegerId;
            }

            set
            {
                _JaegerId = value;
                RaisePropertyChanged("JaegerId");
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


                        if (JaegerId != null && SelectTermin !=null && TierId != null)
                        {
                            var newitem = new tbl_Jagderfolge()

                            {
                                Jäger_ID = JaegerId.Jäger_ID,
                                Termine_ID = SelectTermin.Termine_ID,
                                Tiere_ID = TierId.Tiere_ID


                            };

                            Messenger.Default.Send<AbschusslisteAktualisierenSelectedMessage>(new AbschusslisteAktualisierenSelectedMessage { Abfrage = serv.InsertJagdErfolge(newitem, Abschuesse) });
                        }
                        else
                        {
                            Messenger.Default.Send<AbschusslisteAktualisierenSelectedMessage>(new AbschusslisteAktualisierenSelectedMessage { Abfrage = false });
                        }

                    });

                }
                return _AbschusslisteAkualisieren;
            }
        }

        
        

    }
}
