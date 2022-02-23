using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für Sicherheitsfragestellung.xaml
    /// </summary>
    public partial class GUI_SicherheitsFragestellung : Window
    {
        public GUI_SicherheitsFragestellung()
        {
            InitializeComponent();
            Messenger.Default.Register<SicherheitsfragestellungsErfolgsMessage>(this, (SicherheitsfragestellungsErfolgsMessage loginProof) =>
            {
                if (loginProof.SuccesSicherheitsFragestellung)
                {

                    GUI_PasswortErneuern passwortErneuern = new GUI_PasswortErneuern();
                    passwortErneuern.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Falsche Antwort");
                }
            });
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Messenger.Default.Unregister<SicherheitsfragestellungsErfolgsMessage>(this);
            
        }

        private void abbruch_Click(object sender, RoutedEventArgs e)
        {
            GUI_Login login = new GUI_Login();
            login.Show();
            Close();
        }

       
    }
}
