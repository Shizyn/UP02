using System.Windows;
using System.Windows.Controls;
using UP02.Classes;

namespace UP02.Pages.ConsumableCharacteristics
{
    public partial class ConsumableCharacteristics : UserControl
    {
        Classes.Consumable_characteristic consumable_characteristics;
        public readonly Frame _frame;
        public ConsumableCharacteristics(Frame frame, Classes.Consumable_characteristic consumable_characteristics)
        {
            InitializeComponent();
            _frame = frame;
            this.consumable_characteristics = consumable_characteristics;
            tbCharacteristic_Name.Text = consumable_characteristics.Characteristic_name;
            tbCharacteristic_Value.Text = consumable_characteristics.Characteristic_value;
        }

        private void EditConsumableCharacteristics(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.ConsumableCharacteristics.Add(_frame, consumable_characteristics));
        }

        private void DeleteConsumableCharacteristics(object sender, RoutedEventArgs e)
        {
            consumable_characteristics.Delete();
            Classes.Consumable_characteristic.Select();
            _frame.Navigate(new Pages.ConsumableCharacteristics.Main(_frame));
        }
    }
}
