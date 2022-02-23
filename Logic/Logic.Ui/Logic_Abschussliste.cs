using System;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.Services;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Abschussliste : ViewModelBase, INotifyPropertyChanged
    {
        string _abschuesse = "";
       
        Service_Abschussliste service_Abschussliste = new Service_Abschussliste();
        public string Abschuesse
        {
            get
            {
                return _abschuesse;
            }
            set
            {
                _abschuesse = value;
            }
        }

        List<string> _jaegerBezogeneAbschuesse = new List<string>();
        public List<string> JaegerBezogeneAbschuesse
        {
            get
            {
                List<GesamtName> namensBauer = service_Abschussliste.GesamtnameMethode();

                foreach(var item in namensBauer)
                {
                    
                    _jaegerBezogeneAbschuesse.Add(item.Vorname + " " + item.Nachname);
                }
                return _jaegerBezogeneAbschuesse;
            }
            set
            {
                _jaegerBezogeneAbschuesse = value;
                RaisePropertyChanged("JaegerBezogeneAbschuesse");
            }
        }        
        List<string> _tierartBezogeneAbschuesse;
        public List<string> TierartBezogeneAbschuesse
        {
            get
            {
                return _tierartBezogeneAbschuesse;
            }
            set
            {
                _tierartBezogeneAbschuesse = value;
                RaisePropertyChanged("TierartBezogeneAbschuesse");
            }            
        }

        List<tbl_Tiere> _dropDownTiere;
        public List<tbl_Tiere> DropDownTiere
        {
            get
            {

                return service_Abschussliste.TierartListe();
            }
            set
            {
                _dropDownTiere = value;
                RaisePropertyChanged("DropDownTiere");
            }
        }


        public Logic_Abschussliste()
        {
            //_jaegerBezogeneAbschuesse = new List<tbl_Jaeger>();
            //_tierartBezogeneAbschuesse = new List<string>();
            //_dropDownTiere = new List<string>();
        }
    }
}
