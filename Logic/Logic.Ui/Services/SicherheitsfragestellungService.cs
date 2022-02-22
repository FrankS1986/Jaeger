using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    public class SicherheitsfragestellungService
    {
        /// <summary>
        ///    Die Methode prüft ob der benutzer vohanden ist.
        ///    wenn ja gibt er die dazu gehörige frage aus
        ///   
        /// </summary>


        public string fragestellung;            
        public bool Benutzerabfrage(string benutzer)
        {
            
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {

                var nameIndex = from abfrage in ctx.tbl_Abfrage
                                where
                                  abfrage.tbl_Login.Loginname == benutzer
                                select new
                                {
                                    abfrage.Abfrage_ID,
                                    abfrage.tbl_Sicherheitsfragen.Frage,
                                    abfrage.tbl_Login.Loginname,
                                    abfrage.tbl_Login.Antwort
                                };

                fragestellung = "";
                
                if (nameIndex.Count()==1)
                {
                    var ergebnis = nameIndex.FirstOrDefault();
                    
                        fragestellung = ergebnis.Frage;
                        
                    
                    return true;
                }

                else
                {
                    return false;
                }
               

            }

        }

           /// <summary>
           ///   hier wird geprüft ob die Benutzereingaben mit den gespeichterten werten auf der Datenbank überein stimmt. 
           /// </summary>
          
        public bool AbfrageAnwort(string benutzername, string antwort)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var liste = from a in ctx.tbl_Login
                            where a.Loginname == benutzername && a.Antwort == antwort
                            select new{ a.Antwort};
                if(liste.Count()==1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


                
        }






    }
}
