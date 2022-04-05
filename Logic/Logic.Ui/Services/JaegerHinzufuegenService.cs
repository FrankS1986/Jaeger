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
               
        /* Methode um die Spalten ID, Vorname und Nachname aus der DB in eine Liste zu speichern
         * und zurück zu geben */
        #region ListeIDVorNachname
        private List<IDVorNachnameModel> _listeIDVorNachname = new List<IDVorNachnameModel>();
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

        /* Methode um einen neuen Jäger in der DB anzulegen
            übernimmt die Angaben aus den ausgeüllten Feldern und speichert sie entsprechend in der DB*/
        #region boolNeuerJaeger
       // private bool ErfolgInsertNeuerJaeger;
        public bool InsertNeuerJaeger(tbl_Jaeger neuerJaeger)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                //var neuerJaeger = from nj in ctx.tbl_Jaeger
                //                  select new { nj.Jäger_ID, nj.Anrede, nj.Vorname, nj.Nachname, nj.Straße, nj.Hausnummer, nj.Adresszusatz, nj.Postleitzahl, nj.Wohnort, nj.Funktion, nj.Telefonnummer1, nj.Telefonnummer2, nj.Telefonnummer3, nj.Email, nj.Jagdhund, nj.Geburtsdatum };
                {

                    try
                    {
                        ctx.tbl_Jaeger.Add(neuerJaeger);
                        ctx.SaveChanges();
                        
                       // ErfolgInsertNeuerJaeger = true;
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
