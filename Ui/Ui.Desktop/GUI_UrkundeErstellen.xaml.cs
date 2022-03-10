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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für Urkunden_Erstellen.xaml
    /// </summary>
    public partial class GUI_UrkundeErstellen : UserControl
    {
        public GUI_UrkundeErstellen()
        {
            InitializeComponent();
            Messenger.Default.Register<UrkundenErstellenProgressbarStartenMessage>(this, (UrkundenErstellenProgressbarStartenMessage loginProof) =>
            {
                if (loginProof.erfolg == true)
                {
                    GUI_ProgressbarWindow window = new GUI_ProgressbarWindow();
                    
                    window.Show();
                }

            });

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Messenger.Default.Send<UrkundenErstellenErfolgsMessage>(new UrkundenErstellenErfolgsMessage { erfolg = true });
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GUI_Kalender kalender = new GUI_Kalender();
            UrkundenErstellen.Content = kalender;
        }
    }
}
