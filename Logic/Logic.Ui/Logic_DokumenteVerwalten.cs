using System.Collections.Generic;
using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_DokumenteVerwalten : ViewModelBase, INotifyPropertyChanged
    {
        DokumenteVerwaltenService serv = new DokumenteVerwaltenService();
        public Logic_DokumenteVerwalten()
        {
            Dokumente = serv.DokumenteListe();
            Messenger.Default.Register<string>(this, (prop) =>
            {
                if (prop.Equals("DokumenteVerwaltenMessage"))
                {
                    Dokumente = serv.DokumenteListe();
                }
            });
        }
        #region Properties
        private List<string> _DokumenteListbox;
        public List<string> Dokumente
        {
            get
            {
                return _DokumenteListbox;
            }
            set
            {
                _DokumenteListbox = value;
                RaisePropertyChanged("DokumenteListbox");
            }
        }
        private string _SelectDokumentListbox;
        public string SelectDokumentListbox
        {
            get
            {
                return _SelectDokumentListbox;
            }
            set
            {
                _SelectDokumentListbox = value;
                RaisePropertyChanged("SelectDokumentListbox");
            }
        }
        private string _DateinameTextbox;
        public string Dateiname
        {
            get
            {
                return _DateinameTextbox;
            }
            set
            {
                _DateinameTextbox = value;
                RaisePropertyChanged("Dateiname");
            }
        }
        private ICommand _DokumentloeschenButton;
        public ICommand DokumentloeschenButton
        {
            get
            {
                if (_DokumentloeschenButton == null)
                {
                    _DokumentloeschenButton = new RelayCommand(() =>
                    {
                        if (SelectDokumentListbox != null)
                        {
                            Messenger.Default.Send<DokumenteVerwaltenLoeschenMessage>(new DokumenteVerwaltenLoeschenMessage { Dokument = SelectDokumentListbox });
                           Dokumente= serv.DokumenteListe();
                        }
                    });

                }
                return _DokumentloeschenButton;
            }
        }
        private ICommand _DokumentBearbeitenButton;
        public ICommand DokumentBearbeitenButton
        {
            get
            {
                if (_DokumentBearbeitenButton == null)
                {
                    _DokumentBearbeitenButton = new RelayCommand(() =>
                    {
                        if (SelectDokumentListbox != null)
                        {
                            serv.DokumenteBearbeiten(SelectDokumentListbox);
                        }
                    });
                }
                return _DokumentBearbeitenButton;
            }
        }
        #endregion
    }

}
