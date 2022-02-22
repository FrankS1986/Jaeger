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
        ///    Die Methode prüft ob der benutzer vohanden ist. Wenn ja wird seine ID gespeichert in benutzerID
        ///    in der tabelle tblAbfrage wird dann die benutzerID verglichen mit der LoginID so das der User klar zu geordnet werden kann.
        ///    die abfrageID wird dann mit der sicherheitsfragenID verglichen um so die Frage zu ermitteln welche der User beim Registrieren ausgewält hat.
        ///    
        /// </summary>
        public string fragestellung;
        private int benutzerID;
        private int abfrageID;
                        
        public bool Benutzerabfrage(string benutzer)
        {
            
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
               

                     
                    var nameIndex = from a in ctx.tbl_Login
                                    where a.Loginname == benutzer
                                    select new { a.Login_ID };

                if (nameIndex.Count() == 1)
                {
                    var listeLogin = new List<tbl_Login>();

                    foreach (var item in nameIndex)
                    {
                        benutzerID = item.Login_ID;
                    }

                    var abfrageIndex = from a in ctx.tbl_Abfrage
                                       where a.Login_ID == benutzerID
                                       select new { a.Sicherheitsfragen_ID };
                    var listeAbfrage = new List<tbl_Abfrage>();

                    foreach (var item in abfrageIndex)
                    {
                        abfrageID = item.Sicherheitsfragen_ID;
                    }

                    var sicherheitsfrage = from a in ctx.tbl_Sicherheitsfragen
                                           where a.Sicherheitsfragen_ID == abfrageID
                                           select new { a.Frage };
                    foreach (var item in sicherheitsfrage)
                    {
                        fragestellung = item.Frage;
                    }
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
