using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für GUI_AbschusslisteAktualisieren.xaml
    /// </summary>
    public partial class GUI_AbschusslisteAktualisieren : UserControl
    {


        /// <summary>
        /// Abschussliste wird zurückgesetzt
        /// </summary>
        public GUI_AbschusslisteAktualisieren()
        {
            InitializeComponent();

            Messenger.Default.Send("Abschussliste");
        }
        /// <summary>
        /// Textbox Abschuesse nimmt nur noch zahlen an
        /// </summary>
        /// <param name="e"></param>
        private void CheckIsNumeric(TextCompositionEventArgs e)
        {
            int result;
            Abschuesse.Text.Contains(" ");
            if (!(int.TryParse(e.Text, out result)))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Textbox Abschuesse nimmt keine Leerzeichen mehr an
        /// </summary>
        /// <param name="e"></param>
        private void CheckSpace(KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Message wird gesendet wenn ein Termin gewählt  wurde um die Jägerliste zu aktualisieren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Messenger.Default.Send("JaegerListe");
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric(e);

        }
        /// <summary>
        /// Es wird der Messenger Registriert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<AbschusslisteAktualisierenSelectedMessage>(this, (AbschusslisteAktualisierenSelectedMessage loginProof) =>
            {
                if (loginProof.Abfrage == true)
                {
                    MessageBox.Show("Abschuss erfolgreich hinzugefügt");

                }
                else
                {
                    MessageBox.Show("Abschuss wurde nicht hinzugefügt. Bitte überprüfen Sie ob Termin, Jäger und Abschüsse ausgewählt sind");
                }
            });
        }
        /// <summary>
        /// Hier wird der Messenger beim wechseln des Fensters Entregestriert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister<AbschusslisteAktualisierenSelectedMessage>(this);
        }
        /// <summary>
        /// verhindert leerzeichen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Abschuesse_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CheckSpace(e);
        }



    }
}
