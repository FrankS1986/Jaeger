using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.Services;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_PasswortErneuern : ViewModelBase, INotifyPropertyChanged
    {
        PasswortErneuernService passwortErneuernService = new PasswortErneuernService();


        public Logic_PasswortErneuern()
        {

        }


        private string _Benutzername;
        public string Benutzername
        {
            get
            {
                return _Benutzername;

            }

            set
            {
                _Benutzername = value;
                RaisePropertyChanged("Benutzername");
            }
        }



        private string _neuespasswort;
        public string Neuespasswort
        {
            get
            {
                return _neuespasswort;

            }

            set
            {
                _neuespasswort = value;
                RaisePropertyChanged("Neuespasswort");
            }
        }
        private string _passwortbestaetigen;
        public string Passwortbestaetigen
        {
            get
            {
                return _passwortbestaetigen;

            }

            set
            {
                _passwortbestaetigen = value;
                RaisePropertyChanged("Passwortbestaetigen");
            }
        }



        private ICommand _Bestaetigen;
        public ICommand Bestaetigen
        {
            get
            {
                if (_Bestaetigen == null)
                {
                    _Bestaetigen = new RelayCommand(() =>
                    {

                        if (passwortErneuernService.PasswortErneuern(Benutzername, Neuespasswort))
                        {
                            if (Neuespasswort == Passwortbestaetigen)
                            {

                                Messenger.Default.Send<PasswortErneuernErfolgsMessage>(new PasswortErneuernErfolgsMessage { passwortErneuernErfolgsMessage = passwortErneuernService.passwortVergeben });

                                passwortErneuernService.PasswortLoeschen(Benutzername);

                            }

                            else
                            {
                                Messenger.Default.Send<PasswortErneuernVergebenMessage>(new PasswortErneuernVergebenMessage { IstVergeben = false });
                            }
                        }
                        else
                        {
                            Messenger.Default.Send<PasswortErneuernVergebenMessage>(new PasswortErneuernVergebenMessage { IstVergeben = true });
                        }

                    });

                }
                return _Bestaetigen;
            }
        }



    }
}
