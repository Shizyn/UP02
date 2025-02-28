using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UP02.Pages.Users
{
    public partial class Users : UserControl
    {
        Classes.Users users;
        public readonly Frame _frame;
        public Users(Frame frame, Classes.Users users)
        {
            InitializeComponent();
            _frame = frame;
            this.users = users;
            tbLogin.Text = users.Login;
            tbPassword.Text = users.Password;
            tbRole.Text = users.Role;
            tbEmail.Text = users.Email;
            tbFio.Text = users.Fio;
            tbPhone.Text = users.Phone;
            tbAddress.Text = users.Address;
        }

        private void EditUser(object sender, RoutedEventArgs e)
        {
            try
            {
                _frame.Navigate(new Add(_frame, users));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            users.Delete();
            Classes.Users.Select();
            _frame.Navigate(new Pages.Users.Main(_frame));
        }
    }
}
