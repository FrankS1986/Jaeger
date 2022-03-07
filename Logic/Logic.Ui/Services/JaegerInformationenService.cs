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

        public List<JaegerInformationModel> Jaeger()
        {
            List<JaegerInformationModel> jaeger;
            using (TreibjagdTestEntities ctx = new TreibjagdTestEntities())
            {
                var infoJaeger = from a in ctx.tbl_Jaeger
                                     //where a.Typ != "Wildunfall" && a.Bezeichnung != "Wildunfall"
                                 select new { a.Vorname, a.Nachname };
                jaeger = new List<JaegerInformationModel>();
                foreach (var tempInfo in infoJaeger)
                {
                    JaegerInformationModel info = new JaegerInformationModel();
                    info.Vorname = tempInfo.Vorname;
                    info.Nachname = tempInfo.Nachname;
                    jaeger.Add((JaegerInformationModel)info);
                }
            }
            return jaeger;
        }
    }
}
