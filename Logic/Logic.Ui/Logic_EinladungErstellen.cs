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
using static JaegerMeister.MvvmSample.Logic.Ui.Services.EinladungenErstellenService;

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



        }

        private ICommand _einlandungSenden;
        public ICommand EinlandungSenden
        {
            get
            {
                if (_einlandungSenden == null)
                {
                    _einlandungSenden = new RelayCommand(() =>
                    {



                        if (SelectTermin != null)
                        {
                            
                            foreach (var item in Einladen)
                            {
                                if (item.Eingeladen)
                                {
                                    var newitem = new tbl_Postausgang()

                                    {
                                        Dokumente_ID = 1,
                                        Jäger_ID = item.ID,
                                        Termine_ID = SelectTermin.Termine_ID,
                                        DatumUhrzeit = DateTime.Now,

                                    };

                                    string x = SelectTermin.DatumUhrzeit.Year.ToString();
                                    string zusammengesetzt = SelectTermin.Typ + x + item.Nachname;
                                    serv.CreateWordDocument(item, Paths.GetFilePath("Logic\\Logic.Ui\\Dokumente\\Einladungen.docx"), Paths.GetFilePath("Logic\\Logic.Ui\\Dokumente\\" + zusammengesetzt + ".docx"));
                                    serv.InsertPostausgang(newitem); 
                                    BereitsEingeladen = serv.Eingeladen(SelectTermin.Termine_ID);
                                    Einladen = serv.JaegerListe();
                                }
                            }

                            Messenger.Default.Send<EinladungenErstellenErfolgsMessage>(new EinladungenErstellenErfolgsMessage { erfolg = true });

                        }
                        else
                        {
                            Messenger.Default.Send<EinladungenErstellenErfolgsMessage>(new EinladungenErstellenErfolgsMessage { erfolg = false });
                        }



                    });
                }
                return _einlandungSenden;
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


        private List<Einladung> _Einladen;
        public List<Einladung> Einladen
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
