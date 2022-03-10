using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Messages
{
    //Klasse für die Message die einen erfolgreichen/nicht erfolgreichen neuen eingetragenen
    //Abschuss meldet
   public class AbschusslisteAktualisierenSelectedMessage
    {
        public bool? Abfrage { get; set; }
    }
}
