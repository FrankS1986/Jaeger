using System.Windows;
using System.Windows.Controls;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für GUI_Abschussliste.xaml
    /// </summary>
    public partial class GUI_Abschussliste : UserControl
    {
        public GUI_Abschussliste()
        {
            InitializeComponent();
        }
        private void btn_AbschuesseHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            GUI_AbschusslisteAktualisieren abschusslisteAktualisieren = new GUI_AbschusslisteAktualisieren();
            abschussliste.Content = abschusslisteAktualisieren;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GUI_AbschusslisteAktualisieren aktualisieren = new GUI_AbschusslisteAktualisieren();
            abschussliste.Content = aktualisieren;
        }
    }
}
