using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für Jaeger_Hinzufuegen.xaml
    /// </summary>
    public partial class GUI_JaegerHinzufuegen : UserControl
    {
        public GUI_JaegerHinzufuegen()
        {
            InitializeComponent();
            Messenger.Default.Register<JaegerHinzufuegenErfolgsMessage>(this, (JaegerHinzufuegenErfolgsMessage loginProof) =>
            {
                if (loginProof.Success == true)
                {
                    MessageBox.Show("Jäger erfolgreich hinzugefügt");
                  
                }
                else
                {
                    MessageBox.Show("NOPE");
                }
            });
        }


        private void btn_abbruch_Click(object sender, RoutedEventArgs e)
        {

            GUI_JaegerInformationen jaegerInfos = new GUI_JaegerInformationen();

            Content = jaegerInfos;
        }

  
    }
}
