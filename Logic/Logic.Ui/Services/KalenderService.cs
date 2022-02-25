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



        public List<KalenderGeburtstagModel> geburtstag;
        public List<KalenderTermineModel> kalenderTermine;

        public List<tbl_Termine> terminlist;
        public List<DateTime> selectedDates;
        
        //Verbindung zur Datenbank
        public List<KalenderTermineModel> Termine()
        {
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

        //public List<KalenderGeburtstagModel> Geburt()
        //{
        //    using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
        //    {
        //        var gebTermin = from a in ctx.tbl_Jaeger
        //                        select new { a.Vorname, a.Nachname, a.Geburtsdatum };
        //        //int ergebnis = gebTermin.Count();




        //        geburtstag = new List<KalenderGeburtstagModel>();

        //        foreach (var keksLord in gebTermin)
        //        {
        //            KalenderGeburtstagModel termin = new KalenderGeburtstagModel();
        //            termin.Vorname = keksLord.Vorname;
        //            termin.Nachname = keksLord.Nachname;
        //            termin.Geburtsdatum = keksLord.Geburtsdatum;

        //            geburtstag.Add((KalenderGeburtstagModel)termin);
        //        }
        //        return geburtstag;
        //    }
        //}


        public List<DateTime> DateKaleder()
        {
            selectedDates = new List<DateTime>();
            selectedDates.Add(DateTime.Now.Date);
            selectedDates.Add(DateTime.Now.Date);
            selectedDates.Add(DateTime.Now.AddDays(2));

            return selectedDates;
        }








    }
}
