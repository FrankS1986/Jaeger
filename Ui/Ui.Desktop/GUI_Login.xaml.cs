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
using System.Windows.Shapes;
using JaegerMeister.MvvmSample.Logic.Ui;
using GalaSoft.MvvmLight.Messaging;
using static JaegerMeister.MvvmSample.Logic.Ui.Logic_Login;
using Ui.Desktop;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für GUILogin.xaml
    /// </summary>
    public partial class GUI_Login : Window
    {
        public GUI_Login()
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
            (this.DataContext as Logic_Login).passwort = ((PasswordBox)sender).Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("Btn_Bestaetigen_clicked");
        }

        private void btn_registrieren_Click(object sender, RoutedEventArgs e)
        {
            GUI_Registrierung registrierung = new GUI_Registrierung();
            registrierung.Show();
            Close();
        }

        private void btn_abbruch_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_passwortVergessen_Click(object sender, RoutedEventArgs e)
        {
            GUI_SicherheitsFragestellung sicherheitsFragestellung = new GUI_SicherheitsFragestellung();
            sicherheitsFragestellung.Show();
            Close();
        }
    }
}
