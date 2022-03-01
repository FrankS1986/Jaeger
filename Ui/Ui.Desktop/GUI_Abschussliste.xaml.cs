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

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für GUI_Abschussliste.xaml
    /// </summary>
    public partial class GUI_Abschussliste : UserControl
    {
        public GUI_Abschussliste()
        {
            InitializeComponent();
        }

        private void Jaeger_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GUI_AbschusslisteAktualisieren aktualisieren = new GUI_AbschusslisteAktualisieren();
            abschussliste.Content = aktualisieren;
        }
    }
}
