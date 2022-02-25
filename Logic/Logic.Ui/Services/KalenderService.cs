using JaegerMeister.MvvmSample.Logic.Ui.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    public class KalenderService
    {
        public List<KalenderGeburtstagModel> geburtstag;
        public List<KalenderTermineModel> kalenderTermine;

        public List<tbl_Termine> terminlist;
        public List<DateTime> selectedDates;
        

        public List<KalenderTermineModel> Termine()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var bezTermin = from a in ctx.tbl_Termine
                                select new { a.Bezeichnung, a.DatumUhrzeit };

                //var ergebnis = dateTime.FirstOrDefault().DatumUhrzeit.ToString("yyyy, MMMM, dd")               
                //DateTime testDate = DateTime.Now;
                //string datum = testDate.ToString("yyyy, MMMM, dd");

                //terminlist = new List<tbl_Termine>();             
                kalenderTermine = new List<KalenderTermineModel>();
                foreach (var keksLord in bezTermin)
                {

                    //tbl_Termine termin = new tbl_Termine();
                    KalenderTermineModel termin = new KalenderTermineModel();
                    termin.Bezeichnung = keksLord.Bezeichnung;
                    termin.DatumUhrzeit = keksLord.DatumUhrzeit; 
                                      
                    //terminlist.Add((tbl_Termine)termin);
                    kalenderTermine.Add((KalenderTermineModel)termin);
                }
                //return terminlist;
                return kalenderTermine;
            }
        }

        public List<KalenderGeburtstagModel> Geburt()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var gebTermin = from a in ctx.tbl_Jaeger
                                select new { a.Vorname, a.Nachname, a.Geburtsdatum };

                geburtstag = new List<KalenderGeburtstagModel>();
                
                foreach(var keksLord in gebTermin)
                {
                    KalenderGeburtstagModel termin = new KalenderGeburtstagModel();
                    termin.Vorname = keksLord.Vorname;
                    termin.Nachname = keksLord.Nachname;
                    termin.Geburtsdatum = keksLord.Geburtsdatum;

                    geburtstag.Add((KalenderGeburtstagModel)termin);
                }
                return geburtstag;
               }
        }

        //public List<DateTime> DateKaleder()
        //{
        //    selectedDates = new List<DateTime>();
        //    selectedDates.Add(DateTime.Now.Date);
        //    selectedDates.Add(DateTime.Now.AddDays(1));
        //    selectedDates.Add(DateTime.Now.AddDays(2));

        //    return selectedDates;
        //}



    
                
       


    }
}
