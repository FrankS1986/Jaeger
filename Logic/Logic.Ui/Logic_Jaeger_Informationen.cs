using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.Models;
using System.Collections.Generic;
using System;

namespace JaegerMeister.MvvmSample.Logic.Ui
{

    public class Logic_Jaeger_Informationen : ViewModelBase, INotifyPropertyChanged
    {
        JaegerInformationenService serv = new JaegerInformationenService();

        public Logic_Jaeger_Informationen()
        {
            Dg_Jaeger = serv.Jaeger();
        }

        private List<JaegerInformationModel> _dg_Jaeger;
        public List<JaegerInformationModel> Dg_Jaeger
        
        private ICommand _JaegerHinzufuegen;
        public ICommand JaegerHinzufuegen
        {
            get
            {
                if (_JaegerHinzufuegen == null)
                {
                    _JaegerHinzufuegen = new RelayCommand(() =>
                    {
                        Logic_Jaeger_Informationen logic = new Logic_Jaeger_Informationen();

                     
                    });

                }
                return _JaegerHinzufuegen;
            }
        }

        private ICommand _JaegerEntfernen;

        public ICommand JaegerEntfernen
        {
            get
            {
                if (_JaegerEntfernen == null)
                {
                    _JaegerEntfernen = new RelayCommand(() =>
                    {
                        Logic_Jaeger_Informationen logic = new Logic_Jaeger_Informationen();

                    });

                }
                return _JaegerEntfernen;
            }
        }

        private ICommand _Bearbeiten;

        public ICommand Bearbeiten
        {
            get
            {
                if (_Bearbeiten == null)
                {
                    _Bearbeiten = new RelayCommand(() =>
                    {
                        Logic_Jaeger_Informationen logic = new Logic_Jaeger_Informationen();


                    });

                }
                return _Bearbeiten;
            }
        }

        private string _VorUndNachname;

        public string VorUndNachname
        {
            get
            {
                return _VorUndNachname;
            }
            set { }
        }

        private string _Vorname;

        public string Vorname
        {
            get
            {
                return _Vorname;
            }
            set { }
        }

        private string _Nachname;

        public string Nachname
        {
            get
            {
                return _Nachname;
            }
            set { }
        }

        private string _Anrede;
        public string Anrede
        {
            get
            {
                return _Anrede;
            }
            set { }
        }
        private string _Geburtstag;
        public string Geburtstag
        {
            get
            {
                return _Geburtstag;
            }
            set { }
        }

        private string _Straße;
        public string Straße
        {
            get
            {
                return _Straße;
            }
            set { }
        }

        private string _Hausnummer;

        public string Hausnummer
        {
            get
            {
                return _Hausnummer;
            }
            set { }
        }

        private string _Adresszusatz;

        public string Adresszusatz
        {
            get
            {
                return _Adresszusatz;
            }
            set { }
        }

        private int _Postleitzahl;

        public int Postleitzahl
        {
            get
            {
                return _Postleitzahl;
            }
            set
            { }
        }

        private string _Wohnort;
        public string Wohnort
        {
            get
            {
                return _Wohnort;
            }
            set { }
        }

        private string _Telefonnummer1;

        public string Telefonnummer1
        {
            get
            {
                return _Telefonnummer1;
            }
            set { }
        }

        private string _Telefonnummer2;

        public string Telefonnummer2
        {
            get
            {
                return _Telefonnummer2;
            }
            set { }
        }

        private string _Telefonnummer3;

        public string Telefonnummer3
        {
            get
            {
                return _Telefonnummer3;
            }
            set { }
        }

        private string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set { }
        }

        private string _Funktion;
        public string Funktion
        {
            get
            {
                return _Funktion;
            }
            set { }
        }

        private int _Jagdhunde;
        public int Jagdhunde
        {
            get
            {
                return Jagdhunde;
            }
            set { }
        }
        #endregion
    }
}