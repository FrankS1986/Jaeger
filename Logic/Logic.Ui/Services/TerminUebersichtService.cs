using JaegerMeister.MvvmSample.Logic.Ui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{

    public class TerminUebersichtService
    {
        //<summary>
        //Holt die entsprechenden Daten aus der Tabelle tbl_Termine und packt diese in eine Liste.
        //</summary>
        public List<tbl_Termine> terminUebersicht()
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var termine = from a in ctx.tbl_Termine
                              select new { a.Termine_ID, a.Bezeichnung, a.Ort, a.DatumUhrzeit };
                var liste = new List<tbl_Termine>();

                foreach (var item in termine)
                {
                    liste.Add(new tbl_Termine()
                    {
                        Termine_ID = item.Termine_ID,
                        Bezeichnung = item.Bezeichnung,
                        Ort = item.Ort,
                        DatumUhrzeit = item.DatumUhrzeit
                    });
                }
                return liste;
            }
        }

        //<summary>
        //Sucht den Datensatz durch den mitgegebenen Integer in der Datenbank um diesen dann zu löschen.
        //</summary>
        public IQueryable terminLoeschen(int id)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var termine = from a in ctx.tbl_Termine
                              where a.Termine_ID == id
                              select a;
                foreach (tbl_Termine del in termine)
                {
                    ctx.tbl_Termine.Remove(del);
                }
                ctx.SaveChanges();

                return termine;
            }
        }

        //<summary>
        //Sucht die eingeladenen Personen, die zu dem asugewählten Termin zugeordnet sind.
        //</summary>
        public List<tbl_Jaeger> Personen(int id)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var Personen = from a in ctx.tbl_Rueckmeldung
                               select new { a.Termine_ID, a.tbl_Jaeger.Vorname, a.tbl_Jaeger.Nachname };
                var Liste = new List<tbl_Jaeger>();

                foreach (var item in Personen)
                {
                    if (item.Termine_ID == id)
                    {
                        Liste.Add(new tbl_Jaeger()
                        {
                            Vorname = item.Vorname,
                            Nachname = item.Nachname
                        });
                    }
                }
                return Liste;
            }
        }
    }
}
