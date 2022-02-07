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

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für Jaeger_Informationen.xaml
    /// </summary>
    public partial class Jaeger_Informationen : Window
    {
        public Jaeger_Informationen()
        {
            InitializeComponent();
        }

        private void Jaeger_Bearbeiten_Click(object sender, RoutedEventArgs e)
        {
            Jaeger_Bearbeiten jae_bea = new Jaeger_Bearbeiten();

            jaeger_informationen.Content = jae_bea.JaegerBearbeiten.Content;
        }

        private void Jaeger_Hinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            Jaeger_Hinzufuegen jae_hin = new Jaeger_Hinzufuegen();

            jaeger_informationen.Content = jae_hin.JaegerHinzufuegen.Content;
        }
    }
}
