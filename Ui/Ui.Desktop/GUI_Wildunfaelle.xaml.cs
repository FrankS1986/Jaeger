using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using System.Windows;
using System.Windows.Controls;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für Wildunfaelle.xaml
    /// </summary>
    public partial class GUI_Wildunfaelle : UserControl
    {
        public GUI_Wildunfaelle()
        {
            InitializeComponent();




            Messenger.Default.Send("zuruecksetzen");


        }
        /// <summary>
        /// Register wird initialisiert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<WildunfaelleErfolgsMessage>(this, (WildunfaelleErfolgsMessage unfall) =>
            {
                if (unfall.Wildunfallhinzugefuegt == true)
                {
                    MessageBox.Show("Wildunfall erfolgreich hinzugefügt");


                }
                else
                {
                    MessageBox.Show("Hinzufügen vom dem Wildunfall hat nicht geklappt ");
                }
            });
        }
        /// <summary>
        /// Register wird zurückgesetzt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister<WildunfaelleErfolgsMessage>(this);
        }


    }
}
