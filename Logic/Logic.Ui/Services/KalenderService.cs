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




        

        public List<KalenderTermineModel> Termine()
        {
            List<KalenderTermineModel> kalenderTermine;
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var bezTermin = from a in ctx.tbl_Termine
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
                return kalenderTermine;
            }
        }
        public List<KalenderNextTerminModel> NextTermin(DateTime selectedDate)

        {
            List<KalenderNextTerminModel> nextTermin = new List<KalenderNextTerminModel>();
            //DateTime dateTime = new DateTime(selectedDate.Year, selectedDate.Month, DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month), 23, 59, 59);
            DateTime dateTime = selectedDate.AddHours(23).AddMinutes(59).AddSeconds(59);
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {

                var nTermin = from a in ctx.tbl_Termine
                              where a.DatumUhrzeit >= selectedDate && a.DatumUhrzeit <= dateTime
                              orderby a.DatumUhrzeit ascending
                              select new { a.Bezeichnung, a.Typ, a.DatumUhrzeit };




                foreach (var kekslLord in nTermin)
                {
                    KalenderNextTerminModel tempTermin = new KalenderNextTerminModel();
                    tempTermin.Bezeichnung = kekslLord.Bezeichnung;
                    tempTermin.DatumUhrzeit = kekslLord.DatumUhrzeit;
                    tempTermin.Typ = kekslLord.Typ;



                    nextTermin.Add((KalenderNextTerminModel)tempTermin);
                }

            }
            return nextTermin;
        }
    }
}
