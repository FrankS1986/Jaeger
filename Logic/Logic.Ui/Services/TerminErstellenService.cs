using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    public class TerminErstellenService
    {
        /// <summary>
        /// Wenn ein Termin bearbeitet wird, wird dieser in der Datebank überschrieben. Ansonsten wird ein neuer Termin angelegt.
        /// </summary>
        /// <param name="terminID"></param>
        /// <param name="bezeichnung"></param>
        /// <param name="ort"></param>
        /// <param name="zeit"></param>
        /// <param name="typ"></param>
        /// <param name="datum"></param>
        /// <returns></returns>
        public bool TerminErstellen(int terminID, string bezeichnung, string ort, string zeit, string typ, DateTime datum)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var checkSpecialChar = new Regex("^[a-zA-Z0-9 äÄöÖüÜßáàâéèê]*$");
                if (terminID == 0)
                {
                    try
                    {
                        string[] zeitEinheit = zeit.Split(':');
                        if (Convert.ToDouble(zeitEinheit[0]) >= 24)
                        {
                            MessageBox.Show("Ihre Zeitangabe ist ungültig!");
                            return false;
                        }
                        else if (Convert.ToDouble(zeitEinheit[1]) >= 60)
                        {
                            MessageBox.Show("Ihre Zeitangabe ist ungültig!");
                            return false;
                        }
                        else if (datum < DateTime.Today)
                        {
                            MessageBox.Show("Sie haben einen Tag ausgewählt, der in der Vergangenheit liegt!");
                            return false;
                        }
                        else if (checkSpecialChar.IsMatch(bezeichnung) == false)
                        {
                            MessageBox.Show("Bitte nutzen Sie keine Sonderzeichen in der Beschreibung!");
                            return false;
                        }
                        else
                        {
                            datum = datum.AddHours(Convert.ToDouble(zeitEinheit[0]));
                            datum = datum.AddMinutes(Convert.ToDouble(zeitEinheit[1]));
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
                                where a.Termine_ID == terminID
                                select a;
                    try
                    {
                        string[] zeitEinheit = zeit.Split(':');
                        if (Convert.ToDouble(zeitEinheit[0]) >= 24)
                        {
                            MessageBox.Show("Ihre Zeitangabe ist ungültig!");
                            return false;
                        }
                        else if (Convert.ToDouble(zeitEinheit[1]) >= 60)
                        {
                            MessageBox.Show("Ihre Zeitangabe ist ungültig!");
                            return false;
                        }
                        else if (datum < DateTime.Today)
                        {
                            MessageBox.Show("Sie haben einen Tag ausgewählt, der in der Vergangenheit liegt!");
                            return false;
                        }
                        else if (checkSpecialChar.IsMatch(bezeichnung) == false)
                        {
                            MessageBox.Show("Bitte nutzen Sie keine Sonderzeichen in der Beschreibung!");
                            return false;
                        }
                        else
                        {
                            datum = datum.AddHours(Convert.ToDouble(zeitEinheit[0]));
                            datum = datum.AddMinutes(Convert.ToDouble(zeitEinheit[1]));
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
