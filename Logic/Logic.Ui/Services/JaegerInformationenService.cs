using JaegerMeister.MvvmSample.Logic.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    public class JaegerInformationenService
    {
        //Datenbank Verbindung InformationModel Liste
        public List<JaegerInformationModel> Jaeger()
        {
            List<JaegerInformationModel> _jaeger;
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var infoJaeger = from a in ctx.tbl_Jaeger
                                 where a.Nachname != "Wildunfall"
                                 select new { a.Vorname, a.Nachname, a.Jäger_ID };

                _jaeger = new List<JaegerInformationModel>();
                foreach (var tempInfo in infoJaeger)
                {
                    JaegerInformationModel info = new JaegerInformationModel();
                    info.Vorname = tempInfo.Vorname;
                    info.Nachname = tempInfo.Nachname;
                    info.Jäger_ID = tempInfo.Jäger_ID;
                    _jaeger.Add((JaegerInformationModel)info);
                }
            }
            return _jaeger;
        }
        //Datenbank Verbindung ID wird gesucht!
        public JaegerInformationSelectedModel Selected(int ID)
        {
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var infoJaeger = from a in ctx.tbl_Jaeger
                                 where a.Jäger_ID == ID
                                 select a;

                tbl_Jaeger tempjaeger = infoJaeger.FirstOrDefault();

                JaegerInformationSelectedModel info = new JaegerInformationSelectedModel();
                info.Vorname = tempjaeger.Vorname;
                info.Nachname = tempjaeger.Nachname;
                info.Anrede = tempjaeger.Anrede;
                info.Geburtsdatum = tempjaeger.Geburtsdatum;
                info.Straße = tempjaeger.Straße;
                info.Hausnummer = tempjaeger.Hausnummer;
                info.Adresszusatz = tempjaeger.Adresszusatz;
                info.Postleitzahl = tempjaeger.Postleitzahl;
                info.Wohnort = tempjaeger.Wohnort;
                info.Telefonnummer1 = tempjaeger.Telefonnummer1;
                info.Telefonnummer2 = tempjaeger.Telefonnummer2;
                info.Telefonnummer3 = tempjaeger.Telefonnummer3;
                info.Email = tempjaeger.Email;
                info.Funktion = tempjaeger.Funktion;
                info.Jagdhund = tempjaeger.Jagdhund;

                return info;
            }
        }
    }
}
