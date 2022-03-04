using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Dokumente;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_EinladungErstellen : ViewModelBase, INotifyPropertyChanged
    {

        EinladungenErstellenService serv = new EinladungenErstellenService();


        public Logic_EinladungErstellen()
        {
            
            Termine = serv.Termine();

            Messenger.Default.Register<string>(this, (x) =>


             {
                 if (x.Equals("BereitsEingeladenMessage"))
                 {
                     if (SelectTermin != null)
                     {
                         BereitsEingeladen = serv.Eingeladen(SelectTermin.Termine_ID);
                         Einladen = serv.JaegerListe();

                     }

                 }
             });

            

            Messenger.Default.Register<string>(this, (prop) =>
            {
                if (prop.Equals("ButtonEinladungErstellen"))
                {
                    if (SelectEinladen != null && SelectTermin != null)
                    {
                        var newitem = new tbl_Postausgang()

                        {
                            Dokumente_ID = 1,
                            Jäger_ID = SelectEinladen.Jäger_ID,
                            Termine_ID = SelectTermin.Termine_ID,
                            DatumUhrzeit = DateTime.Now,

                        };
                        string x = SelectTermin.DatumUhrzeit.Year.ToString();
                        string zusammengesetzt = SelectTermin.Typ + x + SelectEinladen.Nachname;
                        serv.CreateWordDocument(Paths.GetFilePath("Logic\\Logic.Ui\\Dokumente\\Einladungen.docx"), Paths.GetFilePath("Logic\\Logic.Ui\\Dokumente\\" + zusammengesetzt + ".docx"), SelectEinladen.Jäger_ID);
                        Messenger.Default.Send<EinladungenErstellenErfolgsMessage>(new EinladungenErstellenErfolgsMessage { erfolg = serv.InsertPostausgang(newitem) });
                        BereitsEingeladen = serv.Eingeladen(SelectTermin.Termine_ID);
                        Einladen = serv.JaegerListe();
                    }
                    else
                    {
                        Messenger.Default.Send<EinladungenErstellenErfolgsMessage>(new EinladungenErstellenErfolgsMessage { erfolg = false });
                    }







                }
            });

        }

        private ICommand _EinlandungSenden;
        public ICommand EinlandungSenden
        {
            get
            {
                if (_EinlandungSenden == null)
                {
                    _EinlandungSenden = new RelayCommand(() =>
                    {






                        if (SelectEinladen != null)
                        {

                        }

                    });
                }
                return _EinlandungSenden;
            }
        }

        private List<string> _BereitsEingeladen;

        public List<string> BereitsEingeladen
        {
            get
            {
                return _BereitsEingeladen;
            }
            set
            {
                _BereitsEingeladen = value;
                RaisePropertyChanged("BereitsEingeladen");
            }
        }



        private ICommand _Abbrechen;
        public ICommand Abbrechen
        {
            get
            {
                if (_Abbrechen == null)
                {
                    _Abbrechen = new RelayCommand(() =>
                    {


                        ///Logic
                    });
                }
                return _Abbrechen;
            }
        }



        private ICommand _Com;
        public ICommand Com
        {
            get
            {
                if (_Com == null)
                {
                    _Com = new RelayCommand(() =>
                    {


                        ///Logic
                    });
                }
                return _Com;
            }
        }

        private List<tbl_Termine> _Termine;
        public List<tbl_Termine> Termine
        {
            get
            {
                return _Termine;
            }
            set
            {
                _Termine = value;
                RaisePropertyChanged("Termine");
            }
        }

        private tbl_Termine _SelectTermin;
        public tbl_Termine SelectTermin
        {
            get
            {
                return _SelectTermin;
            }
            set
            {
                _SelectTermin = value;
                RaisePropertyChanged("SelectTermin");
            }
        }


        private List<tbl_Jaeger> _Einladen;
        public List<tbl_Jaeger> Einladen
        {
            get
            {
                return _Einladen;
            }
            set
            {
                _Einladen = value;
                RaisePropertyChanged("Einladen");
            }
        }

        private tbl_Jaeger _SelectEinladen;
        public tbl_Jaeger SelectEinladen
        {
            get
            {
                return _SelectEinladen;
            }
            set
            {
                _SelectEinladen = value;
                RaisePropertyChanged("SelectEinladen");
            }
        }

    }
}
