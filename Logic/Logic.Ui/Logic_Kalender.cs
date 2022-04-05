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
        KalenderService serv = new KalenderService();
        /// <summary>
        /// Aufruf der Liste DateTime(LookUpConverter).
        /// </summary>
        public List<DateTime> Dates { get; } = new List<DateTime>();
        public Logic_Kalender()
        {
            TermineListe = serv.Termine();
            KalenderAnzeige = serv.NextTermin(DateTime.Now);
            foreach (KalenderTermineModel termin in TermineListe)
            {
                DateTime dateTime = new DateTime(termin.DatumUhrzeit.Year, termin.DatumUhrzeit.Month, termin.DatumUhrzeit.Day);
                Dates.Add(dateTime);
            }
        }
        #region Properties
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
                KalenderAnzeige = serv.NextTermin(value);
                RaisePropertyChanged("SelectedDates");
            }
        }
        private List<KalenderTermineModel> _termineListe;
        public List<KalenderTermineModel> TermineListe
        {
            get
            {
                return _termineListe;
            }
            set
            {
                _termineListe = value;
                RaisePropertyChanged("TermineListe");
            }
        }
        private List<KalenderNextTerminModel> _kalenderAnzeige;
        public List<KalenderNextTerminModel> KalenderAnzeige
        {
            get
            {
                return _kalenderAnzeige;
            }
            set
            {
                _kalenderAnzeige = value;
                RaisePropertyChanged("KalenderAnzeige");
            }
        }
        #endregion
    }
}

