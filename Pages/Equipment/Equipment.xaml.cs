using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace UP02.Pages.Equipment
{
    public partial class Equipment : UserControl
    {
        List<Classes.Room> AllRooms = Classes.Room.Select();
        List<Classes.Models> AllModels = Classes.Models.Select();
        List<Classes.Users> AllUsers = Classes.Users.Select();
        List<Classes.Software> AllSoftware = Classes.Software.Select();
        Classes.Equipment equipment;
        public readonly Frame _frame;
        public Equipment(Frame frame, Classes.Equipment equipment)
        {
            InitializeComponent();
            _frame = frame;
            this.equipment = equipment;

            tbName.Text = equipment.name;
            if (equipment.photo != null && equipment.photo.Length > 0)
            {
                SelectedImage.Source = ByteArrayToImage(equipment.photo);
            }
            else
            {
                SelectedImage.Source = new BitmapImage(new Uri("/Image/placeholder.png", UriKind.Relative));
            }
            tbInventory_Number.Text = equipment.inventory_number.ToString();
            tbRoom.Text = AllRooms.Find(x => x.Id == equipment.room_id).Name;
            tbModel.Text = AllModels.Find(x => x.Id == equipment.model_id).Name;
            tbUser.Text = AllUsers.Find(x => x.Id == equipment.user_id).Fio;
            tbResponsible_User.Text = AllUsers.Find(x => x.Id == equipment.user_id).Fio;
            tbDirection.Text = equipment.direction_id.ToString();
            tbStatus.Text = equipment.status_id.ToString();
            tbCost.Text = equipment.cost.ToString();
            tbComment.Text = equipment.comment.ToString();
            tbSoftware.Text = AllSoftware.Find(x => x.Id == equipment.software_id).Name;
        }

        private void EditEquipment(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Equipment.Add(_frame, equipment));
        }

        private void DeleteEquipment(object sender, RoutedEventArgs e)
        {
            equipment.Delete();
            Classes.Equipment.Select();
            _frame.Navigate(new Pages.Equipment.Main(_frame));
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
