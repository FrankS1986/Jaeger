﻿using System;
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
using Ui.Desktop;

namespace JaegerMeister.MvvmSample.Ui.Desktop
{
    /// <summary>
    /// Interaktionslogik für Jaeger_Informationen.xaml
    /// </summary>
    public partial class GUI_JaegerInformationen : UserControl
    {
        public GUI_JaegerInformationen()
        {
            InitializeComponent();
        }

        private void Jaeger_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GUI_JaegerHinzufuegen jaegerHinzufuegen = new GUI_JaegerHinzufuegen();

            Content = jaegerHinzufuegen;
        }

        private void BtnBearbeiten(object sender, RoutedEventArgs e)
        {
            //GUI_JaegerBearbeiten jaeger_Bearbeiten = new GUI_JaegerBearbeiten();
            //ContentControl_JaegerInformation.Content = jaeger_Bearbeiten;

        }
    }
}
