using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Wildunfaelle : ViewModelBase, INotifyPropertyChanged
    {
        WildunfaelleService serv = new WildunfaelleService();
        public Logic_Wildunfaelle()
        {
            Datum = DateTime.Today.ToString();
            Messenger.Default.Register<string>(this, (prop) =>
            {
                if (prop.Equals("B"))
                {
                    Ort = null;

                }
            });
            Tiere = serv.Tiere();


        }
        private DateTime _StartDate;
        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
                RaisePropertyChanged("StartDate");
            }
        }



        private string _Ort;
        public string Ort
        {
            get { return _Ort; }
            set { _Ort = value; RaisePropertyChanged("Ort"); }
        }


        private tbl_Tiere _SelectItem;
        public tbl_Tiere SelectItem
        {
            get { return _SelectItem; }
            set { _SelectItem = value; RaisePropertyChanged("SelectItem"); }
        }

        private string _Datum;
        public string Datum
        {
            get { return _Datum; }
            set { _Datum = value; RaisePropertyChanged("Datum"); }
        }

        private List<tbl_Tiere> _Tiere;
        public List<tbl_Tiere> Tiere
        {
            get
            {
                return _Tiere;
            }
            set
            {
                _Tiere = value;
                RaisePropertyChanged("Tiere");
            }
        }


        private ICommand _Wildunfaelle;
        public ICommand Wildunfaelle
        {
            get
            {
                if (_Wildunfaelle == null)
                {
                    _Wildunfaelle = new RelayCommand(() =>
                    {
                        if (StartDate <= DateTime.Today)
                        {
                            if (!string.IsNullOrEmpty(Ort) && Tiere != null)
                            {


                                Messenger.Default.Send<WildunfaelleErfolgsMessage>(new WildunfaelleErfolgsMessage { wildunfallhizugefügt = serv.Tierhinzufuegen(StartDate, SelectItem.Tiere_ID, Ort) });

                                var newitem = new tbl_Jagderfolge()

                                {
                                    Jäger_ID = serv.jaegerID,
                                    Termine_ID = serv.datumID,
                                    Tiere_ID = serv.tierartID


                                };

                                serv.InsertJagdErfolge(newitem);

                            }

                            else
                            {
                                Messenger.Default.Send<WildunfaelleErfolgsMessage>(new WildunfaelleErfolgsMessage { wildunfallhizugefügt = false });
                            }
                        }

                        else
                        {
                            Messenger.Default.Send<WildunfaelleErfolgsMessage>(new WildunfaelleErfolgsMessage { wildunfallhizugefügt = false });
                        }

                    });

                }
                return _Wildunfaelle;
            }
        }
    }
}
