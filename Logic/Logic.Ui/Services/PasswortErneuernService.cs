using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    public class PasswortErneuernService
    {

        public bool passwortVergeben;
        public bool PasswortErneuern(string benutzer, string passwort)
        {

            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var listebenutzer = from a in ctx.tbl_Login
                                    where a.Loginname == benutzer
                                    select a;
                var listepasswort = from a in ctx.tbl_Passwoerter
                                    where a.Loginname == benutzer
                                    select new { a.Passwort };

                foreach (var item in listepasswort)
                {
                    if (passwort == item.Passwort)
                    {
                        passwortVergeben = false;
                        break;
                    }
                    else
                    {
                        passwortVergeben = true;
                    }
                }




                if (listebenutzer.Count() == 1 && passwortVergeben)
                {

                       foreach(var item in listebenutzer)
                    {
                        item.Passwort = passwort;
                        item.DatumUhrzeit = DateTime.Now;
                          

                    }



                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


        int altespasswort;
        public void PasswortLoeschen(string benutzer)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {

                var listepasswort = from a in ctx.tbl_Passwoerter
                                    where a.Loginname == benutzer
                                    select new { a.Passwort_ID };


                if (listepasswort.Count() > 5)
                {
                    var passwort = listepasswort.FirstOrDefault();
                    altespasswort = passwort.Passwort_ID;

                    var liste = from a in ctx.tbl_Passwoerter
                                where a.Passwort_ID == altespasswort
                                select a;
                    foreach (var del in liste)
                    {
                        ctx.tbl_Passwoerter.Remove(del);
                    }
                    ctx.SaveChanges();
                }




            }
        }

    }
}
