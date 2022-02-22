using System;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_SicherheitsFragestellung : ViewModelBase, INotifyPropertyChanged
    {
        Services.SicherheitsfragestellungService serv = new Services.SicherheitsfragestellungService();

        public Logic_SicherheitsFragestellung()
        {

            AntwortEnable = false;
            BenutzerEnable = true;
            SicherheitsfragestellungsErfolgsMessage sicherheitsfragestellungsErfolgsMessage = new SicherheitsfragestellungsErfolgsMessage();



        }

        private ICommand _btn_bestaetigen;

        public ICommand btn_bestaetigen
        {
            get
            {
                if (_btn_bestaetigen == null)
                {
                    _btn_bestaetigen = new RelayCommand(() =>
                    {

                        Messenger.Default.Send<SicherheitsfragestellungsErfolgsMessage>(new SicherheitsfragestellungsErfolgsMessage { SuccesSicherheitsFragestellung = serv.AbfrageAnwort(Benutzername, Antwort) });

                        Benutzername = null;
                        Antwort = null;
                        Sicherheitsfrage = null;
                        AntwortEnable = false;
                        BenutzerEnable = true;


                    });
                }
                return _btn_bestaetigen;
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

                        Benutzername = null;
                        Antwort = null;
                        Sicherheitsfrage = null;
                        AntwortEnable = false;
                        BenutzerEnable = true;

                    });
                }
                return _Abbrechen;
            }
        }


        private ICommand _BenutzernameBestaetigen;

        public ICommand BenutzernameBestaetigen
        {
            get
            {
                if (_BenutzernameBestaetigen == null)
                {
                    _BenutzernameBestaetigen = new RelayCommand(() =>
                    {

                        serv.Benutzerabfrage(Benutzername);
                        Sicherheitsfrage = serv.fragestellung;
                        if(!string.IsNullOrEmpty(Sicherheitsfrage))
                        {
                            AntwortEnable = true;
                            BenutzerEnable = false;
                        }

                    });
                }
                return _BenutzernameBestaetigen;
            }
        }


        private string _Benutzername;

        public string Benutzername
        {
            get
            {
                return _Benutzername;
            }
            set
            {
                _Benutzername = value;
                RaisePropertyChanged("Benutzername");
            }
        }

        private string _Sicherheitsfrage;

        public string Sicherheitsfrage
        {
            get
            {
                return _Sicherheitsfrage;
            }
            set
            {
                _Sicherheitsfrage = value;
                RaisePropertyChanged("Sicherheitsfrage");
            }
        }
        private List<tbl_Abfrage> _test;

        public List<tbl_Abfrage> test
        {
            get
            {
                return _test;
            }
            set
            {
                _test = value;
                RaisePropertyChanged("test");
            }
        }
        private string _Antwort;

        public string Antwort
        {
            get
            {
                return _Antwort;
            }
            set
            {
                _Antwort = value;
                RaisePropertyChanged("Antwort");
            }
        }

        private bool _AntwortEnable;

            public bool AntwortEnable
        {
            get
            {
                return _AntwortEnable;
            }
            set
            {
                _AntwortEnable = value;
                RaisePropertyChanged("AntwortEnable");
            }
        }

        private bool _BenutzerEnable;

        public bool BenutzerEnable
        {
            get
            {
                return _BenutzerEnable;
            }
            set
            {
                _BenutzerEnable = value;
                RaisePropertyChanged("BenutzerEnable");
            }
        }

    }
}
