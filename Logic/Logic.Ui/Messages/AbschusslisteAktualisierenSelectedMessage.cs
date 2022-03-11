using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Messages
{
    /// <summary>
    ///   Abfrage für ergfolgreichen Eintrag
    /// </summary>
    public class AbschusslisteAktualisierenSelectedMessage
    {
        public bool? Abfrage { get; set; }
    }
}
