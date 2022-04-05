using System.ComponentModel;
using GalaSoft.MvvmLight;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using JaegerMeister.MvvmSample.Logic.Ui.Models;
using System.Collections.Generic;
using System;

namespace JaegerMeister.MvvmSample.Logic.Ui
{

    public class Logic_Jaeger_Informationen : ViewModelBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Interaktionslogik für Jaeger_Informationen.xaml
        /// </summary>
        JaegerInformationenService jaegerInformationenService = new JaegerInformationenService();

        public Logic_Jaeger_Informationen()
        {
            PersonAnzeige = jaegerInformationenService.Jaeger();
        }


        #region properties Labels
        private JaegerInformationModel _SelectedListItem;
        public JaegerInformationModel SelectedListItem
        {
            get
            {
                return _SelectedListItem;
            }
            set
            {
                _SelectedListItem = value;
                RaisePropertyChanged("SelectedListItem");

                if(_SelectedListItem != null)
                {
                    JaegerInformationSelectedModel result = jaegerInformationenService.Selected(_SelectedListItem.Jäger_ID);

                    VornameLabel = result.Vorname;
                    NachnameLabel = result.Nachname;
                    AnredeLabel = result.Anrede;
                    GeburtstagLabel = (DateTime)result.Geburtsdatum;
                    StraßeLabel = result.Straße;
                    HausnummerLabel = result.Hausnummer;
                    AdresszusatzLabel = result.Adresszusatz;
                    PostleitzahlLabel = result.Postleitzahl;
                    WohnortLabel = result.Wohnort;
                    Telefonnummer1Label = result.Telefonnummer1;
                    Telefonnummer2Label = result.Telefonnummer2;
                    Telefonnummer3Label = result.Telefonnummer3;
                    EmailLabel = result.Email;
                    FunktionLabel = result.Funktion;
                    JagdhundeLabel = result.Jagdhund;
                    VornameHeader = result.Vorname;
                    NachnameHeader = result.Nachname; 
                }
            }
        }
        
        private List<JaegerInformationModel> _PersonAnzeige;
        public List<JaegerInformationModel> PersonAnzeige
        {
            get
            {
                return _PersonAnzeige;
            }
            set
            {

                _PersonAnzeige = value;
                RaisePropertyChanged("PersonAnzeige");
            }
        }

        private string _VornameHeader;
        public string VornameHeader
        {
            get
            {
                return _VornameHeader;
            }
            set
            {
                _VornameHeader = value;
                RaisePropertyChanged("VornameHeader");
            }
        }

        private string _NachnameHeader;
        public string NachnameHeader
        {
            get
            {
                return _NachnameHeader;
            }
            set
            {
                _NachnameHeader = value;
                RaisePropertyChanged("NachnameHeader");
            }
        }

        private string _VornameLabel;
        public string VornameLabel
        {
            get
            {
                return _VornameLabel;
            }
            set
            {
                _VornameLabel = value;
                RaisePropertyChanged("VornameLabel");
            }
        }

        private string _NachnameLabel;
        public string NachnameLabel
        {
            get
            {
                return _NachnameLabel;
            }
            set
            {
                _NachnameLabel = value;
                RaisePropertyChanged("NachnameLabel");
            }
        }

        private string _AnredeLabel;
        public string AnredeLabel
        {
            get
            {
                return _AnredeLabel;
            }
            set
            {
                _AnredeLabel = value;
                RaisePropertyChanged("AnredeLabel");
            }
        }

        private DateTime _GeburtstagLabel;
        public DateTime GeburtstagLabel
        {
            get
            {
                return _GeburtstagLabel;
            }
            set
            {
                _GeburtstagLabel = value;
                RaisePropertyChanged("GeburtstagLabel");
            }
        }

        private string _StraßeLabel;
        public string StraßeLabel
        {
            get
            {
                return _StraßeLabel;
            }
            set
            {
                _StraßeLabel = value;
                RaisePropertyChanged("StraßeLabel");
            }
         
        }

        private string _HausnummerLabel;
        public string HausnummerLabel
        {
            get
            {
                return _HausnummerLabel;
            }
            set
            {
                _HausnummerLabel = value;
                RaisePropertyChanged("HausnummerLabel");
            }
           
        }

        private string _AdresszusatzLabel;
        public string AdresszusatzLabel
        {
            get
            {
                return _AdresszusatzLabel;
            }
            set
            {
                _AdresszusatzLabel = value;
                RaisePropertyChanged("AdresszusatzLabel");
            }
          
        }

        private string _PostleitzahlLabel;
        public string PostleitzahlLabel
        {
            get
            {
                return _PostleitzahlLabel;
            }
            set
            {
                _PostleitzahlLabel = value;
                RaisePropertyChanged("PostleitzahlLabel");
            }
        }

        private string _WohnortLabel;
        public string WohnortLabel
        {
            get
            {
                return _WohnortLabel;
            }
            set
            {
                _WohnortLabel = value;
                RaisePropertyChanged("Lab_wohnort");
            }
           
        }

        private string _Telefonnummer1Label;
        public string Telefonnummer1Label
        {
            get
            {
                return _Telefonnummer1Label;
            }
            set
            {
                _Telefonnummer1Label = value;
                RaisePropertyChanged("Telefonnummer1Label");
            }
            
        }

        private string _Telefonnummer2Label;
        public string Telefonnummer2Label
        {
            get
            {
                return _Telefonnummer2Label;
            }
            set
            {
                _Telefonnummer2Label = value;
                RaisePropertyChanged("Telefonnummer2Label");
            }

        }

        private string _Telefonnummer3Label;
        public string Telefonnummer3Label
        {
            get
            {
                return _Telefonnummer3Label;
            }
            set
            {
                _Telefonnummer3Label = value;
                RaisePropertyChanged("Telefonnummer3Label");
            }
          
        }

        private string _EmailLabel;
        public string EmailLabel
        {
            get
            {
                return _EmailLabel;
            }
            set
            {
                _EmailLabel = value;
                RaisePropertyChanged("EmailLabel");
            }
           
        }

        private string _FunktionLabel;
        public string FunktionLabel
        {
            get
            {
                return _FunktionLabel;
            }
            set
            {
                _FunktionLabel = value;
                RaisePropertyChanged("FunktionLabel");
            }
         
        }

        private string _JagdhundeLabel;
        public string JagdhundeLabel
        {
            get
            {
                return _JagdhundeLabel;
            }
            set
            {
                _JagdhundeLabel = value;
                RaisePropertyChanged("JagdhundeLabel");
            }
            
        }
        #endregion Properties
    }
}