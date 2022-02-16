using System.Windows.Input;
using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace JaegerMeister.MvvmSample.Logic.Ui
{

    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        public string WindowTitle { get; private set; }
        public MainViewModel()
        {
                              
            if (IsInDesignMode)
            {
                WindowTitle = "MvvSample (Designmode)";
                
            }
            else
            {
                WindowTitle = "MvvSample";
               
            }
           
        }

        #region Commands
        private ICommand _Btn_Bestaetigen;
        public ICommand Btn_Bestaetigen
        {
            get
            {
                if (_Btn_Bestaetigen == null)
                {
                    _Btn_Bestaetigen = new RelayCommand(() =>
                   {

                   });
                }
                return _Btn_Bestaetigen;
            }
            
        }

        private ICommand _Btn_Registrieren;
        public ICommand Btn_Registrieren
        {
            get
            {
                if (_Btn_Registrieren == null)
                {
                    _Btn_Registrieren = new RelayCommand(() =>
                    {

                    });
                }

                return _Btn_Registrieren;
            }
        }


        private ICommand _Btn_Abbruch;
        public ICommand Btn_Abbruch
        {
            get
            {
                if(_Btn_Abbruch== null)
                {
                    _Btn_Abbruch = new RelayCommand(() =>
                   {

                   });
                }
                
                return _Btn_Abbruch;
            }
        }

        private ICommand _Btn_Passwortvergessen;
        public ICommand Btn_Passwortvergessen
        {
            get
            {
                if(_Btn_Passwortvergessen == null)
                {
                    _Btn_Passwortvergessen = new RelayCommand(() =>
                   {

                   });
                }
                return _Btn_Passwortvergessen;
            }
        }



        private string _Tb_Benutzername;
        public string Tb_Benutzername
        {
            get
            {

            }
        }
    }
    #endregion Commands



}