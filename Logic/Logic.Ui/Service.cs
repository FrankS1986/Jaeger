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
                Logic_Login Logik = new Logic_Login();



                var loginData = from a in ctx.tbl_Login
                                where a.Loginname == benutzer && a.Passwort == passwort
                                select new { a.Loginname, a.Passwort };



                var LoginData = new List<tbl_Login>();
                foreach (var item in loginData)
                {
                    LoginData.Add(new tbl_Login()
                    {

                        Loginname = item.Loginname,
                        Passwort = item.Passwort
                    });

                    if (item.Loginname == null && item.Passwort == null )
                    {
                        loginSuccessful = false;
                    }
                    else
                    {
                        loginSuccessful = true;
                    }
                }
                return loginSuccessful;
            }

        }

        

    }
}
