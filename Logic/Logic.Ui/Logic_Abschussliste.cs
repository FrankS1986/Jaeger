using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.ComponentModel;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using JaegerMeister.MvvmSample.Logic.Ui.Models;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Abschussliste : ViewModelBase, INotifyPropertyChanged
    {

        //Die Menge an gesamten geschossenen Tieren
        int _abschuesse = 0;
        Service_Abschussliste service_Abschussliste = new Service_Abschussliste();
        public int GesamtAbschuesse
        {
            get
            {
                return _abschuesse;
            }
            set
            {
                _abschuesse = value;
                RaisePropertyChanged("GesamtAbschuesse");
            }
        }

        //Hier wird die Methode aufgerufen die dafuer zustaendig ist das datagrid zu füllen.
        //Hier werden auch direkt die Abschuesse gezaehlt und eingefuegt.
        List<JaegerAbschussModel> _abschussListe;
        public List<JaegerAbschussModel> AbschussListe
        {
            get
            {
                _abschussListe =  service_Abschussliste.JaegerAbschuesse();
                return _abschussListe;
            }
            set
            {
                _abschussListe = value;
                RaisePropertyChanged("AbschussListe");
            }
        }

        //Diese Property fuellt das Datagrid mit den Tieren und wie oft sie erlegt worden sind.
        //Dies schließt Unfaelle mit ein!        
        List<TierAbschussModel> _tierErlegtListe = new List<TierAbschussModel>();       
        public List<TierAbschussModel> TierSchussListe
        {
            get
            {
                _tierErlegtListe = service_Abschussliste.TierAbschussListeMethode(_tierartSelectedItem.Tierart);
                GesamtAbschuesse = 0;
                _abschuesse = 0;
                foreach (var item in _tierErlegtListe)
                {
                    _abschuesse += item.Abschüsse;
                }
                GesamtAbschuesse = _abschuesse;
                return _tierErlegtListe;
            }
            set
            {
                _tierErlegtListe = value;
                RaisePropertyChanged("TierSchussListe");
            }
        }

        //Hier wird die Dropdownliste mit Tierarten gefüllt
        List<TierAbschussModel> _dropDownTiere;
        public List<TierAbschussModel> DropDownTiere
        {
            get
            {   
                _dropDownTiere = service_Abschussliste.TierartListe();
                return _dropDownTiere;                
            }
            set
            {
                _dropDownTiere = value;
                RaisePropertyChanged("DropDownTiere");
            }
        }

        //Hier wird geschaut ob eine andere Tierart ausgewahlt wurde, und dementsprechend
        //die Datenanzeige auf die neue Tierart ausrichtet
        private TierAbschussModel _tierartSelectedItem;
        public TierAbschussModel TierartSelectedItem
        {
            get { return _tierartSelectedItem; }
            set
            {
                _tierartSelectedItem = value;
                RaisePropertyChanged("TierartSelectedItem");
                RaisePropertyChanged("TierSchussListe");
            }
        }
    }
}