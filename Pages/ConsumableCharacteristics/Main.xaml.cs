using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UP02.Classes;

namespace UP02.Pages.ConsumableCharacteristics
{
    public partial class Main : Page
    {
        public List<Consumable_characteristic> AllConsumableCharacteristics = Consumable_characteristic.Select();
        public readonly Frame _frame;
        public Main(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            foreach (Consumable_characteristic consumable_characteristic in AllConsumableCharacteristics)
            {
                ConsumableCharacteristicsParent.Children.Add(new ConsumableCharacteristics(_frame, consumable_characteristic));
            }
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }
    }
}
