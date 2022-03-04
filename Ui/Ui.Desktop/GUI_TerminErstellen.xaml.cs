using GalaSoft.MvvmLight.Messaging;
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
    /// Interaktionslogik für GUI_TerminErstellen.xaml
    /// </summary>
    public partial class GUI_TerminErstellen : UserControl
    {
        public GUI_TerminErstellen()
        {
            InitializeComponent();
        }

        private void Person_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("Personen");
        }

        private void Einladung_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Abbruch_Click(object sender, RoutedEventArgs e)
        {
            GUI_TermineUebersicht termineUebersicht = new GUI_TermineUebersicht();

            Content = termineUebersicht;
        }

        private void Bestaetigen_Click(object sender, RoutedEventArgs e)
        {
            GUI_TermineUebersicht termineUebersicht = new GUI_TermineUebersicht();

            Content = termineUebersicht;
        }

        private void Personen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Messenger.Default.Send("SelectPerson");
        }
    }
}
