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
    public class Logic_AbschusslisteAktualisieren : ViewModelBase, INotifyPropertyChanged
    {
        AbschusslisteAktualisierenService serv = new AbschusslisteAktualisierenService();

        /// <summary>
        /// Weiterleitung zu anderen Fenstern
        /// </summary>
        public Logic_AbschusslisteAktualisieren()
        {
            Tierart = serv.Tiere();
            Termine = serv.Termine();
           
            Messenger.Default.Register<string>(this, (prop) =>
            {
                if (prop.Equals("Abschussliste"))
                {                    
                    Abschuesse = 0;                   
                }
            });

            Messenger.Default.Register<string>(this, (prop2) =>
            {
                if (prop2.Equals("JaegerListe"))
                {
                    if (SelectTermin != null)
                    {
                        Jaeger = serv.Jaeger(SelectTermin.Termine_ID);
                    }
                }
            });
        }
        //Properties zur Erstellung eines neuen Abschusses
        #region Properties
        private List<tbl_Tiere> _tierart;
        public List<tbl_Tiere> Tierart
        {
            get
            {
                return _tierart;
            }
            set
            {
                _tierart = value;
                RaisePropertyChanged("Tierart");
            }
        }

        private tbl_Termine _selectTermin;
        public tbl_Termine SelectTermin
        {
            get
            {
                return _selectTermin;
            }

            set
            {
                _selectTermin = value;
                RaisePropertyChanged("SelectTermin");
            }
        }

        private List<tbl_Termine> _termine;
        public List<tbl_Termine> Termine
        {
            get
            {
                return _termine;
            }
            set
            {
                _termine = value;
                RaisePropertyChanged("Termine");
            }
        }

        private List<tbl_Jaeger> _jaeger;
        public List<tbl_Jaeger> Jaeger

        {
            get
            {
                return _jaeger;
            }
            set
            {
                _jaeger = value;
                RaisePropertyChanged("Jaeger");
            }
        }

        private int _abschuesse;
        public int Abschuesse
        {
            get
            {
                return _abschuesse;
            }
            set
            {
                _abschuesse = value;

                RaisePropertyChanged("Abschuesse");
            }
        }

        private tbl_Tiere _tierId;
        public tbl_Tiere TierId

        {
            get
            {
                return _tierId;
            }
            set
            {
                _tierId = value;
                RaisePropertyChanged("TierId");
            }
        }

        private tbl_Jaeger _jaegerId;
        public tbl_Jaeger JaegerId
        {
            get
            {
                return _jaegerId;
            }
            set
            {
                _jaegerId = value;
                RaisePropertyChanged("JaegerId");
            }
        }
        #endregion

        //Buttonbefehl bei dem Versuch einen neuen Abschuss hinzu zufuegen
        private ICommand _abschusslisteAkualisieren;
        public ICommand AbschusslisteAkualisieren
        {
            get
            {
                if (_abschusslisteAkualisieren == null)
                {
                    _abschusslisteAkualisieren = new RelayCommand(() =>
                    {
                        if (JaegerId != null && SelectTermin != null && TierId != null)
                        {
                            var newitem = new tbl_Jagderfolge()
                            {
                                Jäger_ID = JaegerId.Jäger_ID,
                                Termine_ID = SelectTermin.Termine_ID,
                                Tiere_ID = TierId.Tiere_ID
                            };
                            Messenger.Default.Send<AbschusslisteAktualisierenSelectedMessage>(new AbschusslisteAktualisierenSelectedMessage { Abfrage = serv.InsertJagdErfolge(newitem, Abschuesse) });
                            Abschuesse = 0;
                        }
                        else
                        {
                            Messenger.Default.Send<AbschusslisteAktualisierenSelectedMessage>(new AbschusslisteAktualisierenSelectedMessage { Abfrage = false });
                        }
                    });
                }
                return _abschusslisteAkualisieren;
            }
        }
    }
}
