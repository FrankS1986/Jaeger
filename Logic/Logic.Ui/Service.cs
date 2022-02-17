using System.Collections.Generic;
using System.Linq;


namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Service
    {
        public bool loginSuccessful;
        public bool LoginSuccessful(string benutzer, string passwort)
        {

            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
               var loginData = from a in ctx.tbl_Login
                                where a.Loginname == benutzer && a.Passwort == passwort
                                select new { a.Loginname, a.Passwort };

                if (loginData.Count() == 1)
                {
                    loginSuccessful = true;
                }
                else
                {
                    loginSuccessful = false;
                }
                return loginSuccessful;
            }

        }



    }
}
