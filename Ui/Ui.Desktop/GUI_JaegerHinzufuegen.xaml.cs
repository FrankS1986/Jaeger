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

            //registriert ob das hinzufügen erfolgreich war. Informiert User per MessageBox über den Erfolg und leitet weiter zur Jäger Info GUI, bei misserfolg wird lediglich MessageBox gezeigt
            Messenger.Default.Register<JaegerHinzufuegenErfolgsMessage>(this, (JaegerHinzufuegenErfolgsMessage loginProof) =>
            {
                if (loginProof.Success == true)
                {
                    MessageBox.Show("Jäger erfolgreich hinzugefügt");

                    GUI_JaegerInformationen jaegerInfos = new GUI_JaegerInformationen();

                    Content = jaegerInfos;
                }
                else
                {
                    MessageBox.Show("Alle Pflichtfelder müssen korrekt ausgefüllt sein.");
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
