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

namespace UP02.Pages.Software
{
    public partial class Main : Page
    {
        public List<Classes.Software> AllSoftwares = Classes.Software.Select();
        public readonly Frame _frame;
        public Main(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            foreach (Classes.Software softwares in AllSoftwares)
            {
                softwareParent.Children.Add(new Software(_frame, softwares));
            }
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }
    }
}
