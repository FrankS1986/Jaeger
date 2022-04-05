using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.ComponentModel;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using JaegerMeister.MvvmSample.Logic.Ui.Models;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Abschussliste : ViewModelBase, INotifyPropertyChanged
    {
        //TODO: Jahreszahl einfügen
        //Die Menge an gesamten geschossenen Tieren
        int _Abschuesse = 0;
        Service_Abschussliste service_Abschussliste = new Service_Abschussliste();
        public int GesamtAbschuesse
        {
            get
            {
                return _Abschuesse;
            }
            set
            {
                _Abschuesse = value;
                RaisePropertyChanged("GesamtAbschuesse");
            }
        }

        //Hier wird die Methode aufgerufen die dafuer zustaendig ist das datagrid zu füllen.
        //Hier werden auch direkt die Abschuesse gezaehlt und eingefuegt.
        List<JaegerAbschussModel> _AbschussListe;
        public List<JaegerAbschussModel> AbschussListe
        {
            get
            {
                _AbschussListe =  service_Abschussliste.JaegerAbschuesse();
                return _AbschussListe;
            }
            set
            {
                _AbschussListe = value;
                RaisePropertyChanged("AbschussListe");
            }
        }

        //Diese Property fuellt das Datagrid mit den Tieren und wie oft sie erlegt worden sind.
        //Dies schließt Unfaelle mit ein!        
        List<TierAbschussModel> _TierErlegtListe = new List<TierAbschussModel>();       
        public List<TierAbschussModel> TierSchussListe
        {
            get
            {
                _TierErlegtListe = service_Abschussliste.TierAbschussListeMethode(_TierartSelectedItem.Tierart);
                GesamtAbschuesse = 0;
                _Abschuesse = 0;
                foreach (var item in _TierErlegtListe)
                {
                    _Abschuesse += item.Abschüsse;
                }
                GesamtAbschuesse = _Abschuesse;
                return _TierErlegtListe;
            }
            set
            {
                _TierErlegtListe = value;
                RaisePropertyChanged("TierSchussListe");
            }
        }

        //Hier wird die Dropdownliste mit Tierarten gefüllt
        List<TierAbschussModel> _DropDownTiere;
        public List<TierAbschussModel> DropDownTiere
        {
            get
            {   
                _DropDownTiere = service_Abschussliste.TierartListe();
                return _DropDownTiere;                
            }
            set
            {
                _DropDownTiere = value;
                RaisePropertyChanged("DropDownTiere");
            }
        }

        //Hier wird geschaut ob eine andere Tierart ausgewahlt wurde, und dementsprechend
        //die Datenanzeige auf die neue Tierart ausrichtet
        private TierAbschussModel _TierartSelectedItem;
        public TierAbschussModel TierartSelectedItem
        {
            get { return _TierartSelectedItem; }
            set
            {
                _TierartSelectedItem = value;
                RaisePropertyChanged("TierartSelectedItem");
                RaisePropertyChanged("TierSchussListe");
            }
        }
    }
}