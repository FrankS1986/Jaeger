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



       
    }
}
