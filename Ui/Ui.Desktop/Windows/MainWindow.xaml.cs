using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.ViewModels;
using JaegerMeister.MvvmSample.Ui.Desktop.Controls;

namespace JaegerMeister.MvvmSample.Ui.Desktop.Windows
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            KalenderControl kalender = new KalenderControl();
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
            KalenderControl kalender = new KalenderControl();
            Contmain.Content = kalender;
        }

        private void btn_Termin(object sender, RoutedEventArgs e)
        {
            TermineUebersichtControl termine = new TermineUebersichtControl();
            Contmain.Content = termine;
        }

        private void btn_Jaegerliste(object sender, RoutedEventArgs e)
        {
            JaegerInformationenControl jaeger = new JaegerInformationenControl();
            Contmain.Content = jaeger;
        }

        private void btn_Abschussliste(object sender, RoutedEventArgs e)
        {
            AbschusslisteViewModel abschussliste = new AbschusslisteViewModel();
            Contmain.Content = abschussliste;
        }

        private void btn_Wildunfaelle(object sender, RoutedEventArgs e)
        {
            WildunfaelleViewModel wildunfaelle = new WildunfaelleViewModel();
            Contmain.Content = wildunfaelle;
        }

        private void btn_Einladungsuebersicht(object sender, RoutedEventArgs e)
        {
            EinladungsuebersichtViewModel einladungen = new EinladungsuebersichtViewModel();
            Contmain.Content = einladungen;
        }

        private void btn_Dokumente(object sender, RoutedEventArgs e)
        {
            DokumenteVerwaltenControl dokumenteVerwalten = new DokumenteVerwaltenControl();
            Contmain.Content = dokumenteVerwalten;
        }
        private void btn_Urkundeerstellen(object sender, RoutedEventArgs e)
        {
            UrkundeErstellenControl urkunden = new UrkundeErstellenControl();
            Contmain.Content = urkunden;
        }
        private void btn_Admin(object sender, RoutedEventArgs e)
        {
            AdminControl admin = new AdminControl();
            Contmain.Content = admin;
        }
    }
}
