using System.Windows;
using System.Windows.Controls;

namespace JaegerMeister.MvvmSample.Ui.Desktop.Controls
{
    /// <summary>
    /// Interaktionslogik für Jaeger_Informationen.xaml
    /// </summary>
    public partial class JaegerInformationenControl : UserControl
    {
        public JaegerInformationenControl()
        {
            InitializeComponent();
        }

        private void Jaeger_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JaegerHinzufuegen jaegerHinzufuegen = new JaegerHinzufuegen();

            Content = jaegerHinzufuegen;
        }
    }
}
