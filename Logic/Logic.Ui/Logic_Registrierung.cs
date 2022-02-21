using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Registrierung : ViewModelBase, INotifyPropertyChanged
    {

        private Service serv = new Service();


        public Logic_Registrierung()
        {
            BBvorname = "#230C0F";
            BBnachname = "#230C0F";
            BBpasswort = "#230C0F"; 
            BBbenutzername = "#230C0F";
            BBantwort = "#230C0F";

            
            Cb_sicherheitsfrage = serv.Sichheitsfragen();

               
        }





        private ICommand _btn_abbrechen;

        public ICommand Btn_abbrechen
        {
            get
            {
                if (_btn_abbrechen == null)
                {
                    _btn_abbrechen = new RelayCommand(() =>
                    {



                    });
                }
                return _btn_abbrechen;
            }
        }
        private ICommand _btn_bestaetigen;

        public ICommand Btn_bestaetigen
        {
            get
            {
                if (_btn_bestaetigen == null)
                {
                    _btn_bestaetigen = new RelayCommand(() =>
                    {
                        if (Cb_sicherheitsfrage != null && !string.IsNullOrEmpty(Tb_vorname) && !string.IsNullOrEmpty(Tb_nachname) && !string.IsNullOrEmpty(Tb_benutzername) && !string.IsNullOrEmpty(Tb_passwort) && !string.IsNullOrEmpty(Tb_sicherheitsfrage_antwort))
                        {
                            var newItem = new tbl_Login()
                            {

                                UserVorname = Tb_vorname,
                                UserNachname = Tb_nachname,
                                Loginname = Tb_benutzername,
                                Passwort = Tb_passwort,
                                Antwort = Tb_sicherheitsfrage_antwort,
                                DatumUhrzeit = DateTime.Now
                            };

                            Messenger.Default.Send<RegistrierungsErfolgsMessage>(new RegistrierungsErfolgsMessage { Success = serv.Insert(newItem, Tb_benutzername) });

                            //anpassen
                            if (serv.BenutzerVorhanden)
                            {
                                tbl_Sicherheitsfragen FrageInhalt = new tbl_Sicherheitsfragen()
                                {
                                    Frage = SelectItem.Frage
                                };


                                serv.InsertAbfrage(SelectItem.Sicherheitsfragen_ID, Tb_benutzername, FrageInhalt);

                                var abfrage = new tbl_Abfrage()
                                {

                                    Login_ID = serv.login_ID,
                                    Sicherheitsfragen_ID = serv.sicherheitsfragen_ID

                                };
                                serv.InsertAB(abfrage);
                            }

                            else
                            {
                                Messenger.Default.Send<RegistrierungsAbfrageBenutzer>(new RegistrierungsAbfrageBenutzer { SuccessBenutzer = true });
                                BBbenutzername = "Red";

                            }

                        }

                        // für alle textfelder noch machen
                        else
                        {
                            Messenger.Default.Send<RegistrierungsErfolgsMessage>(new RegistrierungsErfolgsMessage { Success = false });
                            if (string.IsNullOrEmpty(Tb_vorname))
                            {
                                BBvorname = "Red";
                            }
                            else { BBvorname = "#230C0F"; }

                            if (string.IsNullOrEmpty(Tb_nachname))
                            {
                                BBnachname = "Red";
                            }
                            else { BBnachname = "#230C0F"; }

                            if (string.IsNullOrEmpty(Tb_sicherheitsfrage_antwort))
                            {
                                BBantwort = "Red";
                            }
                            else { BBantwort = "#230C0F"; }

                            if (string.IsNullOrEmpty(Tb_benutzername))
                            {
                                BBbenutzername = "Red";
                            }
                            else { BBbenutzername = "#230C0F"; }

                            if (string.IsNullOrEmpty(Tb_passwort))
                            {
                                BBpasswort = "Red";
                            }
                            else { BBpasswort = "#230C0F"; }
                        }


                    });
                }
                return _btn_bestaetigen;
            }
        }

        private string _BBvorname;

        public string BBvorname
        {
            get
            {
                return _BBvorname;
            }
            set
            {
                _BBvorname = value;
                RaisePropertyChanged("BBvorname");
            }
        }


        private string _BBnachname;

        public string BBnachname
        {
            get
            {
                return _BBnachname;
            }
            set
            {
                _BBnachname = value;
                RaisePropertyChanged("BBnachname");
            }
        }




        private string _BBbenutzername;

        public string BBbenutzername
        {
            get
            {
                return _BBbenutzername;
            }
            set
            {
                _BBbenutzername = value;
                RaisePropertyChanged("BBbenutzername");
            }
        }

        private string _BBantwort;

        public string BBantwort
        {
            get
            {
                return _BBantwort;
            }
            set
            {
                _BBantwort = value;
                RaisePropertyChanged("BBantwort");
            }
        }


        private string _BBpasswort;

        public string BBpasswort
        {
            get
            {
                return _BBpasswort;
            }
            set
            {
                _BBpasswort = value;
                RaisePropertyChanged("BBpasswort");
            }
        }


        private string _tb_vorname;

        public string Tb_vorname
        {
            get
            {
                return _tb_vorname;
            }
            set
            {
                _tb_vorname = value;
                RaisePropertyChanged("Tb_vorname");
            }
        }

        private tbl_Sicherheitsfragen _selectItem;

        public tbl_Sicherheitsfragen SelectItem
        {
            get
            {
                return _selectItem;
            }
            set
            {
                _selectItem = value;
                RaisePropertyChanged("selectItem");
            }
        }

        private string _tb_nachname;

        public string Tb_nachname
        {
            get
            {
                return _tb_nachname;
            }
            set
            {
                _tb_nachname = value;
                RaisePropertyChanged("Tb_nachname");
            }
        }

        private string _tb_benutzername;

        public string Tb_benutzername
        {
            get
            {
                return _tb_benutzername;
            }
            set
            {
                _tb_benutzername = value;
                RaisePropertyChanged("Tb_benutzername");
            }
        }

        private string _tb_passwort;

        public string Tb_passwort
        {
            get
            {
                return _tb_passwort;
            }
            set
            {
                _tb_passwort = value;
                RaisePropertyChanged("Tb_passwort");
            }
        }

        private string _tb_sicherheitsfrage_antwort;

        public string Tb_sicherheitsfrage_antwort
        {
            get
            {
                return _tb_sicherheitsfrage_antwort;
            }
            set
            {
                _tb_sicherheitsfrage_antwort = value;
                RaisePropertyChanged("Tb_sicherheitsfrage_antwort");
            }
        }

        private List<tbl_Sicherheitsfragen> _cb_sicherheitsfrage;

        public List<tbl_Sicherheitsfragen> Cb_sicherheitsfrage
        {
            get
            {
                return _cb_sicherheitsfrage;
            }
            set
            {
                _cb_sicherheitsfrage = value;
                RaisePropertyChanged("Cb_sicherheitsfrage");
            }
        }
      


    }
}
