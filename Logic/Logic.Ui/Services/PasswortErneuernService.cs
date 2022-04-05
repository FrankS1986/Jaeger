using System;
using System.Linq;


namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
   
    public class PasswortErneuernService
    {

        public bool passwortVergeben;
        /// <summary>
        /// prüft ob das passwort schon mal vergeben wurden wenn nein dann wird das alte passwort ersetzt und in der Tabelle Passwörter gespeichert.
        /// </summary>
        /// <param name="benutzer"></param>
        /// <param name="passwort"></param>
        /// <returns></returns>
        public bool PasswoerterUeberprüfen(string benutzer, string passwort)
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

                    foreach (var item in listebenutzer)
                    {
                        item.Passwort = passwort;
                        item.DatumUhrzeit = DateTime.Now;


                    }

                    ctx.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


        int altespasswort;
        /// <summary>
        ///  Löscht das Passwort was anlängsten drin ist wenn es über 5 Passwörter gibt
        /// </summary>
        /// <param name="benutzer"></param>
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
