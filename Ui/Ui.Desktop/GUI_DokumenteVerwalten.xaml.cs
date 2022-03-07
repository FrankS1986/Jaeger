using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Dokumente;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für GUIDokumenteVerwalten.xaml
    /// </summary>
    public partial class GUIDokumenteVerwalten : UserControl
    {
        public GUIDokumenteVerwalten()
        {
            InitializeComponent();
            DokumenteVerwaltenService serv = new DokumenteVerwaltenService();
            /*Messenger.Default.Register<DokumenteVerwaltenLoeschenMessage>(this, (DokumenteVerwaltenLoeschenMessage prop) =>
           {

              

           });*/

            Messenger.Default.Register<DokumenteVerwaltenLoeschenMessage>(this, (DokumenteVerwaltenLoeschenMessage message) =>
            {
                if (message.Dokument != null)
                {

                    MessageBoxResult result = MessageBox.Show("Wollen Sie die Datei wirklich löschen", "Datei löschen", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            serv.DokumenteLoeschen(message.Dokument);
                            break;

                        case MessageBoxResult.No:

                            break;

                    }
                }
            });

        }
        /// <summary>
        /// Fügt Dokumente hizu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (!string.IsNullOrEmpty(dateiname.Text))
            {
                openFileDialog.Filter = "Dokumente (.docx)|*.docx";

                if (openFileDialog.ShowDialog() == true)
                {

                    File.Copy(openFileDialog.FileName, (Paths.GetFilePath(@"Logic\\Logic.Ui\\Dokumente\\" + dateiname.Text + ".docx")));
                }

                Messenger.Default.Send("DokumenteVerwaltenMessage");
            }

            else
            {
                MessageBox.Show("Bitte Dateinamen vergeben");
            }
        }
    }
}
