using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Consumables
{
    public partial class Main : Page
    {
        public List<Classes.Consumables> AllConsumable = Classes.Consumables.Select();
        public readonly Frame _frame;
        public Main(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            foreach (Classes.Consumables consumable in AllConsumable)
            {
                ConsumablesParent.Children.Add(new Pages.Consumables.Consumables(_frame, consumable));
            }
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }
    }
}