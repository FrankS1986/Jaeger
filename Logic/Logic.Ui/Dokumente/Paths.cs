using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerMeister.MvvmSample.Logic.Ui.Dokumente
{
   public class Paths
    {
        public static string GetFilePath(string file)
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            return appPath + "..\\..\\..\\..\\" + file;
        }


    }
}
