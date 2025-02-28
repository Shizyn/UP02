using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Room
{
    public partial class Add : Page
    {
        List<Classes.Users> AllUsers = Classes.Users.Select();
        Classes.Room rooms;
        public readonly Frame _frame;
        public Add(Frame frame, Classes.Room rooms = null)
        {
            InitializeComponent();

            foreach (var item in AllUsers)
            {
                responsible_user_idTB.Items.Add(item.Fio);
            }

            responsible_user_idTB.Items.Add("Выберите .....");

            if (rooms != null)
            {
                this.rooms = rooms;
                namePB.Text = rooms.Name;
                short_nameTB.Text = rooms.Short_name;
                responsible_user_idTB.SelectedIndex = AllUsers.FindIndex(x => x.Id == rooms.Responsible_user_id);
                BthAdd.Content = $"Изменить";
            }
            _frame = frame;
        }

        private void AddRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.rooms == null)
            {
                Classes.Room newRooms = new Classes.Room(
                    0,
                    namePB.Text,
                    short_nameTB.Text,
                    AllUsers.Find(x => x.Fio == responsible_user_idTB.SelectedItem).Id
                    );
                newRooms.Add();
                MessageBox.Show($"Аудитория добавлена");
            }
            if (this.rooms != null)
            {
                Classes.Room newRooms = new Classes.Room(
                    rooms.Id,
                    namePB.Text,
                    short_nameTB.Text,
                    AllUsers.Find(x => x.Fio == responsible_user_idTB.SelectedItem).Id
                    );
                newRooms.Update();
                MessageBox.Show($"Аудитория изменена");
            }
            _frame.Navigate(new Main(_frame));
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }        
    }
}
