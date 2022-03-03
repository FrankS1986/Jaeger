using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Dokumente;
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
        }

        private void Einladungen_Click(object sender, RoutedEventArgs e)
        {


            Messenger.Default.Send("Checkboxen");
        }

       

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
              
        }
    }
}
