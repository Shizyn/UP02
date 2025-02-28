using System.Collections.Generic;
using System.Windows.Controls;

namespace UP02.Pages.Room
{
    public partial class Room : UserControl
    {
        List<Classes.Users> AllUsers = Classes.Users.Select();
        Classes.Room rooms;
        public readonly Frame _frame;
        public Room(Frame frame, Classes.Room rooms)
        {
            InitializeComponent();
            _frame = frame;
            this.rooms = rooms;
            tbName.Text = rooms.Name;
            tbShort_Name.Text = rooms.Short_name;
            tbResponsible_User_Id.Text = AllUsers.Find(x => x.Id == rooms.Responsible_user_id).Fio;
        }        

        private void EditRoom(object sender, System.Windows.RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Room.Add(_frame, rooms));
        }
        
        private void DeleteRoom(object sender, System.Windows.RoutedEventArgs e)
        {
            rooms.Delete();
            Classes.Room.Select();
            _frame.Navigate(new Pages.Room.Main(_frame));
        }
    }
}
