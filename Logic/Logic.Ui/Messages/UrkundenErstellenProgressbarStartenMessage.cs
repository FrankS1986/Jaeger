using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Messages
{     /// <summary>
      /// Sendet eine Message das so das sich der Lade Bildschrim öffnet
      /// </summary>
    public class UrkundenErstellenProgressbarStartenMessage
    {
        public bool? Erfolg { get; set; }
    }
}
