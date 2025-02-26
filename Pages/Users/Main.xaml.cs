using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Users
{
    public partial class Main : Page
    {
        public readonly System.Windows.Controls.Frame _frame;
        public IEnumerable<Classes.Users> AllUsers = Classes.Users.AllUsers();
        public Main(System.Windows.Controls.Frame frame)
        {
            InitializeComponent();
            foreach (var Users in AllUsers)
                usersParent.Children.Add(new Users());
            _frame = frame;
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }
    }
}
