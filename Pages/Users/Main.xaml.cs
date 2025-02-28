using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Users
{
    public partial class Main : Page
    {
        public readonly Frame _frame;
        public List<Classes.Users> AllUsers = Classes.Users.Select();
        public Main(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            foreach (Classes.Users users in AllUsers)
            {
                usersParent.Children.Add(new Users(_frame, users));
            }            
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }
    }
}
