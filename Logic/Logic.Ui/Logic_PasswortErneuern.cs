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


        #region Properties

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



        private string _Neuespasswort;
        public string Neuespasswort
        {
            get
            {
                return _Neuespasswort;

            }

            set
            {
                _Neuespasswort = value;
                RaisePropertyChanged("Neuespasswort");
            }
        }
        private string _Passwortbestaetigen;
        public string Passwortbestaetigen
        {
            get
            {
                return _Passwortbestaetigen;

            }

            set
            {
                _Passwortbestaetigen = value;
                RaisePropertyChanged("Passwortbestaetigen");
            }
        }

        #endregion Properties

        private ICommand _Bestaetigen;
        public ICommand Bestaetigen
        {
            get
            {
                if (_Bestaetigen == null)
                {
                    _Bestaetigen = new RelayCommand(() =>
                    {

                        if (passwortErneuernService.PasswoerterUeberprüfen(Benutzername, Neuespasswort))
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
