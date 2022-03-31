using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;

namespace JaegerMeister.MvvmSample.Ui.Desktop.Controls
{
    /// <summary>
    /// Interaktionslogik für Jaeger_Hinzufuegen.xaml
    /// </summary>
    public partial class JaegerHinzufuegen : UserControl
    {
        public JaegerHinzufuegen()
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
                    MessageBox.Show("Irgendetwas ist schief gelaufen, sorry.");
                }
            });
        }


        private void btn_abbruch_Click(object sender, RoutedEventArgs e)
        {

            JaegerInformationenControl jaegerInfos = new JaegerInformationenControl();

            Content = jaegerInfos;
        }

  
    }
}
