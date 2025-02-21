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
using UP02.Classes;
 

namespace UP02.Pages.Authoriz
{
    
    public partial class Authoriz : Page
    {

        private readonly Frame _frame;
        public Authoriz(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //LoginTextBox.Text = string.Empty;
            PasswordBox.Password = string.Empty;
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

            if (Classes.Users.Equals(login, password))
            {
                MessageBox.Show("Вы успешно вошли!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                if (_frame != null)
                {
                    _frame.Navigate(new Pages.Main.Main()); 
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
