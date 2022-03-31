using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.ViewModels;
using static JaegerMeister.MvvmSample.Logic.Ui.ViewModels.RegistrierungViewModel;

namespace JaegerMeister.MvvmSample.Ui.Desktop.Windows
{
    /// <summary>
    /// Interaktionslogik für RegistrierungWindow.xaml
    /// </summary>
    public partial class RegistrierungWindow : Window
    {
        public RegistrierungWindow()
        {
            InitializeComponent();

            Messenger.Default.Register<RegistrierungsErfolgsMessage>(this, (RegistrierungsErfolgsMessage loginProof) =>
            {
                if (loginProof.Success == true)
                {
                    MessageBox.Show("Registrierung war erfolgreich");
                    LoginWindow login = new LoginWindow();
                    login.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Registrierung fehlgeschlagen");
                }
            });

            Messenger.Default.Register<RegistrierungsAbfrageBenutzer>(this, (RegistrierungsAbfrageBenutzer loginProof) =>
            {
                if (loginProof.SuccessBenutzer == true)
                {
                    MessageBox.Show("Benutzername schon vorhanden. Bitte wählen Sie ein anderen");
                    
                }
                
            });
        }

       

        

        private void PasswordBox_PasswordChanged_1(object sender, RoutedEventArgs e)
        {
            (DataContext as RegistrierungViewModel).Tb_passwort = ((PasswordBox)sender).Password;
        }

        private void bestaetigen_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("Btn_bestaetigen");
        }

        private void abbruch_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow Login = new LoginWindow();
            Login.Show();

            Close();
        }
    }
}
