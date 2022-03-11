using JaegerMeister.MvvmSample.Logic.Ui.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    public class KalenderService
    {
        /// <summary>
        /// Verbindungsaufbau zur Datenbank. Erstellung der Liste für alle Termine.
        /// </summary>
        /// <returns></returns>
        public List<KalenderTermineModel> Termine()
        {
            List<KalenderTermineModel> kalenderTermine;
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var bezTermin = from a in ctx.tbl_Termine
                                where a.Typ != "Wildunfall" && a.Bezeichnung != "Wildunfall"
                                select new { a.Bezeichnung, a.DatumUhrzeit };
                //Debugging des Datums
                //var ergebnis = dateTime.FirstOrDefault().DatumUhrzeit.ToString("yyyy, MMMM, dd")               
                //DateTime testDate = DateTime.Now;
                //string datum = testDate.ToString("yyyy, MMMM, dd");
                kalenderTermine = new List<KalenderTermineModel>();
                foreach (var tempTermin in bezTermin)
                {
                    KalenderTermineModel termin = new KalenderTermineModel();
                    termin.Bezeichnung = tempTermin.Bezeichnung;
                    termin.DatumUhrzeit = tempTermin.DatumUhrzeit;
                    kalenderTermine.Add((KalenderTermineModel)termin);
                }
            }
            return kalenderTermine;
        }
        /// <summary>
        /// Verbindungsaufbau zur Datenbank. Erstellung der Liste für die Aktuellen Termine.
        /// Neues DateTime(dateTime) erstellt
        /// Termine werden nach dateTime sortiert.
        /// </summary>
        /// <param name="selectedDate"></param>
        /// <returns></returns>
        public List<KalenderNextTerminModel> NextTermin(DateTime selectedDate)
        {
            List<KalenderNextTerminModel> nextTermin = new List<KalenderNextTerminModel>();
            //DateTime dateTime = new DateTime(selectedDate.Year, selectedDate.Month, DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month), 23, 59, 59);
            DateTime dateTime = selectedDate.AddHours(23).AddMinutes(59).AddSeconds(59);
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {

                var nTermin = from a in ctx.tbl_Termine
                              where a.Bezeichnung != "Wildunfall" && a.Typ != "Unfall" && a.DatumUhrzeit >= selectedDate && a.DatumUhrzeit <= dateTime
                              orderby a.DatumUhrzeit ascending
                              select new { a.Bezeichnung, a.Typ, a.DatumUhrzeit, a.Ort };
                foreach (var tempTermin in nTermin)
                {
                    KalenderNextTerminModel termin = new KalenderNextTerminModel();
                    termin.Bezeichnung = tempTermin.Bezeichnung;
                    termin.DatumUhrzeit = tempTermin.DatumUhrzeit;
                    termin.Ort = tempTermin.Ort;
                    termin.Typ = tempTermin.Typ;
                    nextTermin.Add((KalenderNextTerminModel)termin);
                }
            }
            return nextTermin;
        }
    }
}
