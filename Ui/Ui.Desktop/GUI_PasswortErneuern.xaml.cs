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
                    MessageBox.Show("fehlgeschlagen");
                }
            });


            Messenger.Default.Register<PasswortErneuernVergebenMessage>(this, (PasswortErneuernVergebenMessage vergeben) =>

            { 
               if(vergeben.passwortErneuernVergebenMessage==true)
                {
                    MessageBox.Show("Dieses Passwort wurde kürzlich von Ihnen vergeben. Bitte gebe Sie ein anderes ein.");
                }
            });

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
