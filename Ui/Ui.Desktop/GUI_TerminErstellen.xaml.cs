using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Windows.Controls;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
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
