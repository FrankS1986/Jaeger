using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Messages
{
    /// <summary>
    /// Wird verwendet wenn ein Termin ausgewählt wird das die Liste sichen zurücksetzen
    /// </summary>
  public  class UrkundenErstellenErfolgsMessage
    {
        public bool? Erfolg { get; set; }
    }
}
