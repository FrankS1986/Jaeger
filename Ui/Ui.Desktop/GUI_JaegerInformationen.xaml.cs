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

        private void BearbeitenButton(object sender, RoutedEventArgs e)
        {
            GUI_JaegerBearbeiten jaeger_Bearbeiten = new GUI_JaegerBearbeiten();
            ContentControl_JaegerInformation.Content = jaeger_Bearbeiten;

        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    GUI_JaegerBearbeiten jaegerBearbeiten = new GUI_JaegerBearbeiten();
        //    Content = jaegerBearbeiten;
        //}
    }
}
