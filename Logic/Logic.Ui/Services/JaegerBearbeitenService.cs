﻿using GalaSoft.MvvmLight.Messaging;
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
        private List<tbl_Jaeger> _getJaegerInfo = new List<tbl_Jaeger>();
        public List<tbl_Jaeger> GetJaegerInfoList()
        {
            _getJaegerInfo.Clear();

            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var jaegerInfos = from abfrage in ctx.tbl_Jaeger
                                  where abfrage.Jäger_ID != 10
                                  orderby abfrage.Vorname
                                  select new
                                  {
                                      abfrage.Jäger_ID,
                                      abfrage.Vorname,
                                      abfrage.Nachname,
                                      abfrage.Anrede,
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
                List<tbl_Jaeger> liste = new List<tbl_Jaeger>();
                foreach (var item in jaegerInfos)
                {
                    liste.Add(new tbl_Jaeger()
                    {
                        Jäger_ID = item.Jäger_ID,
                        Vorname = item.Vorname,
                        Nachname = item.Nachname,
                        Anrede = item.Anrede,
                        Straße = item.Straße,
                        Hausnummer = item.Hausnummer,
                        Adresszusatz = item.Adresszusatz,
                        Postleitzahl = item.Postleitzahl,
                        Wohnort = item.Wohnort,
                        Funktion = item.Funktion,
                        Telefonnummer1 = item.Telefonnummer1,
                        Telefonnummer2= item.Telefonnummer2,
                        Telefonnummer3= item.Telefonnummer3,
                        Email = item.Email,
                        Jagdhund = item.Jagdhund,
                        Geburtsdatum = item.Geburtsdatum
                    });
                }
                return liste;

            }

        }

    }
}