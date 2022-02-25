using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
   public  class WildunfaelleService
    {

        public List<tbl_Tiere> Tiere()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {

                var liste = ctx.tbl_Tiere.ToList();

                return liste;
            }

        }


        public int datumID;
        public int tierartID;
        public DateTime time;
        public int jaegerID;
        public bool Tierhinzuegen(DateTime date, int id, string ort)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                time = date;
                try
                {
                    tbl_Termine itbl_Termine = new tbl_Termine
                    {
                        Ort = ort,
                        DatumUhrzeit = date,

                        Bezeichnung = "Wildunfall",
                        Typ = "Unfall"
                    };
                    ctx.tbl_Termine.Add(itbl_Termine);
                    ctx.SaveChanges();



                    var IndexName = from a in ctx.tbl_Jaeger
                                    where a.Vorname == "Wildunfall"
                                    select new { a.Jäger_ID };

                    if (IndexName.Count() == 1)
                    {
                        foreach (var j in IndexName)
                        {
                            jaegerID = j.Jäger_ID;
                        }

                    }

                    var IndexTier = from a in ctx.tbl_Tiere
                                    where a.Tiere_ID == id
                                    select new { a.Tiere_ID };

                    if (IndexTier.Count() == 1)
                    {
                        foreach (var j in IndexTier)
                        {
                            tierartID = j.Tiere_ID;
                        }

                    }



                    var IndexTermin = from tbl_Termine in ctx.tbl_Termine
                                      select new
                                      {
                                          Termine_ID = tbl_Termine.Termine_ID,
                                          Ort = tbl_Termine.Ort,
                                          DatumUhrzeit = tbl_Termine.DatumUhrzeit,
                                          Bezeichnung = tbl_Termine.Bezeichnung,
                                          Typ = tbl_Termine.Typ
                                      };

                    
                        int ergebnis = IndexTermin.Count();
                        datumID = ergebnis;
                    







                    //tbl_Jagderfolge itbl_Jagderfolge = new tbl_Jagderfolge
                    //{
                    //    Jäger_ID =
                    //        ((from tbl_Jaeger in ctx.tbl_Jaeger
                    //          where
                    //            tbl_Jaeger.Jäger_ID == 1
                    //          select new
                    //          {
                    //              tbl_Jaeger.Jäger_ID 
                    //          }).FirstOrDefault().Jäger_ID),
                    //    Termine_ID =
                    //        ((from tbl_Termine in ctx.tbl_Termine
                    //          where
                    //            tbl_Termine.Termine_ID ==
                    //              (from tbl_Termine0 in ctx.tbl_Termine
                    //               select new
                    //               {
                    //                   tbl_Termine0.Termine_ID
                    //               }).Max(p => p.Termine_ID)
                    //          select new
                    //          {
                    //              tbl_Termine.Termine_ID
                    //          }).FirstOrDefault().Termine_ID),
                    //    Tiere_ID =
                    //        ((from tbl_Tiere in ctx.tbl_Tiere
                    //          where
                    //            tbl_Tiere.Tierart == tierart
                    //          select new
                    //          {
                    //              tbl_Tiere.Tiere_ID
                    //          }).FirstOrDefault().Tiere_ID)
                    //};
                    //ctx.tbl_Jagderfolge.Add(itbl_Jagderfolge);
                    //ctx.SaveChanges();

                    return true;
                }

                catch (Exception ex)
                {

                    return false;
                    throw ex;
                }




            }


        }

        public bool InsertJagdErfolge(tbl_Jagderfolge jagd)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())


            {
                try
                {
                    ctx.tbl_Jagderfolge.Add(jagd);
                    ctx.SaveChanges();
                    return true;

                }

                catch (Exception ex)
                {

                    return false;
                    throw ex;
                }

            }



        }

    }
}
