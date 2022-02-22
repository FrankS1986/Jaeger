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
using JaegerMeister.MvvmSample.Logic;
using JaegerMeister.MvvmSample.Logic.Ui;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;

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
            GUI_Kalender kalender = new GUI_Kalender();
            Contmain.Content = kalender;
            ///<summary>
            ///Wenn der Benutzer kein Admin ist, wird der Button Admin vom Layout verschwinden.
            ///</summary>
            Messenger.Default.Register(this, (AdminAbfrage Success) =>
            {
                if (Success.Abfrage == false)
                {
                    Admin.Visibility = Visibility.Collapsed;
                }
            });
        }

        private void btn_Kalender(object sender, RoutedEventArgs e)
        {
            GUI_Kalender kalender = new GUI_Kalender();
            Contmain.Content = kalender;
        }

        private void btn_Termin(object sender, RoutedEventArgs e)
        {
            GUI_TermineUebersicht termine = new GUI_TermineUebersicht();
            Contmain.Content = termine;
        }

        private void btn_Jaegerliste(object sender, RoutedEventArgs e)
        {
            Jaeger_Informationen jaeger = new Jaeger_Informationen();
            Contmain.Content = jaeger;
        }

        private void btn_Abschussliste(object sender, RoutedEventArgs e)
        {
            GUI_Abschussliste abschussliste = new GUI_Abschussliste();
            Contmain.Content = abschussliste;
        }

        private void btn_Wildunfaelle(object sender, RoutedEventArgs e)
        {
            GUI_Wildunfaelle wildunfaelle = new GUI_Wildunfaelle();
            Contmain.Content = wildunfaelle;
        }

        private void btn_Einladungsuebersicht(object sender, RoutedEventArgs e)
        {
            GUIEinladungsuebersicht einladungen = new GUIEinladungsuebersicht();
            Contmain.Content = einladungen;
        }

        private void btn_Dokumente(object sender, RoutedEventArgs e)
        {
            GUIDokumenteVerwalten dokumenteVerwalten = new GUIDokumenteVerwalten();
            Contmain.Content = dokumenteVerwalten;
        }
        private void btn_Urkundeerstellen(object sender, RoutedEventArgs e)
        {
            GUI_UrkundeErstellen urkunden = new GUI_UrkundeErstellen();
            Contmain.Content = urkunden;
        }
        private void btn_Admin(object sender, RoutedEventArgs e)
        {
            GUI_Admin admin = new GUI_Admin();
            Contmain.Content = admin;
        }
    }
}
