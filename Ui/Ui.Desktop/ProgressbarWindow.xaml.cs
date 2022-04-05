using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaktionslogik für GUI_ProgressbarWindow.xaml
    /// </summary>
    public partial class ProgressbarWindow : Window
    {
        public ProgressbarWindow()
        {
            InitializeComponent();
            // Beendet die Seite GUI_ProgressbarWindow
            Messenger.Default.Register<ProgressbarValueMessage>(this, (ProgressbarValueMessage loginProof) =>
            {
                MessageBox.Show("Dokumente erstellen abgeschlossen");
                Close();

            });



        }
        /// <summary>
        /// Prosse arbeiten weiter auch wenn das programm geschlossen wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
        }

        /// <summary>
        /// Beendet die Registrierung  vom Messenger.Default.Register
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            Messenger.Default.Unregister<ProgressbarValueMessage>(this);

        }
    }
}
