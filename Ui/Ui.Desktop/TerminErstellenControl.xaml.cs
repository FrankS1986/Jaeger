using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Windows.Controls;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    public partial class TerminErstellenControl : UserControl
    {
        public TerminErstellenControl()
        {
            InitializeComponent();
        }

        private void Abbruch_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("Abbruch");

            TermineUebersichtControl termineUebersicht = new TermineUebersichtControl();

            Content = termineUebersicht;
        }

        private void Bestaetigen_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<string>(this, (prop) =>
            {
                if (prop.Equals("Richtig"))
                {
                    TermineUebersichtControl termineUebersicht = new TermineUebersichtControl();

                    Content = termineUebersicht;
                }
            });
        }
    }
}
