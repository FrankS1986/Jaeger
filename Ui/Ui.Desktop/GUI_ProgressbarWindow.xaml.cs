﻿using GalaSoft.MvvmLight.Messaging;
using JaegerMeister.MvvmSample.Logic.Ui.Messages;
using System;
using System.Collections.Generic;
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
    public partial class GUI_ProgressbarWindow : Window
    {
        public GUI_ProgressbarWindow()
        {
            InitializeComponent();

            Messenger.Default.Register<ProgressbarValueMessage>(this, (ProgressbarValueMessage wert) =>
            {
               // MessageBox.Show("e");
                //Ladebalken.Value = wert.Value;
            });


        }
    }
}
