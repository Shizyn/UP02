using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
