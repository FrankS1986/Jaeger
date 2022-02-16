using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    public class Service
    {
        public List<tbl_Login> GetAllLogin()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var loginData = from a in ctx.tbl_Login
                                select new { a.Login_ID, a.Loginname, a.Passwort };
                var LoginData = new List<tbl_Login>();
                foreach (var item in loginData)
                {
                    LoginData.Add(new tbl_Login()
                    {
                        Login_ID = item.Login_ID,
                        Loginname = item.Loginname,
                        Passwort = item.Passwort
                    });
                }
                return LoginData;
            }
           
        }
    }
}
