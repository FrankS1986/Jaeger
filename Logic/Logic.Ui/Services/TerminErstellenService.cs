using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    class TerminErstellenService
    {
        //<summary>
        //Wenn ein Termin bearbeitet wird, wird dieser in der Datebank überschrieben. Ansonsten wird ein neuer Termin angelegt. 
        //</summary>
        public bool Termin(int id, string bezeichnung, string ort, string zeit, string typ, DateTime datum)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                if (id == 0)
                {
                    var liste = from a in ctx.tbl_Termine
                                select a;
                    try
                    {
                        string[] einheit = zeit.Split(':');
                        if (Convert.ToDouble(einheit[0]) >= 24)
                        {
                            MessageBox.Show("Die Zeitangabe ist ungültig!");
                            return false;
                        }
                        else if (Convert.ToDouble(einheit[1]) >= 60)
                        {
                            MessageBox.Show("Die Zeitangabe ist ungültig!");
                            return false;
                        }
                        else if (datum < DateTime.Today)
                        {
                            MessageBox.Show("Sie haben einen Tag ausgewählt, der in der Vergangenheit liegt!");
                            return false;
                        }
                        else
                        {
                            datum = datum.AddHours(Convert.ToDouble(einheit[0]));
                            datum = datum.AddMinutes(Convert.ToDouble(einheit[1]));
                            tbl_Termine termin = new tbl_Termine
                            {
                                Ort = ort,
                                DatumUhrzeit = datum,
                                Bezeichnung = bezeichnung,
                                Typ = typ
                            };
                            ctx.tbl_Termine.Add(termin);
                            ctx.SaveChanges();
                            return true;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bitte verwenden Sie dieses Format als Zeitangabe: 15:30!");
                        return false;
                    }
                }
                else
                {
                    var liste = from a in ctx.tbl_Termine
                                where a.Termine_ID == id
                                select a;
                    try
                    {
                        string[] einheit = zeit.Split(':');
                        if (Convert.ToDouble(einheit[0]) >= 24)
                        {
                            MessageBox.Show("Die Zeitangabe ist ungültig!");
                            return false;
                        }
                        else if (Convert.ToDouble(einheit[1]) >= 60)
                        {
                            MessageBox.Show("Die Zeitangabe ist ungültig!");
                            return false;
                        }
                        else if (datum < DateTime.Today)
                        {
                            MessageBox.Show("Sie haben einen Tag ausgewählt, der in der Vergangenheit liegt!");
                            return false;
                        }
                        else
                        {
                            datum = datum.AddHours(Convert.ToDouble(einheit[0]));
                            datum = datum.AddMinutes(Convert.ToDouble(einheit[1]));
                            foreach (var item in liste)
                            {
                                item.Bezeichnung = bezeichnung;
                                item.Ort = ort;
                                item.Typ = typ;
                                item.DatumUhrzeit = datum;
                            }
                            ctx.SaveChanges();
                            return true;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bitte verwenden Sie dieses Format als Zeitangabe: 15:30!");
                        return false;
                    }
                }
            }
        }
    }
}
