using System;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using JaegerMeister.MvvmSample.Logic.Ui.Models;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Abschussliste : ViewModelBase, INotifyPropertyChanged
    {

        //Die Menge an gesamten geschossenen Tieren
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

        //Hier wird die Methode aufgerufen die dafür zuständig ist das datagrid zu füllen.
        List<JaegerAbschussModel> _abschussListe;
        public List<JaegerAbschussModel> AbschussListe
        {
            get
            {
                return service_Abschussliste.JaegerAbschuesse();
            }
            set
            {
                _abschussListe = value;
                RaisePropertyChanged("AbschussListe");
            }
        }
        List<TierAbschussModel> _tierErlegtListe = new List<TierAbschussModel>();
        public List<TierAbschussModel> TierSchussListe
        {
            get
            {
                _tierErlegtListe = service_Abschussliste.TierAbschussListeMethode(_tierartSelectedItem);
                return _tierErlegtListe;
            }
            set
            {
                _tierErlegtListe = value;
                RaisePropertyChanged("TierSchussListe");
            }
        }


        //Hier wird die Dropdownliste mit Tierarten gefüllt
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
        //Hier wird geschaut ob eine andere Tierart ausgewahlt wurde, und dementsprechend
        //die Datenanzeige auf die neue Tierart ausrichtet
        private string _tierartSelectedItem;
        public string TierartSelectedItem
        {
            get { return _tierartSelectedItem; }
            set
            {
                _tierartSelectedItem = value;
                RaisePropertyChanged("TierartSelectedItem");
                RaisePropertyChanged("TierSchussListe");
            }
        }

        public Logic_Abschussliste()
        {

        }
    }
}
