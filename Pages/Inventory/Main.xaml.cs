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
using UP02.Classes;

namespace UP02.Pages.Inventory
{
    public partial class Main : Page
    {
        public List<Inventorychecks> AllInventorychecks = Inventorychecks.Select();
        public readonly Frame _frame;
        public Main(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            foreach (Inventorychecks inventorychecks in AllInventorychecks)
            {
                inventoryParent.Children.Add(new Inventory(_frame, inventorychecks));
            }
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }
    }
}
