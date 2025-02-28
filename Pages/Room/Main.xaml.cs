using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Room
{
    public partial class Main : Page
    {
        public readonly Frame _frame;
        public List<Classes.Room> AllRooms = Classes.Room.Select();
        public Main(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            foreach (Classes.Room rooms in AllRooms)
            {
                roomParent.Children.Add(new Room(_frame, rooms));
            }
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }
    }
}