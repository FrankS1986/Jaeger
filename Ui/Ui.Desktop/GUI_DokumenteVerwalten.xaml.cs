using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Dokumente;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    public partial class GUIDokumenteVerwalten : UserControl
    {
        public GUIDokumenteVerwalten()
        {
            InitializeComponent();

            Messenger.Default.Register<DokumenteVerwaltenLoeschenMessage>(this, (DokumenteVerwaltenLoeschenMessage message) =>
            {
                if (message.Dokument != null)
                {
                    MessageBoxResult result = MessageBox.Show("Wollen Sie die Datei wirklich löschen", "Datei löschen", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            DokumenteVerwaltenService serv = new DokumenteVerwaltenService();
                            serv.DokumenteLoeschen(message.Dokument);
                           
                            break;

                        case MessageBoxResult.No:
                            break;
                        case MessageBoxResult.None:
                            break;
                        case MessageBoxResult.OK:
                            break;
                        case MessageBoxResult.Cancel:
                            break;
                        default:
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
        private void DokumentHinzufuegenButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (!string.IsNullOrEmpty(dateiname.Text))
            {
                openFileDialog.Filter = "Dokumente (.docx)|*.docx";
                if (openFileDialog.ShowDialog() == true)
                {
                    if (!dateiname.Text.Contains("?") && !dateiname.Text.Contains("/") && !dateiname.Text.Contains("\\") && !dateiname.Text.Contains(":") && !dateiname.Text.Contains("\"") && !dateiname.Text.Contains("<") && !dateiname.Text.Contains(">") && !dateiname.Text.Contains("*") && !dateiname.Text.Contains(".") && !dateiname.Text.Contains("|"))
                    {
                        DokumenteVerwaltenService serv = new DokumenteVerwaltenService();
                        if (serv.DokumentUeberpruefen(dateiname.Text))
                        {
                            File.Copy(openFileDialog.FileName, (Paths.GetFilePath(@"Logic\\Logic.Ui\\Dokumente\\" + dateiname.Text + ".docx")));
                        }
                        else
                        {
                            MessageBox.Show("Dateiname schon vergeben.Bitte wählen Sie ein neuen");                      
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sie haben Sonderzeichen verwendet Bitte Dateinamen Überprüfen");                      
                    }
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
