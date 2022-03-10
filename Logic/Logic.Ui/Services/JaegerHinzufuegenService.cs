using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JaegerMeister.MvvmSample.Logic.Ui.Models;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{

    public class JaegerHinzufuegenService
    {
        #region ListeIDVorNachname
        private List<IDVorNachnameModel> _listeIDVorNachname = new List<IDVorNachnameModel>();
        /// <summary>
        /// Methode fragt ID,Vorname und Nachname ab und speichert in eine Liste
        /// </summary>
        /// <returns></returns>
        public List<IDVorNachnameModel> ListeIDVorNachname()
        {
            _listeIDVorNachname.Clear();

            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
               //If Abfrage um zu vermeiden, dass die Liste mehrmals hintereinander angezeigt wird
               
                    /* Ruft alles aus der DB außer ID 10, welche für Wildunfalle steht*/
                    var nameIndex = from abfrage in ctx.tbl_Jaeger
                                    where abfrage.Jäger_ID != 10
                                    select new
                                    {
                                        abfrage.Jäger_ID,
                                        abfrage.Vorname,
                                        abfrage.Nachname

                                    };

                    foreach (var item in nameIndex)
                    {
                        IDVorNachnameModel VNM = new IDVorNachnameModel(item.Jäger_ID, item.Vorname, item.Nachname);
                        _listeIDVorNachname.Add(VNM);
                    }
               
            }
            return _listeIDVorNachname;
        }
        #endregion ListeIDVorNachname
                
        #region boolNeuerJaeger
        /// <summary>
        /// Methode um einen neuen Jäger in der DB anzulegen übernimmt die Angaben aus den ausgeüllten Feldern und speichert sie entsprechend in der DB
        /// </summary>
        /// <param name="neuerJaeger"></param>
        /// <returns></returns>
        public bool InsertNeuerJaeger(tbl_Jaeger neuerJaeger)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
               {

                    try
                    {
                        ctx.tbl_Jaeger.Add(neuerJaeger);
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
        #endregion boolNeuerJaeger

        public List<tbl_Anrede> Anrede()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var liste = ctx.tbl_Anrede.ToList();
                return liste;
            }
        }

        public List<tbl_Funktionen> Funktionen()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var liste = ctx.tbl_Funktionen.ToList();
                return liste;
            }
        }
    }
}
