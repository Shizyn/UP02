using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace UP02.Pages.Users
{
    public partial class Add : Page
    {
        Classes.Users users;
        public readonly Frame _frame;
        public Add(Frame frame, Classes.Users users)
        {
            InitializeComponent();
            _frame = frame;
            if (users != null)
            {
                this.users = users;
                LoginTB.Text = users.Login;
                PassPB.Text = users.Password;
                RolePB.Text = users.Role;
                EmailTB.Text = users.Email;
                FioTB.Text = users.Fio;
                PhoneTB.Text = users.Phone;
                AddressTB.Text = users.Address;
                BthAdd.Content = $"Изменить";
            }
        }

        private void AddUsersBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.users == null)
            {
                Classes.Users newUsers = new Classes.Users(
                    0,
                    LoginTB.Text,
                    PassPB.Text,
                    RolePB.Text,
                    EmailTB.Text,
                    FioTB.Text,
                    PhoneTB.Text,
                    AddressTB.Text);
                newUsers.Add();
                MessageBox.Show($"Пользователь добавлен");
            }
            if (this.users != null)
            { 
                Classes.Users newUsers = new Classes.Users(
                    users.Id,
                    LoginTB.Text,
                    PassPB.Text,
                    RolePB.Text,
                    EmailTB.Text,
                    FioTB.Text,
                    PhoneTB.Text,
                    AddressTB.Text);
                newUsers.Update();
                MessageBox.Show($"Пользователь изменён");
            }
            _frame.Navigate(new Main(_frame));
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }
    }
}
