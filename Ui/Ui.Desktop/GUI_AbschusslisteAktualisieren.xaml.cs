﻿using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
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
    /// Interaktionslogik für GUI_AbschusslisteAktualisieren.xaml
    /// </summary>
    public partial class GUI_AbschusslisteAktualisieren : UserControl
    {
        public GUI_AbschusslisteAktualisieren()
        {
            InitializeComponent();
        }

       

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("Liste");
        }

        private void Jaeger_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Messenger.Default.Send("JaegerListe");
        }
    }
}
