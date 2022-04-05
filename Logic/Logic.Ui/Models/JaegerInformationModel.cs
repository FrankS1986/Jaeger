using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Models
{
    //Klasse die genutzt wird um das Datagrid im Jaegerinformationsfenster mit allen Jaegern zu füllen
    public class JaegerInformationModel
    {
        public int Jäger_ID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }       
    }
}
