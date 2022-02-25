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

        KalenderService serv = new KalenderService();
        
        public Logic_Kalender()
        {

            Dg_TermineKalender = serv.Termine();
            //Dg_KalenderAnzeige = serv.Geburt();

            SelectedDates = serv.DateKaleder();
            //Kalender.SelectedDate = DateTime.Now.AddDays(1);
            

        }
        private List<DateTime> _selectedDates;
        public List<DateTime> SelectedDates
        {
            get
            {

                return _selectedDates;
            }
            set
            {
                _selectedDates = value;
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
        private List<KalenderGeburtstagModel> _dg_KalenderAnzeige;
        public List<KalenderGeburtstagModel> Dg_KalenderAnzeige
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



        //private DateTime _selectedDate;
        //public DateTime SelectedDate
        //{
        //    get { return _selectedDate; }
        //    set
        //    {
        //        _selectedDate = value; RaisePropertyChanged("SelectedDates");
        //    }
        //}
        //private ObservableCollection<DateTime> _selectedDates = new ObservableCollection<DateTime>();
        //public ObservableCollection<DateTime> SelectedDates
        //{
        //    get { return _selectedDates; }
        //    set
        //    {
        //        _selectedDates = value; RaisePropertyChanged("SelectedDates");
        //    }
        //}

    }
}
