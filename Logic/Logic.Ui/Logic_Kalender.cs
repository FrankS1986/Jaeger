using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using JaegerMeister.MvvmSample.Logic.Ui.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Globalization;



namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Logic_Kalender : ViewModelBase, INotifyPropertyChanged
    {
        //public HashSet<DateTime> Dates { get; } = new HashSet<DateTime>();
        KalenderService serv = new KalenderService();

        public Logic_Kalender()
        {
            Dg_TermineKalender = serv.Termine();
            Dg_KalenderAnzeige = serv.NextTermin(DateTime.Now);
        }

        private DateTime _selectedDates;
        public DateTime SelectedDates
        {
            get
            {

                return _selectedDates;
            }
            set
            {
                _selectedDates = value;
                Dg_KalenderAnzeige = serv.NextTermin(value);
                RaisePropertyChanged("SelectedDates");
            }
        }
        private List<KalenderTermineModel> _dg_TermineKalender;
        public List<KalenderTermineModel> Dg_TermineKalender
        {
            get
            {
                return _dg_TermineKalender;
            }
            set
            {
                _dg_TermineKalender = value;
                RaisePropertyChanged("Dg_TermineKalender");
            }
        }
        private List<KalenderNextTerminModel> _dg_KalenderAnzeige;
        public List<KalenderNextTerminModel> Dg_KalenderAnzeige
        {
            get
            {
                return _dg_KalenderAnzeige;
            }
            set
            {
                _dg_KalenderAnzeige = value;
                RaisePropertyChanged("Dg_KalenderAnzeige");
            }


        }
    }
}
