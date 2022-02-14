using System;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Abschussliste : ViewModelBase, INotifyPropertyChanged
    {
        string _abschuesse = "";
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

        List<string> _jaegerBezogeneAbschuesse;
        public List<string> JaegerBezogeneAbschuesse
        {
            get
            {
                return _jaegerBezogeneAbschuesse;
            }
            set
            {
                _jaegerBezogeneAbschuesse = value;
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
            }
        }

        List<string> _dropDownTiere;
        public List<string> DropDownTiere
        {
            get
            {
                return _dropDownTiere;
            }
            set
            {
                _dropDownTiere = value;
            }
        }
        ICommand _abschuesseHinzufuegen;
        public ICommand AbschuesseHinzufuegen
        {
            get
            {
                _abschuesseHinzufuegen = new RelayCommand(() =>
                {
                    //WAS SOLL DER BUTTON TUN?
                });
                return _abschuesseHinzufuegen;
            }
        }
        public Logic_Abschussliste()
        {
            _jaegerBezogeneAbschuesse = new List<string>();
            _tierartBezogeneAbschuesse = new List<string>();
            _dropDownTiere = new List<string>();
        }
    }
}
