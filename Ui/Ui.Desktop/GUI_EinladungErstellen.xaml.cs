using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Dokumente;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaktionslogik für GUIEinladungErstellen.xaml
    /// </summary>
    public partial class GUIEinladungErstellen : UserControl
    {
        public GUIEinladungErstellen()
        {
            InitializeComponent();
                  
            Messenger.Default.Register<EinladungenErstellenErfolgsMessage>(this, (EinladungenErstellenErfolgsMessage loginProof) =>
            {
                if (loginProof.erfolg == true)
                {
                    MessageBox.Show("Wurde eingeladen");
                   
                }
                else
                {
                    MessageBox.Show("Einladungen fehlgeschlagen");
                }
            });
        }

        private void Einladungen_Click(object sender, RoutedEventArgs e)
        {

         

        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("ButtonEinladungErstellen");
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Messenger.Default.Send("BereitsEingeladenMessage");
        }
    }
}
