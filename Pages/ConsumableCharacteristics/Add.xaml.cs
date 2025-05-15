using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UP02.Classes;

namespace UP02.Pages.ConsumableCharacteristics
{
    public partial class Add : Page
    {
        Classes.Consumable_characteristic consumable_Characteristic;
        public readonly Frame _frame;
        public Add(Frame frame, Classes.Consumable_characteristic consumable_Characteristic = null)
        {
            InitializeComponent();
            _frame = frame;
            if (consumable_Characteristic != null)
            {
                this.consumable_Characteristic = consumable_Characteristic;
                characteristic_nameTB.Text = consumable_Characteristic.Characteristic_name;
                characteristic_valueTB.Text = consumable_Characteristic.Characteristic_value;
                BthAdd.Content = $"Изменить";
            }
            _frame = frame;
        }

        private void AddConsumable_characteristicsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.consumable_Characteristic == null)
            {
                Classes.Consumable_characteristic newConsumable_characteristic = new Classes.Consumable_characteristic(
                    0,
                    characteristic_nameTB.Text,
                    characteristic_valueTB.Text
                    );
                newConsumable_characteristic.Add();
                MessageBox.Show($"Новая характеристика добавлена");
            }
            if (this.consumable_Characteristic != null)
            {
                Classes.Consumable_characteristic newConsumable_characteristic = new Classes.Consumable_characteristic(
                    consumable_Characteristic.Id,
                    characteristic_nameTB.Text,
                    characteristic_valueTB.Text
                    );
                newConsumable_characteristic.Update();
                MessageBox.Show($"Характеристика изменена изменена");
            }
            _frame.Navigate(new Main(_frame));
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }        
    }
}
