using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für PasswortVergessen.xaml
    /// </summary>
    public partial class GUI_PasswortErneuern : Window
    {

        public GUI_PasswortErneuern()
        {
            InitializeComponent();


            Messenger.Default.Register<PasswortErneuernErfolgsMessage>(this, (PasswortErneuernErfolgsMessage loginProof) =>
            {
                if (loginProof.passwortErneuernErfolgsMessage == true)
                {
                    MessageBox.Show("Passwort erfolgreich vergeben");
                    GUI_Login login = new GUI_Login();
                    login.Show();

                    Close();
                }
                else
                {
                    MessageBox.Show("Fehlgeschlagen");
                }
            });


            Messenger.Default.Register<PasswortErneuernVergebenMessage>(this, (PasswortErneuernVergebenMessage vergeben) =>

            {
                if (vergeben.IstVergeben == true)
                {
                    MessageBox.Show("Dieses Passwort wurde kürzlich von Ihnen vergeben. Bitte gebe Sie ein anderes Passwort ein.");
                }

                else
                {
                    MessageBox.Show("Passwörter stimmen nicht überein");
                }
            });

        }
        /// <summary>
        /// Unregistriert den Messenger sodass nicht mehere gleiche Seiten aufgehen
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            Messenger.Default.Unregister<PasswortErneuernErfolgsMessage>(this);
            Messenger.Default.Unregister<PasswortErneuernVergebenMessage>(this);
        }

        private void PwtNeu_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (this.DataContext as Logic_PasswortErneuern).Neuespasswort = ((PasswordBox)sender).Password;
        }

        private void PwtNeuBe_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (this.DataContext as Logic_PasswortErneuern).Passwortbestaetigen = ((PasswordBox)sender).Password;
        }

        private void btn_abbruch_Click(object sender, RoutedEventArgs e)
        {
            GUI_SicherheitsFragestellung gUI_SicherheitsFragestellung = new GUI_SicherheitsFragestellung();
            gUI_SicherheitsFragestellung.Show();
            Close();
        }
    }
}
