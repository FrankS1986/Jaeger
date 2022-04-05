using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    public partial class GUI_TermineUebersicht : UserControl
    {

        public GUI_TermineUebersicht()
        {
            InitializeComponent();
        }

        private void Termin_hinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("Termin");

            GUI_TerminErstellen terminErstellen = new GUI_TerminErstellen();

            Content = terminErstellen;
        }

        private void Btn_ÜbersichtRueckmeldungen_Click(object sender, RoutedEventArgs e)
        {
            Einladungsrueckmeldung einladungsrueckmeldung = new Einladungsrueckmeldung();

            Content = einladungsrueckmeldung;
        }

        private void Termine_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("Termine");
        }

        private void Termine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Messenger.Default.Send("Select");
        }

        private void Bearbeiten_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("Bearbeiten");

            GUI_TerminErstellen terminErstellen = new GUI_TerminErstellen();

            Content = terminErstellen;
        }
    }
}
