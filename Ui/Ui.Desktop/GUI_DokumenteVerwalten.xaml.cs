using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Dokumente;
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

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (string.IsNullOrEmpty(dateiname.Text))
            {
                if (openFileDialog.ShowDialog() == true)
                {

                    File.Copy(openFileDialog.FileName, (Paths.GetFilePath(@"Logic\\Logic.Ui\\Dokumente\\" + dateiname.Text )));
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
