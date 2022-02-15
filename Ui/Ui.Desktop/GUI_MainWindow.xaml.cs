using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using JaegerMeister.MvvmSample.Ui.Desktop;

namespace Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Kalender kalender = new Kalender();
            Contmain.Content = kalender;
        }

        private void btn_Kalender(object sender, RoutedEventArgs e)
        {
            Kalender kalender = new Kalender();
            Contmain.Content = kalender;
        }

        private void btn_Termin(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Jaegerliste(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Abschussliste(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Wildunfaelle(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Einladungsuebersicht(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Dokumente(object sender, RoutedEventArgs e)
        {

        }
        private void btn_Urkundeerstellen(object sender, RoutedEventArgs e)
        {

        }
        private void btn_Admin(object sender, RoutedEventArgs e)
        {

        }
    }
}
