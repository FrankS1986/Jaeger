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
        {
            get
            {
                return _dg_Jaeger;
            }
            set
            {
                
                _dg_Jaeger = value;
                RaisePropertyChanged("Dg_Jaeger");
            }
        }
        //SelectedItem Anzeige der Labels
        private JaegerInformationModel _selectedListItem;
        public JaegerInformationModel SelectedListItem
        {
            get
            {
                return _selectedListItem;
            }
            set
            {
                _selectedListItem = value;
                RaisePropertyChanged("SelectedListItem");

                if(_selectedListItem != null)
                {
                    JaegerInformationSelectedModel result = serv.Selected(_selectedListItem.Jäger_ID);

                    Lab_vorname = result.Vorname;
                    Lab_nachname = result.Nachname;
                    Lab_anrede = result.Anrede;
                    Lab_geburtstag = (DateTime)result.Geburtsdatum;
                    Lab_straße = result.Straße;
                    Lab_hausnummer = result.Hausnummer;
                    Lab_adresszusatz = result.Adresszusatz;
                    Lab_postleitzahl = result.Postleitzahl;
                    Lab_wohnort = result.Wohnort;
                    Lab_telefonnummer1 = result.Telefonnummer1;
                    Lab_telefonnummer2 = result.Telefonnummer2;
                    Lab_telefonnummer3 = result.Telefonnummer3;
                    Lab_email = result.Email;
                    Lab_funktion = result.Funktion;
                    Lab_jagdhunde = result.Jagdhund;
                    LabelVorname = result.Vorname;
                    LabelNachname = result.Nachname; 
                }
            }
        }
        #region properties Labels
        private string _labelVorname;
        public string LabelVorname
        {
            get
            {
                return _labelVorname;
            }
            set
            {
                _labelVorname = value;
                RaisePropertyChanged("LabelVorname");
            }
        }

        private string _labelNachname;
        public string LabelNachname
        {
            get
            {
                return _labelNachname;
            }
            set
            {
                _labelNachname = value;
                RaisePropertyChanged("LabelNachname");
            }
        }

        private string _lab_vorname;
        public string Lab_vorname
        {
            get
            {
                return _lab_vorname;
            }
            set
            {
                _lab_vorname = value;
                RaisePropertyChanged("Lab_vorname");
            }
        }

        private string _lab_nachname;
        public string Lab_nachname
        {
            get
            {
                return _lab_nachname;
            }
            set
            {
                _lab_nachname = value;
                RaisePropertyChanged("Lab_nachname");
            }
        }

        private string _lab_anrede;
        public string Lab_anrede
        {
            get
            {
                return _lab_anrede;
            }
            set
            {
                _lab_anrede = value;
                RaisePropertyChanged("Lab_anrede");
            }
        }

        private DateTime _lab_geburtstag;
        public DateTime Lab_geburtstag
        {
            get
            {
                return _lab_geburtstag;
            }
            set
            {
                _lab_geburtstag = value;
                RaisePropertyChanged("Lab_geburtstag");
            }
        }

        private string _lab_straße;
        public string Lab_straße
        {
            get
            {
                return _lab_straße;
            }
            set
            {
                _lab_straße = value;
                RaisePropertyChanged("Lab_Straße");
            }
        }

        private string _lab_hausnummer;
        public string Lab_hausnummer
        {
            get
            {
                return _lab_hausnummer;
            }
            set
            {
                _lab_hausnummer = value;
                RaisePropertyChanged("Lab_hausnummer");
            }
        }

        private string _lab_adresszusatz;
        public string Lab_adresszusatz
        {
            get
            {
                return _lab_adresszusatz;
            }
            set
            {
                _lab_adresszusatz = value;
                RaisePropertyChanged("Lab_adresszusatz");
            }
        }

        private string _lab_postleitzahl;
        public string Lab_postleitzahl
        {
            get
            {
                return _lab_postleitzahl;
            }
            set
            {
                _lab_postleitzahl = value;
                RaisePropertyChanged("Lab_postleitzahl");
            }
        }

        private string _lab_wohnort;
        public string Lab_wohnort
        {
            get
            {
                return _lab_wohnort;
            }
            set
            {
                _lab_wohnort = value;
                RaisePropertyChanged("Lab_wohnort");
            }
        }

        private string _lab_telefonnummer1;
        public string Lab_telefonnummer1
        {
            get
            {
                return _lab_telefonnummer1;
            }
            set
            {
                _lab_telefonnummer1 = value;
                RaisePropertyChanged("Lab_telefonnummer1");
            }
        }

        private string _lab_telefonnummer2;
        public string Lab_telefonnummer2
        {
            get
            {
                return _lab_telefonnummer2;
            }
            set
            {
                _lab_telefonnummer2 = value;
                RaisePropertyChanged("Lab_telefonnummer2");
            }
        }

        private string _lab_telefonnummer3;
        public string Lab_telefonnummer3
        {
            get
            {
                return _lab_telefonnummer3;
            }
            set
            {
                _lab_telefonnummer3 = value;
                RaisePropertyChanged("Lab_telefonnummer3");
            }
        }

        private string _lab_email;
        public string Lab_email
        {
            get
            {
                return _lab_email;
            }
            set
            {
                _lab_email = value;
                RaisePropertyChanged("Lab_email");
            }
        }

        private string _lab_funktion;
        public string Lab_funktion
        {
            get
            {
                return _lab_funktion;
            }
            set
            {
                _lab_funktion = value;
                RaisePropertyChanged("Lab_funktion");
            }
        }

        private string _lab_jagdhunde;
        public string Lab_jagdhunde
        {
            get
            {
                return _lab_jagdhunde;
            }
            set
            {
                _lab_jagdhunde = value;
                RaisePropertyChanged("Lab_jagdhunde");
            }
        }
        #endregion
    }
}