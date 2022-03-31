using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;

namespace JaegerMeister.MvvmSample.Ui.Desktop.Windows
{
    /// <summary>
    /// Interaktionslogik für Sicherheitsfragestellung.xaml
    /// </summary>
    public partial class SicherheitsFragestellungWindow : Window
    {
        public SicherheitsFragestellungWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<SicherheitsfragestellungsErfolgsMessage>(this, (SicherheitsfragestellungsErfolgsMessage loginProof) =>
            {
                if (loginProof.SuccesSicherheitsFragestellung)
                {

                    PasswortErneuernWindow passwortErneuern = new PasswortErneuernWindow();
                    passwortErneuern.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Falsche Antwort");
                }
            });
        }

        

        private void abbruch_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            Close();
        }

       
    }
}
