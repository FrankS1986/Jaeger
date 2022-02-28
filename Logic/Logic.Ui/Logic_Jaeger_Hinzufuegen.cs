using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JaegerMeister.MvvmSample.Logic.Ui.Models;
using JaegerMeister.MvvmSample.Logic.Ui.Services;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Jaeger_Hinzufuegen : ViewModelBase, INotifyPropertyChanged
    {
        //initiert Service Klasse 
        JaegerHinzufuegenService serv = new JaegerHinzufuegenService();

        public Logic_Jaeger_Hinzufuegen ()
        {
            Funktion = serv.Funktionen();
            Anrede = serv.Anrede();
        }
               
        
        //erstellt Liste vom Typ IDVorNachnameModel, ruft serv. Methode auf zum Anzeigen im Datagrid "JaegerListe"
        private List<IDVorNachnameModel> _listIDVorNachname = new List<IDVorNachnameModel>();
        public List<IDVorNachnameModel> JaegerListe
        {
            get 
            {
                _listIDVorNachname = serv.ListeIDVorNachname();
                return _listIDVorNachname;
            }

            //Set wird nicht benötigt da Liste nur lesen, nicht schreiben soll
            //set 
            //{
            //    _listIDVorNachname = value;
            //    RaisePropertyChanged("JaegerListe");

            //}
         
        }
        private ICommand _btn_jaeger_hinzufuegen;

        public ICommand Btn_jaeger_hinzufuegen
        {
            get
            {
                if (_btn_jaeger_hinzufuegen == null)
                {
                    _btn_jaeger_hinzufuegen = new RelayCommand(() =>
                    {

                        //!!Anrede Hinzufügen zur If schleife!!!
                        if(Tb_vorname != null && Tb_nachname != null && Tb_straße != null && Tb_hausnummer !=null && Tb_postleitzahl!= null && Tb_wohnort != null && Tb_telefonnummer1 != null)
                        {
                            var newItem = new tbl_Jaeger()
                            {
                                Anrede = Cb_anrede.Anrede,
                                Vorname = Tb_vorname,
                                Nachname = Tb_nachname,
                                Straße = Tb_straße,
                                Hausnummer = Tb_hausnummer,
                                Adresszusatz = Tb_adresszusatz,
                                Postleitzahl = Tb_postleitzahl,
                                Wohnort = Tb_wohnort,
                                Telefonnummer1 = Tb_telefonnummer1,
                                Telefonnummer2 = Tb_telefonnummer2,
                                Telefonnummer3 = Tb_telefonnummer3,
                                Email = Tb_email,
                                Geburtsdatum = Dp_geburtstag,
                                Funktion = Cb_funtkion.Funktion,
                                Jagdhund = Tb_jagdhunde
                            };

                            serv.InsertNeuerJaeger(newItem);
                        }
                        else
                        {

                           
                        }
                        
                      


                    });

                }
                return _btn_jaeger_hinzufuegen;
                 
            }
            
        }

        private ICommand _btn_jaeger_entfernen;

        public ICommand Btn_jaeger_entfernen
        {
            get
            {
                if (_btn_jaeger_entfernen == null)
                {
                    _btn_jaeger_entfernen = new RelayCommand(() =>
                    {
                      
                    });

                }
                return _btn_jaeger_entfernen;
            }
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


        private tbl_Funktionen _cb_funktion;
        public tbl_Funktionen Cb_funtkion
        {
            get
            {
                return _cb_funktion;
            }
            set
            {
                _cb_funktion = value;
                RaisePropertyChanged("Cb_funktion");
            }
        }

        private List<tbl_Funktionen> _funktion;
        public List<tbl_Funktionen> Funktion
        {
            get
            {
                return _funktion;
                
            }
            set
            {
                _funktion = value;
                RaisePropertyChanged("Funktion");
            }
        }

        private tbl_Anrede _cb_anrede;
        public tbl_Anrede Cb_anrede
        {
            get
            {
                return _cb_anrede;
            }
            set
            {
                _cb_anrede = value;
                RaisePropertyChanged("Cb_anrede");
            }
        }

        private List<tbl_Anrede> _anrede;
        public List<tbl_Anrede> Anrede
        {
            get
            {
                return _anrede;
                ;
            }
            set
            {
                _anrede = value;
                RaisePropertyChanged("Anrede");
            }
        }

        private DateTime _dp_geburtstag;
        public DateTime Dp_geburtstag
        {
            get
            {
                return _dp_geburtstag;
            }
            set
            {
                _dp_geburtstag = value;
                RaisePropertyChanged("Dp_geburtstag");
            }
        }

        #region properties TextBoxen
        private string _tb_vorname;
        public string Tb_vorname
        {
            get
            {
                return _tb_vorname;
            }
            set
            {
                _tb_vorname= value;
                RaisePropertyChanged("Tb_vorname");
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

        private string _tb_straße;
        public string Tb_straße
        {
            get
            {
                return _tb_straße;
            }
            set
            {
                _tb_straße= value;
                RaisePropertyChanged("Tb_straße");
            }
        }

        private string _tb_hausnummer;
        public string Tb_hausnummer
        {
            get
            {
                return _tb_hausnummer;
            }
            set
            {
                _tb_hausnummer= value;
                RaisePropertyChanged("Tb_hausnummer");
            }
        }

        private string _tb_adresszusatz;
        public string Tb_adresszusatz
        {
            get
            {
                return _tb_adresszusatz;
            }
            set
            {
                _tb_adresszusatz= value;
                RaisePropertyChanged("Tb_adresszusatz");
            }
        }

        private string _tb_postleitzahl;
        public string Tb_postleitzahl
        {
            get
            {
                return _tb_postleitzahl;
            }
            set
            {
                _tb_postleitzahl = value;
                RaisePropertyChanged("Tb_postleitzahl");
            }
        }

        private string _tb_wohnort;
        public string Tb_wohnort
        {
            get
            {
                return _tb_wohnort;
            }
            set
            {
                _tb_wohnort= value;
                RaisePropertyChanged("Tb_wohnort");
            }
        }

        private string _tb_telefonnummer1;
        public string Tb_telefonnummer1
        {
            get
            {
                return _tb_telefonnummer1;
            }
            set
            {
                _tb_telefonnummer1 = value;
                RaisePropertyChanged("Tb_telefonnummer1");
            }
        }

        private string _tb_telefonnummer2;
        public string Tb_telefonnummer2
        {
            get
            {
                return _tb_telefonnummer2;
            }
            set
            {
                _tb_telefonnummer2 = value;
                RaisePropertyChanged("Tb_telefonnummer2");
            }
        }

        private string _tb_telefonnummer3;
        public string Tb_telefonnummer3
        {
            get
            {
                return _tb_telefonnummer3;
            }
            set
            {
                _tb_telefonnummer3 = value;
                RaisePropertyChanged("Tb_telefonnummer3");
            }
        }

        private string _tb_email;
        public string Tb_email
        {
            get
            {
                return _tb_email;
            }
            set
            {
                _tb_email= value;
                RaisePropertyChanged("Tb_email"); 
            }
        }

       private string _tb_jagdhunde;
        public string Tb_jagdhunde
        {
            get
            {
                return _tb_jagdhunde;
            }
            set
            {
                _tb_jagdhunde = value;
                RaisePropertyChanged("tb_jagdhunde");
            }
        }
# endregion properties TextBoxen

    }
}
