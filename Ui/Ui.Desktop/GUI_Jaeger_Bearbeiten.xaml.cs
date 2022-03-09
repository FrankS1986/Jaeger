using GalaSoft.MvvmLight.Messaging;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;



namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für Jaeger_Bearbeiten.xaml
    /// </summary>
    public partial class Jaeger_Bearbeiten : UserControl
    {
        public Jaeger_Bearbeiten()
        {
            InitializeComponent();
            Messenger.Default.Register<JaegerBearbeitenErfolgsMessage>(this, (JaegerBearbeitenErfolgsMessage editSuccess) =>
            {
                if (editSuccess.JaegerBearbeitenErfolg == true)
                {
                    MessageBox.Show("Jäger wurde erfolgreich bearbeitet");
                }
                else
                {
                    MessageBox.Show("Irgendetwas ist schief gelaufen, sorry.");
                }
            });
        }

        private void btnHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            GUI_JaegerHinzufuegen jaegerhinzufuegen = new GUI_JaegerHinzufuegen();
            Content = jaegerhinzufuegen;
        }
        private void btnAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            GUI_JaegerInformationen jaegerInfo = new GUI_JaegerInformationen();
            Content = jaegerInfo;
        }
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("Jaeger");
        }
        private void JaegerDG_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {
            Messenger.Default.Send("Select");
        }
        private void ContentControl_JaegerBearbeiten_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Messenger.Default.Send("Change");
        }
    }
}

