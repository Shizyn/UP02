using DocumentFormat.OpenXml.Bibliography;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace UP02.Pages.Consumables
{
    public partial class Add : Page
    {
        List<Classes.Users> AllUsers = Classes.Users.Select();
        List<Classes.Consumable_characteristic> AllConsumable_characteristic = Classes.Consumable_characteristic.Select();
        Classes.Consumables consumable;
        public readonly Frame _frame;
        public Add(Frame frame, Classes.Consumables consumable = null)
        {
            InitializeComponent();
            _frame = frame;
            foreach (var item in AllUsers)
            {
                FioTB.Items.Add(item.Fio);
            }
            foreach (var item in AllConsumable_characteristic)
            {
                Consumable_Type_IdTB.Items.Add(item.Characteristic_name);
            }
            if (consumable != null)
            {
                this.consumable = consumable;
                NameTB.Text = consumable.name;
                DescriptionPB.Text = consumable.description;
                Arrival_DatePB.Text = consumable.arrival_date.ToString();
                SelectedImage.Source = ByteArrayToImage(consumable.image);
                CountTB.Text = consumable.count.ToString();
                FioTB.SelectedIndex = AllUsers.FindIndex(x => x.Id == consumable.user_id);
                Consumable_Type_IdTB.SelectedIndex = AllConsumable_characteristic.FindIndex(x => x.Id == consumable.consumable_id);
                BthAdd.Content = $"Изменить";
            }
            _frame = frame;
        }

        private void AddConsumablesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTB.Text))
            {
                MessageBox.Show("Введите название.");
                return;
            }

            if (string.IsNullOrWhiteSpace(CountTB.Text) || !int.TryParse(CountTB.Text, out int count))
            {
                MessageBox.Show("Введите корректное количество.");
                return;
            }

            if (!DateTime.TryParse(Arrival_DatePB.Text, out DateTime arrivalDate))
            {
                MessageBox.Show("Введите корректную дату поступления.");
                return;
            }
            var selectedUser = AllUsers.Find(x => x.Fio == FioTB.SelectedItem?.ToString());
            if (selectedUser == null)
            {
                MessageBox.Show("Выберите пользователя.");
                return;
            }
            var selectedCharacteristicName = Consumable_Type_IdTB.SelectedItem?.ToString();
            var selectedCharacteristic = AllConsumable_characteristic.Find(x => x.Characteristic_name == selectedCharacteristicName);
            if (selectedCharacteristic == null)
            {
                MessageBox.Show("Выберите тип материала.");
                return;
            }
            byte[] imageData = null;
            if (SelectedImage.Source is BitmapImage bitmapImage)
            {
                imageData = ImageToByteArray(bitmapImage);
            }
            Classes.Consumables newConsumables;
            if (this.consumable == null)
            {
                newConsumables = new Classes.Consumables(
                    0,
                    NameTB.Text,
                    DescriptionPB.Text,
                    arrivalDate,
                    imageData,
                    count,
                    selectedUser.Id,
                    selectedCharacteristic.Id
                );
                newConsumables.Add();
                MessageBox.Show("Инвентаризация добавлена");
            }
            else
            {
                newConsumables = new Classes.Consumables(
                    consumable.id,
                    NameTB.Text,
                    DescriptionPB.Text,
                    arrivalDate,
                    imageData,
                    count,
                    selectedUser.Id,
                    selectedCharacteristic.Id
                );
                newConsumables.Update();
                MessageBox.Show("Инвентаризация изменена");
            }

            _frame.Navigate(new Main(_frame));
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }

        private void Pick_Photo(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите изображение";
            openFileDialog.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg;*.jpg)|*.jpeg;*.jpg|BMP Files (*.bmp)|*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string filePath = openFileDialog.FileName;

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(filePath);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    bitmap.Freeze();

                    SelectedImage.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
                }
            }
        }
        private byte[] ImageToByteArray(BitmapImage image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(ms);
                return ms.ToArray();
            }
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
                image.Freeze(); // Для работы с UI
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