using System;
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

        /// <summary>
        /// Checkt die Login_ID vom Benutzer, um Admin festzustellen.
        /// </summary>
        public bool adminSuccessful;

        public bool AdminSuccessful(string benutzer)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var admin = from a in ctx.tbl_Login
                            where a.Loginname == benutzer && a.Login_ID == 1
                            select new {a.Loginname, a.Login_ID };
                if (admin.Count() == 1)
                {
                    adminSuccessful = true;
                }
                else
                {
                    adminSuccessful = false;
                }
            }
            return adminSuccessful;
        }

        /// <summary>
        /// Beginn Registrierung
        /// </summary>
        /// <returns></returns>
        public List<tbl_Sicherheitsfragen> Sichheitsfragen()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {

                var liste = ctx.tbl_Sicherheitsfragen.ToList();

                return liste;
            }

        }

        public bool BenutzerVorhanden;
        public bool Insert(tbl_Login login, string benutzer)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var CheckBenutzer = from a in ctx.tbl_Login
                                    where a.Loginname == benutzer
                                    select new { a.Loginname, a.Passwort };

                try
                {
                    if (CheckBenutzer.Count() == 0)
                    {
                        ctx.tbl_Login.Add(login);
                        ctx.SaveChanges();
                        BenutzerVorhanden = true;
                        return true;
                    }

                    else
                    {
                        BenutzerVorhanden = false;
                        return false;
                    }
                }

                catch (Exception ex)
                {
                    return false;
                    throw ex;
                }

            }
        }

        public List<tbl_Login> loginListe;
        public List<tbl_Sicherheitsfragen> fragenListe;
        public int LoginId;
        public int SicherheitsfragenId;
        public bool InsertAbfrage(int id, string name, tbl_Sicherheitsfragen securityQuestion)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {


                try
                {
                    // Find Login with given Loginname
                    var loginQuery = from a in ctx.tbl_Login
                                    where a.Loginname == name
                                    select a.Login_ID;

                    LoginId = loginQuery.FirstOrDefault();

                    
                    var securityQuestionQuery = from a in ctx.tbl_Sicherheitsfragen
                                where a.Sicherheitsfragen_ID == id
                                select a;
                    fragenListe = new List<tbl_Sicherheitsfragen>();

                        
                    

                    foreach (var item in securityQuestionQuery)
                    {
                        item.Frage = securityQuestion.Frage;
                        SicherheitsfragenId = item.Sicherheitsfragen_ID;
                    }


                    loginListe = new List<tbl_Login>();

                    return true;
                }


                catch (Exception ex)
                {
                    return false;
                    throw ex;
                }
            }

        }


        public bool InsertAB(tbl_Abfrage abfrage)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                try
                {
                    ctx.tbl_Abfrage.Add(abfrage);
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

        /// <summary>
        /// Ende Registrierung
        /// </summary>

    }
}