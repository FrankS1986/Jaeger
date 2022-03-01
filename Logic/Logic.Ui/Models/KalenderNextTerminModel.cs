using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Models
{
    public class KalenderNextTerminModel
    {
        public string Bezeichnung { get; set; }

        public System.DateTime DatumUhrzeit { get; set; }

        public string Typ { get; set; }

        public string Ort { get; set; }
    }
}
