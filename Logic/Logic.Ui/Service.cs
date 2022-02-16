using System.Collections.Generic;
using System.Linq;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Service
    {
        public List<tbl_Login> GetLoginData()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var loginData = from a in ctx.tbl_Login
                                select new { a.Loginname, a.Passwort };
                var LoginData = new List<tbl_Login>();
                foreach (var item in loginData)
                {
                    LoginData.Add(new tbl_Login()
                    {

                        Loginname = item.Loginname,
                        Passwort = item.Passwort
                    });
                }
                return LoginData;
            }

        }
        public 
    }
}
