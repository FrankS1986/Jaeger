using System.Windows;
using System.Windows.Controls;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    public partial class GUI_Kalender : UserControl
    {
        public GUI_Kalender()
        {
            InitializeComponent();
        }
        private void TerminHinzufuegen(object sender, RoutedEventArgs e)
        {
            GUI_TerminErstellen terminErstellenControl = new GUI_TerminErstellen();
            ContentControlTerminErstellen.Content = terminErstellenControl;
        }
    }
}
