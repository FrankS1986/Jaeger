using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Wildunfaelle : ViewModelBase, INotifyPropertyChanged
    {
        WildunfaelleService serv = new WildunfaelleService();
        public Logic_Wildunfaelle()
        {
            // Ort wird zurück gesetz beim neu laden des Fensters
            Datum = DateTime.Today.ToString();
            Messenger.Default.Register<string>(this, (prop) =>
            {
                if (prop.Equals("zuruecksetzen"))
                {
                    Ort = null;

                }
            });
            Tiere = serv.Tiere();


        }
        #region Properties
        private DateTime _startDate;
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                RaisePropertyChanged("StartDate");
            }
        }



        private string _ort;
        public string Ort
        {
            get { return _ort; }
            set { _ort = value; RaisePropertyChanged("Ort"); }
        }


        private tbl_Tiere _selectItem;
        public tbl_Tiere SelectItem
        {
            get { return _selectItem; }
            set { _selectItem = value; RaisePropertyChanged("SelectItem"); }
        }

        private string _datum;
        public string Datum
        {
            get { return _datum; }
            set { _datum = value; RaisePropertyChanged("Datum"); }
        }

        private List<tbl_Tiere> _tiere;
        public List<tbl_Tiere> Tiere
        {
            get
            {
                return _tiere;
            }
            set
            {
                _tiere = value;
                RaisePropertyChanged("Tiere");
            }
        }

        #endregion Properties

        private ICommand _wildunfaelle;
        public ICommand Wildunfaelle
        {
            get
            {
                if (_wildunfaelle == null)
                {
                    _wildunfaelle = new RelayCommand(() =>
                    {
                        if (StartDate <= DateTime.Today)
                        {
                            if (!string.IsNullOrEmpty(Ort) && Tiere != null && !Ort.Contains(" "))
                            {

                                // neuer eintrag In Datenbank
                                Messenger.Default.Send<WildunfaelleErfolgsMessage>(new WildunfaelleErfolgsMessage { Wildunfallhinzugefuegt = serv.Tierhinzufuegen(StartDate, SelectItem.Tiere_ID, Ort) });

                                var newitem = new tbl_Jagderfolge()

                                {
                                    Jäger_ID = serv.JaegerID,
                                    Termine_ID = serv.DatumID,
                                    Tiere_ID = serv.TierartID


                                };

                                serv.InsertJagdErfolge(newitem);

                            }

                            else
                            {
                                Messenger.Default.Send<WildunfaelleErfolgsMessage>(new WildunfaelleErfolgsMessage { Wildunfallhinzugefuegt = false });
                            }
                        }

                        else
                        {
                            Messenger.Default.Send<WildunfaelleErfolgsMessage>(new WildunfaelleErfolgsMessage { Wildunfallhinzugefuegt = false });
                        }

                    });

                }
                return _wildunfaelle;
            }
        }
    }
}
