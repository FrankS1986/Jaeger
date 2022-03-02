using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Models
{
    public class TerminUebersichtModel
    {
        public string Bezeichnung { get; set; }
        public DateTime DatumUhrzeit { get; set; }
    }

    public class PersonenUebersichtModel
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}
