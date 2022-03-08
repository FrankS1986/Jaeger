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
using JaegerMeister.MvvmSample.Logic.Ui.Services;
using JaegerMeister.MvvmSample.Logic.Ui.Models;


namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für Jaeger_Bearbeiten.xaml
    /// </summary>
    public partial class Jaeger_Bearbeiten : UserControl
    {
        public Jaeger_Bearbeiten()
        {
            InitializeComponent();
        }

        //initiert Service Klasse mit Methode zum füllen der ListBox
        JaegerHinzufuegenService serv = new JaegerHinzufuegenService();

        //erstellt Liste vom Typ IDVorNachnameModel, ruft serv. Methode auf zum Anzeigen im Datagrid "Lb_jaeger"
        private List<IDVorNachnameModel> _listIDVorNachname = new List<IDVorNachnameModel>();
        public List <IDVorNachnameModel> Lb_jaeger
        {
            get
            {
                _listIDVorNachname = serv.ListeIDVorNachname();
                return _listIDVorNachname;
            }
        }
    }
}
