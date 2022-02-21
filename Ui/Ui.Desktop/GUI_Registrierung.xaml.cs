using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
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
using Ui.Desktop;
using static JaegerMeister.MvvmSample.Logic.Ui.Logic_Registrierung;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für Regestrierung.xaml
    /// </summary>
    public partial class GUI_Registrierung : Window
    {
        public GUI_Registrierung()
        {
            InitializeComponent();

            Messenger.Default.Register<RegistrierungsErfolgsMessage>(this, (RegistrierungsErfolgsMessage loginProof) =>
            {
                if (loginProof.Success == true)
                {
                    MessageBox.Show("Registrierung war erfolgreich");
                    GUI_Login login = new GUI_Login();
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
            (this.DataContext as Logic_Registrierung).Tb_passwort = ((PasswordBox)sender).Password;
        }

        private void bestaetigen_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("Btn_bestaetigen");
        }

        private void abbruch_Click(object sender, RoutedEventArgs e)
        {
            GUI_Login gUI_Login = new GUI_Login();
            gUI_Login.Show();

            Close();
        }
    }
}
