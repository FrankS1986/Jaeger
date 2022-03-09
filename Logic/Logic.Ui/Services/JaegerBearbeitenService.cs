using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JaegerMeister.MvvmSample.Logic.Ui.Models.JaegerVerwaltungsModels;

namespace JaegerMeister.MvvmSample.Logic.Ui.Services
{
    class JaegerBearbeitenService
    {
        private List<GetJaegerInfoModel> _getJaegerInfo = new List<GetJaegerInfoModel>();
        public List<GetJaegerInfoModel> GetJaegerInfoList()
        {
            _getJaegerInfo.Clear();

            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var jaegerInfos = from abfrage in ctx.tbl_Jaeger
                                  select new
                                  {
                                      abfrage.Jäger_ID,
                                      abfrage.Vorname,
                                      abfrage.Nachname,
                                      abfrage.Straße,
                                      abfrage.Hausnummer,
                                      abfrage.Adresszusatz,
                                      abfrage.Postleitzahl,
                                      abfrage.Wohnort,
                                      abfrage.Telefonnummer1,
                                      abfrage.Telefonnummer2,
                                      abfrage.Telefonnummer3,
                                      abfrage.Email,
                                      abfrage.Geburtsdatum,
                                      abfrage.Funktion,
                                      abfrage.Jagdhund

                                  };
                foreach (var item in jaegerInfos)
                {
                    GetJaegerInfoModel JIM = new GetJaegerInfoModel(item.Jäger_ID, item.Vorname, item.Nachname, item.Straße, item.Hausnummer, item.Adresszusatz, item.Postleitzahl, item.Wohnort, item.Telefonnummer1, item.Telefonnummer2, item.Telefonnummer3, item.Email, item.Geburtsdatum, item.Funktion, item.Jagdhund);
                        _getJaegerInfo.Add(JIM);
                }

            }
            return _getJaegerInfo;
        }

    }
}
