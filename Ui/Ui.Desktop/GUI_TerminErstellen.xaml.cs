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

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für GUI_TerminErstellen.xaml
    /// </summary>
    public partial class GUI_TerminErstellen : UserControl
    {
        public GUI_TerminErstellen()
        {
            InitializeComponent();
        }

        private void Abbruch_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("Abbruch");

            GUI_TermineUebersicht termineUebersicht = new GUI_TermineUebersicht();

            Content = termineUebersicht;
        }

        private void Bestaetigen_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<string>(this, (prop) =>
            {
                if (prop.Equals("Richtig"))
                {
                    GUI_TermineUebersicht termineUebersicht = new GUI_TermineUebersicht();

                    Content = termineUebersicht;
                }
            });
        }
    }
}
