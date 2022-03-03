using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Models
{
    public class GeburtstagModel
    {
        public Nullable<System.DateTime> Geburtsdatum { get; set; }

        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}
