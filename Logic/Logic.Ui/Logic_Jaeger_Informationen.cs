using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.Models;
using System.Collections.Generic;

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
                
                RaisePropertyChanged("LB_jaeger");
            }
        }

       

        private string _lab_vor_und_nachname;
        public string Lab_vor_und_nachname
        {
            get
            {
                return _lab_vor_und_nachname;
            }
            set
            {
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
            }
        }


        private string _lab_geburtstag;
        public string Lab_geburtstag
        {
            get
            {
                return _lab_geburtstag;
            }
            set
            {
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
            }
        }


        private int _lab_postleitzahl;
        public int Lab_postleitzahl
        {
            get
            {
                return _lab_postleitzahl;
            }
            set
            {
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
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
                //Datenbankverbindung benötigt
            }
        }


        private int _lab_jagdhunde;
        public int Lab_jagdhunde
        {
            get
            {
                return _lab_jagdhunde;
            }
            set
            {
                //Datenbankverbindung benötigt
            }
        }

    }
}
