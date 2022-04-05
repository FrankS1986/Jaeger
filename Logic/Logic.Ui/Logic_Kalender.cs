using GalaSoft.MvvmLight;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using JaegerMeister.MvvmSample.Logic.Ui.Models;


namespace JaegerMeister.MvvmSample.Logic.Ui
{
    /// <summary>
    /// Interaktionslogik für Kalender.xaml
    /// </summary>
    public class Logic_Kalender : ViewModelBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Aufruf der Klasse Kalenderservice.
        /// </summary>
        KalenderService kalenderService = new KalenderService();
        /// <summary>
        /// Aufruf der Liste DateTime(LookUpConverter).
        /// </summary>
        public List<DateTime> Dates { get; } = new List<DateTime>();
        public Logic_Kalender()
        {
            TermineListe = kalenderService.Termine();
            KalenderAnzeige = kalenderService.NextTermin(DateTime.Now);
            foreach (KalenderTermineModel termin in TermineListe)
            {
                DateTime dateTime = new DateTime(termin.DatumUhrzeit.Year, termin.DatumUhrzeit.Month, termin.DatumUhrzeit.Day);
                Dates.Add(dateTime);
            }
        }
        #region Properties
        private DateTime _SelectedDates;
        public DateTime SelectedDates
        {
            get
            {
                return _SelectedDates;
            }
            set
            {
                _SelectedDates = value;
                KalenderAnzeige = kalenderService.NextTermin(value);
                RaisePropertyChanged("SelectedDates");
            }
        }
        private List<KalenderTermineModel> _TermineListe;
        public List<KalenderTermineModel> TermineListe
        {
            get
            {
                return _TermineListe;
            }
            set
            {
                _TermineListe = value;
                RaisePropertyChanged("TermineListe");
            }
        }
        private List<KalenderNextTerminModel> _KalenderAnzeige;
        public List<KalenderNextTerminModel> KalenderAnzeige
        {
            get
            {
                return _KalenderAnzeige;
            }
            set
            {
                _KalenderAnzeige = value;
                RaisePropertyChanged("KalenderAnzeige");
            }
        }
        #endregion
    }
}

