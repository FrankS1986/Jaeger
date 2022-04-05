using System.Windows;
using System.Windows.Controls;


namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    public partial class GUI_JaegerInformationen : UserControl
    {
        public GUI_JaegerInformationen()
        {
            InitializeComponent();
        }
        private void HinzufuegenButton(object sender, RoutedEventArgs e)
        {
            GUI_JaegerHinzufuegen jaegerHinzufuegen = new GUI_JaegerHinzufuegen();
            ContentControl_JaegerInformation.Content = jaegerHinzufuegen;
        }

        private void btnBearbeiten_Click(object sender, RoutedEventArgs e)
        {
          
            GUI_Jaeger_Bearbeiten jaegerBearbeiten = new GUI_Jaeger_Bearbeiten();
            Content = jaegerBearbeiten;
        }
    }
}
