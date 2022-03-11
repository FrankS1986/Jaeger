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
                if (unfall.wildunfallhizugefügt == true)
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

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }
    }
}
