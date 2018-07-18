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
using System.Windows.Shapes;

namespace _4._2BVproject
{
    /// <summary>
    /// Interaction logic for Dijalog.xaml
    /// </summary>
    public partial class Dijalog : Window
    {
        public Dijalog()
        {
            InitializeComponent();
        }

        public bool answer = false;

        public Dijalog(String message)
        {
            InitializeComponent();
            MessageLabel.Text = message;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            answer = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            answer = false;
            this.Close();
        }
    }
}
