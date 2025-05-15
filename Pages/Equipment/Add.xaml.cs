using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace UP02.Pages.Equipment
{
    public partial class Add : Page
    {
        List<Classes.Room> AllRooms = Classes.Room.Select();
        List<Classes.Models> AllModels = Classes.Models.Select();
        List<Classes.Users> AllUsers = Classes.Users.Select();
        List<Classes.Software> AllSoftware = Classes.Software.Select();
        Classes.Equipment equipment;
        public readonly System.Windows.Controls.Frame _frame;
        public Add(System.Windows.Controls.Frame frame, Classes.Equipment equipment = null)
        {
            InitializeComponent();
            _frame = frame;
            foreach (var item in AllRooms)
            {
                roomTB.Items.Add(item.Name);
            }
            foreach (var item in AllModels)
            {
                modelTB.Items.Add(item.Name);
            }
            foreach (var item in AllUsers)
            {
                userTB.Items.Add(item.Fio);
            }
            foreach (var item in AllUsers)
            {
                responsible_userTB.Items.Add(item.Fio);
            }
            foreach (var item in AllSoftware)
            {
                softwareTB.Items.Add(item.Name);
            }
            if (equipment != null)
            {
                this.equipment = equipment;
                nameTB.Text = equipment.name;
                if (equipment.photo != null && equipment.photo.Length > 0)
                {
                    SelectedImage.Source = ByteArrayToImage(equipment.photo);
                }
                else
                {
                    SelectedImage.Source = new BitmapImage(new Uri("/Image/placeholder.png", UriKind.Relative));
                }
                inventory_numberPB.Text = equipment.inventory_number.ToString();
                roomTB.SelectedIndex = AllRooms.FindIndex(x => x.Id == equipment.room_id);
                modelTB.SelectedIndex = AllModels.FindIndex(x => x.Id == equipment.model_id);
                userTB.SelectedIndex = AllUsers.FindIndex(x => x.Id == equipment.user_id);
                responsible_userTB.SelectedIndex = AllUsers.FindIndex(x => x.Id == equipment.responsible_user_id);
                directionPB.Text = equipment.direction_id.ToString();
                statusPB.Text = equipment.status_id.ToString();
                costTB.Text = equipment.cost.ToString();
                commentTB.Text = equipment.comment;
                softwareTB.SelectedIndex = AllSoftware.FindIndex(x => x.Id == equipment.software_id);
                BthAdd.Content = $"Изменить";
            }
            _frame = frame;
        }

        private void AddEquipmentBtn_Click(object sender, RoutedEventArgs e)
        {
            byte[] imageData = null;
            if (SelectedImage.Source is BitmapImage bitmapImage)
            {
                imageData = ImageToByteArray(bitmapImage);
            }

            if (this.equipment == null)
            {
                Classes.Equipment newEquipment = new Classes.Equipment(
                    0,
                    nameTB.Text,
                    imageData,
                    int.Parse(inventory_numberPB.Text),
                    AllRooms.Find(x => x.Name == roomTB.SelectedItem).Id,
                    AllModels.Find(x => x.Name == modelTB.SelectedItem).Id,
                    AllUsers.Find(x => x.Fio == userTB.SelectedItem).Id,
                    AllUsers.Find(x => x.Fio == responsible_userTB.SelectedItem).Id,
                    directionPB.Text,
                    statusPB.Text,
                    costTB.Text,
                    commentTB.Text,
                    AllSoftware.Find(x => x.Name == softwareTB.SelectedItem)?.Id ?? 0
                );
                newEquipment.Add();
                MessageBox.Show("Оборудование добавлено");
            }
            else
            {
                Classes.Equipment newEquipment = new Classes.Equipment(
                    equipment.id,
                    nameTB.Text,
                    imageData,
                    int.Parse(inventory_numberPB.Text),
                    AllRooms.Find(x => x.Name == roomTB.SelectedItem).Id,
                    AllModels.Find(x => x.Name == modelTB.SelectedItem).Id,
                    AllUsers.Find(x => x.Fio == userTB.SelectedItem).Id,
                    AllUsers.Find(x => x.Fio == responsible_userTB.SelectedItem).Id,
                    directionPB.Text,
                    statusPB.Text,
                    costTB.Text,
                    commentTB.Text,
                    AllSoftware.Find(x => x.Name == softwareTB.SelectedItem)?.Id ?? 0
                );
                newEquipment.Update();
                MessageBox.Show("Оборудование изменено");
            }

            _frame.Navigate(new Pages.Equipment.Main(_frame));
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
                    image.CacheOption = BitmapCacheOption.OnLoad;
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
