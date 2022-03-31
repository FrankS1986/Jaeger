using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.ViewModels;
using Ui.Desktop;
using static JaegerMeister.MvvmSample.Logic.Ui.ViewModels.LoginViewModel;

namespace JaegerMeister.MvvmSample.Ui.Desktop.Windows
{
    /// <summary>
    /// Interaktionslogik für LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            Messenger.Default.Register<LoginProofMessage>(this, (LoginProofMessage loginProof) =>
             {
                 if (loginProof.proof == true)
                 {
                     MessageBox.Show("Login war erfolgreich");
                     MainWindow main = new MainWindow();
                     main.Show();
                     Close();
                 }
                 else
                 {
                     MessageBox.Show("Login fehlgeschlagen");
                 }
             });


        }

        private void PwtNeu_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (this.DataContext as LoginViewModel).passwort = ((PasswordBox)sender).Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("Btn_Bestaetigen_clicked");
        }

        private void btn_registrieren_Click(object sender, RoutedEventArgs e)
        {
            RegistrierungWindow registrierung = new RegistrierungWindow();
            registrierung.Show();
            Close();
        }

        private void btn_abbruch_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_passwortVergessen_Click(object sender, RoutedEventArgs e)
        {
            SicherheitsFragestellungWindow sicherheitsFragestellung = new SicherheitsFragestellungWindow();
            sicherheitsFragestellung.Show();
            Close();
        }
    }
}
