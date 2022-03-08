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
using Ui.Desktop;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using GalaSoft.MvvmLight.Messaging;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für GUI_Termine.xaml
    /// </summary>
    public partial class GUI_TermineUebersicht : UserControl
    {

        public GUI_TermineUebersicht()
        {
            InitializeComponent();
        }

        private void termin_hinzufuegen_Click(object sender, RoutedEventArgs e)
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

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
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
