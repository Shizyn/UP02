using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace UP02.Pages.Consumables
{
    public partial class Consumables : UserControl
    {
        List<Classes.Users> AllUsers = Classes.Users.Select();
        List<Classes.Consumable_characteristic> AllConsumable_characteristic = Classes.Consumable_characteristic.Select();
        Classes.Consumables consumable;
        public readonly Frame _frame;
        public Consumables(Frame frame, Classes.Consumables consumable)
        {
            InitializeComponent();
            _frame = frame;
            this.consumable = consumable;

            tbName.Text = consumable.name;
            tbDescription.Text = consumable.description;
            tbArrival_Date.Text = consumable.arrival_date.ToString();
            if (consumable.image != null && consumable.image.Length > 0)
            {
                SelectedImage.Source = ByteArrayToImage(consumable.image);
            }
            else
            {
                SelectedImage.Source = new BitmapImage(new Uri("/Image/placeholder.png", UriKind.Relative));
            }
            tbCount.Text = consumable.count.ToString();
            tbUser_Id.Text = AllUsers.Find(x => x.Id == consumable.user_id).Fio;
            tbConsumable_Type_Id.Text = AllConsumable_characteristic.Find(x => x.Id == consumable.consumable_id).Characteristic_name +
                                        ": " + AllConsumable_characteristic.Find(x => x.Id == consumable.consumable_id).Characteristic_value;
        }

        private void EditConsumable(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Consumables.Add(_frame, consumable));
        }

        private void DeleteConsumable(object sender, RoutedEventArgs e)
        {
            consumable.Delete();
            Classes.Consumables.Select();
            _frame.Navigate(new Pages.Consumables.Main(_frame));
        }

        private BitmapImage ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;

            try
            {
                BitmapImage image = new BitmapImage();
                using (MemoryStream ms = new MemoryStream(byteArray))
                {
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad; // Важно!
                    image.StreamSource = ms;
                    image.EndInit();
                }
                image.Freeze();
                return image;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
                return null;
            }
        }
    }
}
