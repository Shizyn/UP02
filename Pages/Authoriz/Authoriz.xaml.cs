using System.Windows;
using System.Windows.Controls;


namespace UP02.Pages.Authoriz
{

    public partial class Authoriz : Page
    {

        public readonly Frame _frame;
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
                    _frame.Navigate(new Main.Main(_frame)); 
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Glav(_frame));
        }
    }
}
